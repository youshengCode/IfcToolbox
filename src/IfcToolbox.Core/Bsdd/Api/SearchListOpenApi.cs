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
    public interface ISearchListOpenApi
    {
        /// <summary>
        /// Search the bSDD database, get list of Classifications without details.  This &#x27;open&#x27; version is only temporary. Please use api/SearchList/v2 instead. The details can be requested per Classification via the Classification API
        /// </summary>
        /// <param name="domainNamespaceUri">The namespace uri of the Domain to filter on (required)</param>
        /// <param name="searchText">The text to search for (case and accent insensitive)</param>
        /// <param name="languageCode">The ISO language code to search in and to return the text in (case sensitive)  If no language code specified or the text is not available in the requested language, the text will be returned in the default language of the Domain.  If a language code has been given, the search takes place in texts of that language, otherwise searches will be done in the default language of the Domain.  If an invalid or not supported language code is given, a Bad Request will be returned.</param>
        /// <param name="relatedIfcEntity">The official IFC entity name to filter on (case sensitive)</param>
        /// <returns>SearchResultContractV2</returns>
        SearchResultContractV2 ApiSearchListOpenV2Get(string domainNamespaceUri, string searchText, string languageCode, string relatedIfcEntity);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SearchListOpenApi : ISearchListOpenApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchListOpenApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public SearchListOpenApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchListOpenApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchListOpenApi(String basePath)
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
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Search the bSDD database, get list of Classifications without details.  This &#x27;open&#x27; version is only temporary. Please use api/SearchList/v2 instead. The details can be requested per Classification via the Classification API
        /// </summary>
        /// <param name="domainNamespaceUri">The namespace uri of the Domain to filter on (required)</param>
        /// <param name="searchText">The text to search for (case and accent insensitive)</param>
        /// <param name="languageCode">The ISO language code to search in and to return the text in (case sensitive)  If no language code specified or the text is not available in the requested language, the text will be returned in the default language of the Domain.  If a language code has been given, the search takes place in texts of that language, otherwise searches will be done in the default language of the Domain.  If an invalid or not supported language code is given, a Bad Request will be returned.</param>
        /// <param name="relatedIfcEntity">The official IFC entity name to filter on (case sensitive)</param>
        /// <returns>SearchResultContractV2</returns>
        public SearchResultContractV2 ApiSearchListOpenV2Get(string domainNamespaceUri, string searchText, string languageCode, string relatedIfcEntity)
        {
            // verify the required parameter 'domainNamespaceUri' is set
            if (domainNamespaceUri == null) throw new ApiException(400, "Missing required parameter 'domainNamespaceUri' when calling ApiSearchListOpenV2Get");

            var path = "/api/SearchListOpen/v2";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (domainNamespaceUri != null) queryParams.Add("DomainNamespaceUri", ApiClient.ParameterToString(domainNamespaceUri)); // query parameter
            if (searchText != null) queryParams.Add("SearchText", ApiClient.ParameterToString(searchText)); // query parameter
            if (languageCode != null) queryParams.Add("LanguageCode", ApiClient.ParameterToString(languageCode)); // query parameter
            if (relatedIfcEntity != null) queryParams.Add("RelatedIfcEntity", ApiClient.ParameterToString(relatedIfcEntity)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiSearchListOpenV2Get: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiSearchListOpenV2Get: " + response.ErrorMessage, response.ErrorMessage);

            return (SearchResultContractV2)ApiClient.Deserialize(response.Content, typeof(SearchResultContractV2), response.Headers);
        }

    }
}
