﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Twizzar.SharedKernel.CoreInterfaces.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Twizzar.SharedKernel.CoreInterfaces.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is not supported. Only public and internal types are supported..
        /// </summary>
        public static string _0__is_not_supported__Only_public_and_internal_types_are_supported {
            get {
                return ResourceManager.GetString("0__is_not_supported__Only_public_and_internal_types_are_supported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to type cannot be different when merging..
        /// </summary>
        public static string ConfigurationItem_Merge_type_cannot_be_different_when_merging {
            get {
                return ResourceManager.GetString("ConfigurationItem_Merge_type_cannot_be_different_when_merging", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid TypeDescription, Class without ctor described..
        /// </summary>
        public static string CtorSelector_ClassWithoutCtor {
            get {
                return ResourceManager.GetString("CtorSelector_ClassWithoutCtor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find ctor for not class type..
        /// </summary>
        public static string CtorSelector_InvalidConfiguration {
            get {
                return ResourceManager.GetString("CtorSelector_InvalidConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element can only be created with the type UniqueBaseType..
        /// </summary>
        public static string DefinitionValue_InvalidCtorElements {
            get {
                return ResourceManager.GetString("DefinitionValue_InvalidCtorElements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Is not in range of {0}.
        /// </summary>
        public static string Parameter_Is_not_in_range_of__0_ {
            get {
                return ResourceManager.GetString("Parameter_Is_not_in_range_of__0_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type {0} not found..
        /// </summary>
        public static string TypeDescrption_not_found {
            get {
                return ResourceManager.GetString("TypeDescrption_not_found", resourceCulture);
            }
        }
    }
}
