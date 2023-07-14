// See https://aka.ms/new-console-template for more information

using GBX.NET;
using GBX.NET.Engines.Plug;
//using GBX.NET.LZO;

using ColladaNET;
using ColladaNET.Elements;
using System.Numerics;
using System.Diagnostics;
using GBX.NET.Exceptions;
//using System.Text;
//using ColladaNET.Elements;
//using ColladaNET.Generation;

namespace CS2DAE
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Timing operations for diagnostics
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            //  Checking for user error
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please drag a GBX skin on this executable or start it in the command line, e.g.");
                System.Console.WriteLine("\n\t\"CarSkin2DAE.exe MainBody.solid.gbx\"\n");

                return;
            }


            // Reading GBX file
            GBX.NET.Lzo.SetLzo(typeof(GBX.NET.LZO.MiniLZO));

            //  Exception handling (not a GBX file, file not found)
            try
            {
                GBX.NET.Node? carSkin = GameBox.ParseNode(args[0]);

                var carParts = new List<Tuple<string, ushort[], CPlugVisual3D.Vertex[], CPlugVisual.TexCoordSet[], Iso4>>();

                if (carSkin is CPlugSolid solid)
                {
                    System.Console.WriteLine("Starting export...\n");

                    CPlug? tree = solid.Tree;
                    if(tree is CPlugTree cplugTree)
                    {
                        foreach(CPlugTree? carPart in cplugTree.Children)
                        {
                            if(carPart is not null)
                            {
                                Iso4? translation = carPart.Translation;
                                CPlugVisual? visual = carPart.Visual;

                                if(visual is CPlugVisualIndexedTriangles triangles)
                                {
                                    string name = carPart.Name is not null ? carPart.Name : "unnamed";
                                    ushort[] indices = triangles.Indices;
                                    CPlugVisual3D.Vertex[] vertices = triangles.Vertices;
                                    CPlugVisual.TexCoordSet[] texCoords = triangles.TexCoords;

                                    carParts.Add(new Tuple<string, ushort[], CPlugVisual3D.Vertex[], CPlugVisual.TexCoordSet[], Iso4>(name, indices, vertices, texCoords, translation is Iso4 trans ? trans : Iso4.Identity));
                                }
                            }
                        }
                    }
                }
                else if(carSkin is null)
                {
                    System.Console.WriteLine("Unknown error. Please report this bug at \"https://github.com/Mystixor/CarSkin2DAE\" or directly to @mystixor on Discord.\n");

                    return;
                }
                else
                {
                    System.Console.WriteLine("The GBX file you supplied is not a car skin (internally: \"CPlugSolid\")!");
                    System.Console.WriteLine("\nYour input:\t\"" + carSkin.GetType().Name + "\"\n");

                    return;
                }

                ColladaNET.ColladaBuilder daeBuilder = new ColladaNET.ColladaBuilder();

                //  Start building the COLLADA file
                daeBuilder.Begin("CarSkin2DAE", "ColladaNET");

                //  Adding a scene holding a visual scene, composing the final model on-screen
                daeBuilder.AddVisualScene("Scene");
                daeBuilder.SetSceneInstanceVisualScene("", "", "#Scene");

                //  Iterate over all parts of the carskin
                for (int i = 0; i < carParts.Count; i++)
                {
                    //  Get name and geometry data of car part
                    var name = carParts[i].Item1;
                    var indices = carParts[i].Item2;
                    var vertexes = carParts[i].Item3;
                    var texCoords = carParts[i].Item4;


                    //  Getting all triangles in the form of a COLLADA index buffer, as well as references to the COLLADA vertex and texcoord buffer (called input)
                    int[] indicesInt = new int[indices.Length * 2];
                    for(int j = 0; j < indices.Length; j++)
                    {
                        indicesInt[2 * j + 0] = indices[j];
                        indicesInt[2 * j + 1] = indices[j];
                    }

                    InputOffset[] inputs = new InputOffset[texCoords.Length + 1];
                    inputs[0] = new InputOffset("VERTEX", "#" + name + "-mesh-vertices", 0);
                    for(int j = 0; j < texCoords.Length; j++)
                    {
                        inputs[j + 1] = new InputOffset("TEXCOORD", "#" + name + "-mesh-map-" + j, (ulong)(1 + j), (ulong)j);
                    }
                    Triangles triangles = new Triangles((ulong)indices.Length / 3, "", indicesInt);
                    triangles.input = inputs;


                    //  Creating the vertices by referencing the position buffer
                    Vertices vertices = new Vertices(name + "-mesh-vertices", new Input("POSITION", "#" + name + "-mesh-positions"));


                    //  Creating the position buffer
                    float[] verticesFloat = new float[] { };
                    Array.Resize(ref verticesFloat, vertexes.Length * 3);
                    for(int j = 0; j < vertexes.Length; j++)
                    {
                        Vec3 pos = vertexes[j].Position;
                        verticesFloat[3 * j + 0] = pos.X;
                        verticesFloat[3 * j + 1] = pos.Y;
                        verticesFloat[3 * j + 2] = pos.Z;
                    }

                    FloatArray posFloatArray = new FloatArray(name + "-mesh-positions-array", verticesFloat);

                    Param[] posParam = new Param[] { new Param("float", "X"), new Param("float", "Y"), new Param("float", "Z") };
                    Accessor posAccessor = new Accessor((ulong)verticesFloat.Length / 3, "#" + name + "-mesh-positions-array", (ulong)0, (ulong)3, posParam);
                    Source.TechniqueCommon posTechniqueCommon = new Source.TechniqueCommon(posAccessor);

                    Source positionSource = new Source(name + "-mesh-positions", posFloatArray, posTechniqueCommon);


                    //  Creating the texcoord buffer
                    Source[] sources = new Source[] { };
                    Array.Resize(ref sources, texCoords.Length + 1);
                    sources[0] = positionSource;
                    Param[] texCoordParam = new Param[] { new Param("float", "S"), new Param("float", "T") };
                    for (int j = 0; j < texCoords.Length; j++)
                    {
                        float[] texCoordFloat = new float[] { };
                        Array.Resize(ref texCoordFloat, texCoords[j].Count * 2);
                        //foreach (var texCoord in texCoords[j])
                        for(int k = 0; k < texCoords[j].Count; k++)
                        {
                            Vec2 uv = texCoords[j].ElementAt(k).UV;
                            texCoordFloat[2 * k + 0] = uv.X;
                            texCoordFloat[2 * k + 1] = uv.Y;
                        }

                        FloatArray texCoordFloatArray = new FloatArray(name + "-mesh-map-" + j + "-array", texCoordFloat);

                        Accessor texCoordAccessor = new Accessor((ulong)texCoordFloat.Length / 2, "#" + name + "-mesh-map-" + j + "-array", (ulong)0, (ulong)2, texCoordParam);
                        Source.TechniqueCommon texCoordTechniqueCommon = new Source.TechniqueCommon(texCoordAccessor);

                        Source texCoordSource = new Source(name + "-mesh-map-" + j, texCoordFloatArray, texCoordTechniqueCommon);

                        sources[j + 1] = texCoordSource;
                    }


                    //  Assembling vertices and triangles to a finished mesh
                    Mesh mesh = new Mesh();
                    mesh.vertices = vertices;
                    mesh.primitives = new object[] { triangles };
                    mesh.source = sources;
                    Geometry geometry = new Geometry(carParts[i].Item1 + "-mesh", carParts[i].Item1, mesh);

                    daeBuilder.AddGeometry(geometry);


                    //  Construct a node that will get the transformation matrix and a reference to the respective geometry of the model
                    ColladaNET.Node NODE = new ColladaNET.Node(name, name, "", NodeType.NODE);

                    Iso4 m = carParts[i].Item5;
                    ColladaNET.Elements.Matrix matrix = new ColladaNET.Elements.Matrix("transform", new float[] { m.XX, m.XY, m.XZ, m.TX, m.YX, m.YY, m.YZ, m.TY, m.ZX, m.ZY, m.ZZ, m.TZ, 0F, 0F, 0F, 1F});
                    NODE.transformation = NODE.transformation.Append(matrix).ToArray();

                    NODE.AddInstanceGeometry("#" + name + "-mesh");

                    //  Adding the node to the visual scene, thereby making the model visible
                    daeBuilder.LibraryVisualScenes[0].AddNode(NODE);
                }

                //  Finish building the COLLADA model
                Collada outCollada = daeBuilder.End();

                //  Fixing the questionable default scaling of ColladaNET
                outCollada.asset.unit = new Asset.Unit(1f, "meter");

                //  Saving the COLLADA file next to the input GBX file
                outCollada.SaveToFile(args[0] + ".dae");

                System.Console.Out.WriteLine("Successfully exported car skin to: \"" + args[0] + ".dae\"");

                stopwatch.Stop();
                System.Console.Out.WriteLine("\nExport took {0} seconds.", stopwatch.ElapsedMilliseconds / 1000.0);
            }
            catch(NotAGbxException)
            {
                System.Console.Out.WriteLine("The supplied file is not a GBX file. Be sure to supply a GBX file like \"MainBody.solid.gbx\"!");
                System.Console.Out.WriteLine("\nYour input:\t\"" + args[0] + "\"");
            }
            catch(FileNotFoundException)
            {
                System.Console.Out.WriteLine("The supplied file path does not point to a valid file.");
                System.Console.Out.WriteLine("\nYour input:\t\"" + args[0] + "\"");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Unknown error. Please report this bug at \"https://github.com/Mystixor/CarSkin2DAE\" or directly to @mystixor on Discord.\n");
                System.Console.Out.WriteLine(ex.ToString());
            }
        }
    }
}