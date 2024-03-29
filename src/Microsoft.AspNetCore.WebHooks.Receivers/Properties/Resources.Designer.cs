﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.AspNetCore.WebHooks.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.AspNetCore.WebHooks.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid WebHook constraint configuration encountered. Request contained no receiver name and &apos;{0}&apos; should have disallowed the request..
        /// </summary>
        internal static string EventConstraints_NoReceiverName {
            get {
                return ResourceManager.GetString("EventConstraints_NoReceiverName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A &apos;{0}&apos; WebHook request must contain a match for &apos;{1}&apos; in the HTTP request entity body indicating the type or types of event..
        /// </summary>
        internal static string EventMapper_NoBodyProperty {
            get {
                return ResourceManager.GetString("EventMapper_NoBodyProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value cannot be null or empty..
        /// </summary>
        internal static string General_ArgumentCannotBeNullOrEmpty {
            get {
                return ResourceManager.GetString("General_ArgumentCannotBeNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enum type &apos;{0}&apos; has no defined &apos;{1}&apos; value..
        /// </summary>
        internal static string General_InvalidEnumValue {
            get {
                return ResourceManager.GetString("General_InvalidEnumValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A &apos;{0}&apos; WebHook request must contain a &apos;{1}&apos; query parameter..
        /// </summary>
        internal static string General_NoQueryParameter {
            get {
                return ResourceManager.GetString("General_NoQueryParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A &apos;{0}&apos; WebHook verification request must contain a &apos;{1}&apos; query parameter..
        /// </summary>
        internal static string GetRequest_NoQueryParameter {
            get {
                return ResourceManager.GetString("GetRequest_NoQueryParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid metadata services found for the &apos;{0}&apos; WebHook receiver. Receivers must not provide both &apos;{1}&apos; and &apos;{2}&apos; services..
        /// </summary>
        internal static string PropertyProvider_ConflictingMetadataServices {
            get {
                return ResourceManager.GetString("PropertyProvider_ConflictingMetadataServices", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid metadata services found for the &apos;{0}&apos; WebHook receiver. Receivers must not have more than one &apos;{1}&apos; registration..
        /// </summary>
        internal static string PropertyProvider_DuplicateMetadata {
            get {
                return ResourceManager.GetString("PropertyProvider_DuplicateMetadata", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid metadata services found for the &apos;{0}&apos; WebHook receiver. Receiver must have an &apos;{1}&apos; implementation..
        /// </summary>
        internal static string PropertyProvider_MissingMetadata {
            get {
                return ResourceManager.GetString("PropertyProvider_MissingMetadata", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid metadata services found for the &apos;{0}&apos; WebHook receiver. Receivers with attributes implementing &apos;{1}&apos; must also provide a &apos;{2}&apos; or &apos;{3}&apos; service ..
        /// </summary>
        internal static string PropertyProvider_MissingMetadataServices {
            get {
                return ResourceManager.GetString("PropertyProvider_MissingMetadataServices", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The MVC model binding system failed. Model state is valid but model was not set..
        /// </summary>
        internal static string RequestReader_ModelBindingFailed {
            get {
                return ResourceManager.GetString("RequestReader_ModelBindingFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a valid configuration for the &apos;{0}&apos; WebHook receiver, instance &apos;{1}&apos;. The value must be at least {2} characters long..
        /// </summary>
        internal static string Security_BadSecret {
            get {
                return ResourceManager.GetString("Security_BadSecret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; WebHook receiver requires {1} in order to be secure. Register a WebHook URI of type &apos;{2}&apos;..
        /// </summary>
        internal static string Security_NoHttps {
            get {
                return ResourceManager.GetString("Security_NoHttps", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find a valid configuration for the &apos;{0}&apos; WebHook receiver. Configure secret keys for this receiver..
        /// </summary>
        internal static string Security_NoSecrets {
            get {
                return ResourceManager.GetString("Security_NoSecrets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; and &apos;{1}&apos; were applied to the same action. &apos;{2}&apos; must not be combined with attribute routing or non-WebHook constraints..
        /// </summary>
        internal static string SelectorModelProvider_MixedRouteWithWebHookAttribute {
            get {
                return ResourceManager.GetString("SelectorModelProvider_MixedRouteWithWebHookAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; WebHook receiver does not support content type &apos;{1}&apos;. The WebHook request must contain an entity body formatted as HTML form URL-encoded data..
        /// </summary>
        internal static string VerifyBody_NoFormData {
            get {
                return ResourceManager.GetString("VerifyBody_NoFormData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; WebHook receiver does not support content type &apos;{1}&apos;. The WebHook request must contain an entity body formatted as JSON..
        /// </summary>
        internal static string VerifyBody_NoJson {
            get {
                return ResourceManager.GetString("VerifyBody_NoJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; WebHook receiver does not support content type &apos;{1}&apos;. The WebHook request must contain an entity body formatted as XML..
        /// </summary>
        internal static string VerifyBody_NoXml {
            get {
                return ResourceManager.GetString("VerifyBody_NoXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; query parameter provided in the HTTP request did not match the expected value..
        /// </summary>
        internal static string VerifyCode_BadCode {
            get {
                return ResourceManager.GetString("VerifyCode_BadCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; WebHook receiver does not support an empty request body..
        /// </summary>
        internal static string VerifyMethod_BadBody {
            get {
                return ResourceManager.GetString("VerifyMethod_BadBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; WebHook receiver does not support the HTTP &apos;{1}&apos; method..
        /// </summary>
        internal static string VerifyMethod_BadMethod {
            get {
                return ResourceManager.GetString("VerifyMethod_BadMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A &apos;{0}&apos; WebHook request must contain a &apos;{1}&apos; HTTP header..
        /// </summary>
        internal static string VerifyRequiredValue_NoHeader {
            get {
                return ResourceManager.GetString("VerifyRequiredValue_NoHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A &apos;{0}&apos; WebHook request must contain a &apos;{1}&apos; value in the route data..
        /// </summary>
        internal static string VerifyRequiredValue_NoRouteValue {
            get {
                return ResourceManager.GetString("VerifyRequiredValue_NoRouteValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; header value is invalid. The &apos;{1}&apos; WebHook receiver requires a valid Base64-encoded string..
        /// </summary>
        internal static string VerifySignature_BadBase64Encoding {
            get {
                return ResourceManager.GetString("VerifySignature_BadBase64Encoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expecting exactly one &apos;{0}&apos; header field in the WebHook request but found {1}. Ensure the request contains exactly one &apos;{0}&apos; header field..
        /// </summary>
        internal static string VerifySignature_BadHeader {
            get {
                return ResourceManager.GetString("VerifySignature_BadHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; header value is invalid. The &apos;{1}&apos; WebHook receiver requires a valid hex-encoded string..
        /// </summary>
        internal static string VerifySignature_BadHexEncoding {
            get {
                return ResourceManager.GetString("VerifySignature_BadHexEncoding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The signature provided by the &apos;{0}&apos; header field does not match the value expected by the &apos;{1}&apos; WebHook receiver. WebHook request is invalid..
        /// </summary>
        internal static string VerifySignature_BadSignature {
            get {
                return ResourceManager.GetString("VerifySignature_BadSignature", resourceCulture);
            }
        }
    }
}
