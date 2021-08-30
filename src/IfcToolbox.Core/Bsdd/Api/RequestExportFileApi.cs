using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRequestExportFileApi
    {
        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/2020%20prototype/Exports 
        /// </summary>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: Sketchup and Custom</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output</param>
        /// <returns>byte[]</returns>
        byte[] ApiRequestExportFilePreviewPost (string domainNamespaceUri, string exportFormat, bool? useNestedClassifications);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RequestExportFileApi : IRequestExportFileApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestExportFileApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RequestExportFileApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestExportFileApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RequestExportFileApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// PREVIEW  Request a file with an export of a domain.  If you choose format \&quot;Sketchup\&quot; you get an export in xsd format with limited content.  If you choose format \&quot;Custom\&quot; you need to supply a valid xslt file that will do the transformation.  An example of the xslt file and the xsd of the export format can be found at https://github.com/buildingSMART/bSDD/tree/master/2020%20prototype/Exports 
        /// </summary>
        /// <param name="domainNamespaceUri">The namespace uri of the domain to be downloaded</param>
        /// <param name="exportFormat">Select the Export Format you want the result in.  Allowed values at this moment are: Sketchup and Custom</param>
        /// <param name="useNestedClassifications">Use &#x27;false&#x27; if you want a flat list of Classifications  Use &#x27;true&#x27; if you want to reflect the Parent / Child Classification relations in the output</param>
        /// <returns>byte[]</returns>
        public byte[] ApiRequestExportFilePreviewPost (string domainNamespaceUri, string exportFormat, bool? useNestedClassifications)
        {
            // verify the required parameter 'domainNamespaceUri' is set
            if (domainNamespaceUri == null) throw new ApiException(400, "Missing required parameter 'domainNamespaceUri' when calling ApiRequestExportFilePreviewPost");
    
            var path = "/api/RequestExportFile/preview";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (domainNamespaceUri != null) queryParams.Add("DomainNamespaceUri", ApiClient.ParameterToString(domainNamespaceUri)); // query parameter
 if (exportFormat != null) queryParams.Add("ExportFormat", ApiClient.ParameterToString(exportFormat)); // query parameter
 if (useNestedClassifications != null) queryParams.Add("UseNestedClassifications", ApiClient.ParameterToString(useNestedClassifications)); // query parameter
 //if (xsltFormFile != null) fileParams.Add("XsltFormFile", ApiClient.ParameterToFile("XsltFormFile", xsltFormFile));
                
            // authentication setting, if any
            String[] authSettings = new String[] { "aad-jwt" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiRequestExportFilePreviewPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiRequestExportFilePreviewPost: " + response.ErrorMessage, response.ErrorMessage);
    
            return (byte[]) ApiClient.Deserialize(response.Content, typeof(byte[]), response.Headers);
        }
    
    }
}
