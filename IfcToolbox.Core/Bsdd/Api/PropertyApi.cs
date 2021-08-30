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
    public interface IPropertyApi
    {
        /// <summary>
        /// Get Property details 
        /// </summary>
        /// <param name="namespaceUri">Namespace URI of the property, e.g. http://identifier.buildingsmart.org/uri/buildingsmart/ifc-4.3/prop/AirConditioning</param>
        /// <param name="languageCode">Language Code</param>
        /// <returns>PropertyContractV1</returns>
        PropertyContractV1 ApiPropertyV1Get (string namespaceUri, string languageCode);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PropertyApi : IPropertyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PropertyApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PropertyApi(String basePath)
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
        /// Get Property details 
        /// </summary>
        /// <param name="namespaceUri">Namespace URI of the property, e.g. http://identifier.buildingsmart.org/uri/buildingsmart/ifc-4.3/prop/AirConditioning</param>
        /// <param name="languageCode">Language Code</param>
        /// <returns>PropertyContractV1</returns>
        public PropertyContractV1 ApiPropertyV1Get (string namespaceUri, string languageCode)
        {
            // verify the required parameter 'namespaceUri' is set
            if (namespaceUri == null) throw new ApiException(400, "Missing required parameter 'namespaceUri' when calling ApiPropertyV1Get");
    
            var path = "/api/Property/v1";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (namespaceUri != null) queryParams.Add("namespaceUri", ApiClient.ParameterToString(namespaceUri)); // query parameter
 if (languageCode != null) queryParams.Add("languageCode", ApiClient.ParameterToString(languageCode)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiPropertyV1Get: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiPropertyV1Get: " + response.ErrorMessage, response.ErrorMessage);
    
            return (PropertyContractV1) ApiClient.Deserialize(response.Content, typeof(PropertyContractV1), response.Headers);
        }
    
    }
}
