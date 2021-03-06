/* 
 * bSDD API prototype
 *
 * API to access the buildingSMART Data Dictionary
 *
 * OpenAPI spec version: v1
 * Contact: bsdd_support@buildingsmart.org
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IRequestExportFileApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>byte[]</returns>
        byte[] ApiRequestExportFilePreviewPost (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null);

        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>ApiResponse of byte[]</returns>
        ApiResponse<byte[]> ApiRequestExportFilePreviewPostWithHttpInfo (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>Task of byte[]</returns>
        System.Threading.Tasks.Task<byte[]> ApiRequestExportFilePreviewPostAsync (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null);

        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        System.Threading.Tasks.Task<ApiResponse<byte[]>> ApiRequestExportFilePreviewPostAsyncWithHttpInfo (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class RequestExportFileApi : IRequestExportFileApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestExportFileApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RequestExportFileApi(String basePath)
        {
            this.Configuration = new IO.Swagger.Client.Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestExportFileApi"/> class
        /// </summary>
        /// <returns></returns>
        public RequestExportFileApi()
        {
            this.Configuration = IO.Swagger.Client.Configuration.Default;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestExportFileApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public RequestExportFileApi(IO.Swagger.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = IO.Swagger.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IO.Swagger.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>byte[]</returns>
        public byte[] ApiRequestExportFilePreviewPost (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null)
        {
             ApiResponse<byte[]> localVarResponse = ApiRequestExportFilePreviewPostWithHttpInfo(domainNamespaceUri, xsltFormFile, exportFormat, useNestedClassifications);
             return localVarResponse.Data;
        }

        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>ApiResponse of byte[]</returns>
        public ApiResponse< byte[] > ApiRequestExportFilePreviewPostWithHttpInfo (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null)
        {
            // verify the required parameter 'domainNamespaceUri' is set
            if (domainNamespaceUri == null)
                throw new ApiException(400, "Missing required parameter 'domainNamespaceUri' when calling RequestExportFileApi->ApiRequestExportFilePreviewPost");

            var localVarPath = "/api/RequestExportFile/preview";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "multipart/form-data"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (domainNamespaceUri != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "DomainNamespaceUri", domainNamespaceUri)); // query parameter
            if (exportFormat != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "ExportFormat", exportFormat)); // query parameter
            if (useNestedClassifications != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "UseNestedClassifications", useNestedClassifications)); // query parameter
            if (xsltFormFile != null) localVarFileParams.Add("XsltFormFile", this.Configuration.ApiClient.ParameterToFile("XsltFormFile", xsltFormFile));
            // authentication (aad-jwt) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ApiRequestExportFilePreviewPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (byte[]) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(byte[])));
        }

        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>Task of byte[]</returns>
        public async System.Threading.Tasks.Task<byte[]> ApiRequestExportFilePreviewPostAsync (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null)
        {
             ApiResponse<byte[]> localVarResponse = await ApiRequestExportFilePreviewPostAsyncWithHttpInfo(domainNamespaceUri, xsltFormFile, exportFormat, useNestedClassifications);
             return localVarResponse.Data;

        }

        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;bSDD\&quot; you get an export in bSDD xml format with full details.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/Model/Exports 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="xsltFormFile"> (optional)</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: bSDD, Sketchup and Custom (optional)</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output (optional)</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        public async System.Threading.Tasks.Task<ApiResponse<byte[]>> ApiRequestExportFilePreviewPostAsyncWithHttpInfo (string domainNamespaceUri, byte[] xsltFormFile = null, string exportFormat = null, bool? useNestedClassifications = null)
        {
            // verify the required parameter 'domainNamespaceUri' is set
            if (domainNamespaceUri == null)
                throw new ApiException(400, "Missing required parameter 'domainNamespaceUri' when calling RequestExportFileApi->ApiRequestExportFilePreviewPost");

            var localVarPath = "/api/RequestExportFile/preview";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "multipart/form-data"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (domainNamespaceUri != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "DomainNamespaceUri", domainNamespaceUri)); // query parameter
            if (exportFormat != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "ExportFormat", exportFormat)); // query parameter
            if (useNestedClassifications != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "UseNestedClassifications", useNestedClassifications)); // query parameter
            if (xsltFormFile != null) localVarFileParams.Add("XsltFormFile", this.Configuration.ApiClient.ParameterToFile("XsltFormFile", xsltFormFile));
            // authentication (aad-jwt) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ApiRequestExportFilePreviewPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (byte[]) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(byte[])));
        }

    }
}
