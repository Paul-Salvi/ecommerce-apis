﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.Connector.Model {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class FaultMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FaultMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ecommerce.Connector.Model.Exceptions.FaultMessages", typeof(FaultMessages).Assembly);
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
        ///   Looks up a localized string similar to Unable to resolve the {0} type. {1}. Contact your system administrator for more information..
        /// </summary>
        public static string CouldNotResolveType {
            get {
                return ResourceManager.GetString("CouldNotResolveType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0}.{1} value must be in YYYY-MM-DD format..
        /// </summary>
        public static string InvalidDateTimeFormat {
            get {
                return ResourceManager.GetString("InvalidDateTimeFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following headers have invalid value in the request : {0}.
        /// </summary>
        public static string InvalidRequestHeaders {
            get {
                return ResourceManager.GetString("InvalidRequestHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0}.{1} value must be {2}. .
        /// </summary>
        public static string InvalidValueForInputType {
            get {
                return ResourceManager.GetString("InvalidValueForInputType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mandatory field {0} is missing.
        /// </summary>
        public static string MandatoryFieldMissing {
            get {
                return ResourceManager.GetString("MandatoryFieldMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The values for the following keys are missing in Amazon Web Services (AWS) Parameter Store: {0}.
        /// </summary>
        public static string MissingKeysInParameterStore {
            get {
                return ResourceManager.GetString("MissingKeysInParameterStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following headers are missing in the request : {0}.
        /// </summary>
        public static string MissingRequestHeaders {
            get {
                return ResourceManager.GetString("MissingRequestHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred while communicating with Amazon Web Services (AWS) Parameter Store..
        /// </summary>
        public static string ParameterStoreCommunicationError {
            get {
                return ResourceManager.GetString("ParameterStoreCommunicationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No request found. You must provide a valid request..
        /// </summary>
        public static string RequestNotFound {
            get {
                return ResourceManager.GetString("RequestNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred while communicating with the {0} service. .
        /// </summary>
        public static string ServiceCommunication {
            get {
                return ResourceManager.GetString("ServiceCommunication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Internal server error occured. Please check the logs for more details.
        /// </summary>
        public static string UnexpectedSystemException {
            get {
                return ResourceManager.GetString("UnexpectedSystemException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following validation errors occurred: .
        /// </summary>
        public static string ValidationFailure {
            get {
                return ResourceManager.GetString("ValidationFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value is null or empty for mandatory field {0}.
        /// </summary>
        public static string ValueCannotBeNullOrEmptyForMandatoryField {
            get {
                return ResourceManager.GetString("ValueCannotBeNullOrEmptyForMandatoryField", resourceCulture);
            }
        }
    }
}