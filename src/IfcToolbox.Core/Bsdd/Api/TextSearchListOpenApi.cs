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
    public interface ITextSearchListOpenApi
    {
        /// <summary>
        /// Search the bSDD database using free text, get list of Classifications and/or Properties matching the text.  This &#x27;open&#x27; version is only temporary. Please use api/TextSearchList/v2 instead. The details can be requested per Classification via the Classification API
        /// </summary>
        /// <param name="searchText">The text to search for, minimum 3 characters (case and accent insensitive)</param>
        /// <param name="typeFilter">Type filter: must be \&quot;All\&quot;, \&quot;Classifications\&quot; or \&quot;Properties\&quot; (case sensitive)</param>
        /// <param name="domainNamespaceUris">List of domain to filter on</param>
        /// <returns>TextSearchResponseContractV5</returns>
        TextSearchResponseContractV5 ApiTextSearchListOpenV5Get (string searchText, string typeFilter, List<string> domainNamespaceUris);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TextSearchListOpenApi : ITextSearchListOpenApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextSearchListOpenApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TextSearchListOpenApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TextSearchListOpenApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TextSearchListOpenApi(String basePath)
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
        /// Search the bSDD database using free text, get list of Classifications and/or Properties matching the text.  This &#x27;open&#x27; version is only temporary. Please use api/TextSearchList/v2 instead. The details can be requested per Classification via the Classification API
        /// </summary>
        /// <param name="searchText">The text to search for, minimum 3 characters (case and accent insensitive)</param>
        /// <param name="typeFilter">Type filter: must be \&quot;All\&quot;, \&quot;Classifications\&quot; or \&quot;Properties\&quot; (case sensitive)</param>
        /// <param name="domainNamespaceUris">List of domain to filter on</param>
        /// <returns>TextSearchResponseContractV5</returns>
        public TextSearchResponseContractV5 ApiTextSearchListOpenV5Get (string searchText, string typeFilter, List<string> domainNamespaceUris)
        {
            // verify the required parameter 'searchText' is set
            if (searchText == null) throw new ApiException(400, "Missing required parameter 'searchText' when calling ApiTextSearchListOpenV5Get");
    
            var path = "/api/TextSearchListOpen/v5";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (searchText != null) queryParams.Add("SearchText", ApiClient.ParameterToString(searchText)); // query parameter
 if (typeFilter != null) queryParams.Add("TypeFilter", ApiClient.ParameterToString(typeFilter)); // query parameter
 if (domainNamespaceUris != null) queryParams.Add("DomainNamespaceUris", ApiClient.ParameterToString(domainNamespaceUris)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiTextSearchListOpenV5Get: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiTextSearchListOpenV5Get: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TextSearchResponseContractV5) ApiClient.Deserialize(response.Content, typeof(TextSearchResponseContractV5), response.Headers);
        }
    
    }
}
