// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>Collada_Spec_Test</NameSpace><Collection>Array</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>True</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>False</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace ColladaNET
{
    using ColladaNET.Elements;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /*
     * http://code4k.blogspot.de/2010/08/import-and-export-3d-collada-files-with.html
     */


    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot("COLLADA", Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class Collada
    {
        public const string XMLNAMESPACE = "http://www.collada.org/2005/11/COLLADASchema";


        // static flags and values for the whole collada library
        /// <summary>
        /// determines whether to use methods which provide support for the blender software package
        /// </summary>
        public static bool CompatibilityToBlender = false;


        // item fast access field: LibraryAnimationClips instance from Items-array
        private LibraryAnimationClips _libAnimationClips = null;
        // item fast access field: LibraryAnimationClips instance from Items-array
        private LibraryAnimations _libAnimations = null;
        // item fast access field: LibraryCameras instance from Items-array
        private LibraryCameras _libCameras = null;
        // item fast access field: LibraryControllers instance from Items-array
        private LibraryControllers _libControllers = null;
        // item fast access field: LibraryEffects instance from Items-array
        private LibraryEffects _libEffects = null;
        // item fast access field: LibraryForceFields instance from Items-array
        private LibraryForceFields _libForceFields = null;
        // item fast access field: LibraryGeometries instance from Items-array
        private LibraryGeometries _libGeometries = null;
        // item fast access field: LibraryGeometries instance from Items-array
        private LibraryImages _libImages = null;
        // item fast access field: LibraryLights instance from Items-array
        private LibraryLights _libLights = null;
        // item fast access field: LibraryGeometries instance from Items-array
        private LibraryMaterials _libMaterials = null;
        // item fast access field: LibraryNodes instance from Items-array
        private LibraryNodes _libNodes = null;
        // item fast access field: LibraryPhysicsMaterials instance from Items-array
        private LibraryPhysicsMaterials _libPhysicsMaterials = null;
        // item fast access field: LibraryPhysicsModels instance from Items-array
        private LibraryPhysicsModels _libPhysicsModels = null;
        // item fast access field: LibraryPhysicsScenes instance from Items-array
        private LibraryPhysicsScenes _libPhysicsScenes = null;
        // item fast access field: LibraryGeometries instance from Items-array
        private LibraryVisualScenes _libVisualScenes = null;


        [XmlElement()]
        public Asset asset
        { get; set; }

        [XmlElement("library_animation_clips", typeof(LibraryAnimationClips))]
        [XmlElement("library_animations", typeof(LibraryAnimations))]
        [XmlElement("library_cameras", typeof(LibraryCameras))]
        [XmlElement("library_controllers", typeof(LibraryControllers))]
        [XmlElement("library_effects", typeof(LibraryEffects))]
        [XmlElement("library_force_fields", typeof(LibraryForceFields))]
        [XmlElement("library_geometries", typeof(LibraryGeometries))]
        [XmlElement("library_images", typeof(LibraryImages))]
        [XmlElement("library_lights", typeof(LibraryLights))]
        [XmlElement("library_materials", typeof(LibraryMaterials))]
        [XmlElement("library_nodes", typeof(LibraryNodes))]
        [XmlElement("library_physics_materials", typeof(LibraryPhysicsMaterials))]
        [XmlElement("library_physics_models", typeof(LibraryPhysicsModels))]
        [XmlElement("library_physics_scenes", typeof(LibraryPhysicsScenes))]
        [XmlElement("library_visual_scenes", typeof(LibraryVisualScenes))]
        public LibraryBase[] libraries
        { get; set; }

        [XmlElement()]
        public Scene scene
        { get; set; }

        [XmlElement("extra")]
        public Extra[] extra
        { get; set; }

        [XmlAttribute()]
        public VersionType version
        { get; set; }



        #region Library properties
        [XmlIgnore()]
        // item fast access property: LibraryAnimationClips
        public LibraryAnimationClips AnimationClips
        { get { return _libAnimationClips ?? (_libAnimationClips = this.GetOrInit<LibraryAnimationClips>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryAnimations
        public LibraryAnimations Animations
        { get { return _libAnimations ?? (_libAnimations = this.GetOrInit<LibraryAnimations>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryCameras
        public LibraryCameras Cameras
        { get { return _libCameras ?? (_libCameras = this.GetOrInit<LibraryCameras>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryControllers
        public LibraryControllers Controllers
        { get { return _libControllers ?? (_libControllers = this.GetOrInit<LibraryControllers>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryEffects
        public LibraryEffects Effects
        { get { return _libEffects ?? (_libEffects = this.GetOrInit<LibraryEffects>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryForceFields
        public LibraryForceFields ForceFields
        { get { return _libForceFields ?? (_libForceFields = this.GetOrInit<LibraryForceFields>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryGeometries
        public LibraryGeometries Geometries
        { get { return _libGeometries ?? (_libGeometries = this.GetOrInit<LibraryGeometries>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryImages
        public LibraryImages Images
        { get { return _libImages ?? (_libImages = this.GetOrInit<LibraryImages>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryLights
        public LibraryLights Lights
        { get { return _libLights ?? (_libLights = this.GetOrInit<LibraryLights>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryMaterials
        public LibraryMaterials Materials
        { get { return _libMaterials ?? (_libMaterials = this.GetOrInit<LibraryMaterials>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryNodes
        public LibraryNodes Nodes
        { get { return _libNodes ?? (_libNodes = this.GetOrInit<LibraryNodes>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryPhysicsMaterials
        public LibraryPhysicsMaterials PhysicsMaterials
        { get { return _libPhysicsMaterials ?? (_libPhysicsMaterials = this.GetOrInit<LibraryPhysicsMaterials>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryPhysicsModels
        public LibraryPhysicsModels PhysicsModels
        { get { return _libPhysicsModels ?? (_libPhysicsModels = this.GetOrInit<LibraryPhysicsModels>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryPhysicsScenes
        public LibraryPhysicsScenes PhysicsScenes
        { get { return _libPhysicsScenes ?? (_libPhysicsScenes = this.GetOrInit<LibraryPhysicsScenes>()); } }

        [XmlIgnore()]
        // item fast access property: LibraryVisualScenes
        public LibraryVisualScenes VisualScenes
        { get { return _libVisualScenes ?? (_libVisualScenes = this.GetOrInit<LibraryVisualScenes>()); } }
        #endregion



        public void Invalidate<T>()
        {
            if (typeof(T).Equals(typeof(LibraryAnimations)))
                this._libAnimations = null;
            else if (typeof(T).Equals(typeof(LibraryAnimationClips)))
                this._libAnimationClips = null;
            else if (typeof(T).Equals(typeof(LibraryCameras)))
                this._libCameras = null;
            else if (typeof(T).Equals(typeof(LibraryControllers)))
                this._libControllers = null;
            else if (typeof(T).Equals(typeof(LibraryEffects)))
                this._libEffects = null;
            else if (typeof(T).Equals(typeof(LibraryForceFields)))
                this._libForceFields = null;
            else if (typeof(T).Equals(typeof(LibraryGeometries)))
                this._libGeometries = null;
            else if (typeof(T).Equals(typeof(LibraryImages)))
                this._libImages = null;
            else if (typeof(T).Equals(typeof(LibraryLights)))
                this._libLights = null;
            else if (typeof(T).Equals(typeof(LibraryMaterials)))
                this._libMaterials = null;
            else if (typeof(T).Equals(typeof(LibraryNodes)))
                this._libNodes = null;
            else if (typeof(T).Equals(typeof(LibraryPhysicsMaterials)))
                this._libPhysicsMaterials = null;
            else if (typeof(T).Equals(typeof(LibraryPhysicsModels)))
                this._libPhysicsModels = null;
            else if (typeof(T).Equals(typeof(LibraryPhysicsScenes)))
                this._libPhysicsScenes = null;
            else if (typeof(T).Equals(typeof(LibraryVisualScenes)))
                this._libVisualScenes = null;
        }
        public void InvalidateAll()
        {
            this._libAnimationClips = null;
            this._libAnimations = null;
            this._libCameras = null;
            this._libControllers = null;
            this._libEffects = null;
            this._libForceFields = null;
            this._libGeometries = null;
            this._libImages = null;
            this._libLights = null;
            this._libMaterials = null;
            this._libNodes = null;
            this._libPhysicsMaterials = null;
            this._libPhysicsModels = null;
            this._libPhysicsScenes = null;
            this._libVisualScenes = null;
        }



        public Effect GetEffectForMaterial(Material material)
        {
            if (material == null)
                return null;
            return this.Effects.FindByURL(material.instance_effect.url);
        }


        /// <summary>
        /// gets the item of the specified type from the instances items array
        /// </summary>
        /// <typeparam name="T">type of the item to retrieve</typeparam>
        /// <returns>an existing item instance or default(T)/null</returns>
        public T GetItem<T>() where T : LibraryBase
        {
            for (int i = 0; i < this.libraries.Length; i++)
                if (this.libraries[i] != null && this.libraries[i].GetType().Equals(typeof(T)))
                    return (T)this.libraries[i];
            return default(T);
        }

        /// <summary>
        /// gets the element of the specified type or initializes a new instance of it
        /// </summary>
        /// <typeparam name="T">type of the element to retrieve or initialize</typeparam>
        /// <returns>an existing element instance or the new created instance</returns>
        public T GetOrInit<T>() where T : LibraryBase, new()
        {
            for (int i = 0; i < this.libraries.Length; i++)
                if (this.libraries[i] != null && this.libraries[i].GetType().Equals(typeof(T)))
                    return (T)this.libraries[i];
            return new T();
        }

        public List<T> GetItemsForNode<T>(Node node) where T : LibraryItemBase
        {
            List<T> results = new List<T>();
            this.GetItemsForNode(node, results);
            return results;
        }


        public void GetItemsForNode<T>(Node node, List<T> results) where T : LibraryItemBase
        {
            if (results == null)
                return;
            results.Clear();

            if (typeof(T).Equals(Constants.TCamera))
            {
                foreach (InstanceCamera instance in node.instance_camera)
                {
                    Camera item = this.Cameras.FindByURL(instance.url);
                    if (item != null) results.Add(item as T);
                }
            }
            else if (typeof(T).Equals(Constants.TController))
            {
                foreach (InstanceController instance in node.instance_controller)
                {
                    Controller item = this.Controllers.FindByURL(instance.url);
                    if (item != null) results.Add(item as T);
                }
            }
            else if (typeof(T).Equals(Constants.TGeometry))
            {
                foreach (InstanceGeometry instance in node.instance_geometry)
                {
                    Geometry item = this.Geometries.FindByURL(instance.url);
                    if (item != null) results.Add(item as T);
                }
            }
            else if (typeof(T).Equals(Constants.TLight))
            {
                foreach (InstanceLight instance in node.instance_light)
                {
                    Light item = this.Lights.FindByURL(instance.url);
                    if (item != null) results.Add(item as T);
                }
            }
            else if (typeof(T).Equals(Constants.TNode))
            {
                foreach (InstanceNode instance in node.instance_node)
                {
                    Node item = this.Nodes.FindByURL(instance.url);
                    if (item != null) results.Add(item as T);
                }
            }
        }



        #region Public static - T - GetItem<T>(object[])
        /// <summary>
        /// gets the first occuring item from the array if one is available
        /// </summary>
        /// <typeparam name="T">type of the element to find</typeparam>
        /// <param name="items">array of untyped elements</param>
        /// <returns>the first elemet of type T or the default value of T</returns>
        public static T GetItem<T>(object[] items)
        {
            for (int i = 0; i < items.Length; i++)
                if (items[i] != null && items[i].GetType().Equals(typeof(T)))
                    return (T)items[i];
            return default(T);
        }
        #endregion


        public static T GetAs<T>(object item)
        {
            if (item != null && item.GetType().Equals(typeof(T)))
                return (T)item;
            return default(T);
        }
    }

}