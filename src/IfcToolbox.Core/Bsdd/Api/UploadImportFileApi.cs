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
    public interface IUploadImportFileApi
    {
        /// <summary>
        /// Upload a bSDD import model json file, see https://github.com/buildingSMART/bSDD/tree/master/2020%20prototype/import-model for more information 
        /// </summary>
        /// <returns>UploadImportFileResultV1</returns>
        UploadImportFileResultV1 ApiUploadImportFileV1Post ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UploadImportFileApi : IUploadImportFileApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadImportFileApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public UploadImportFileApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadImportFileApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UploadImportFileApi(String basePath)
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
        /// Upload a bSDD import model json file, see https://github.com/buildingSMART/bSDD/tree/master/2020%20prototype/import-model for more information 
        /// </summary>
        /// <returns>UploadImportFileResultV1</returns>
        public UploadImportFileResultV1 ApiUploadImportFileV1Post ()
        {
    
            var path = "/api/UploadImportFile/v1";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

//                                    if (organizationCode != null) formParams.Add("OrganizationCode", ApiClient.ParameterToString(organizationCode)); // form parameter
//if (formFile != null) fileParams.Add("FormFile", ApiClient.ParameterToFile("FormFile", formFile));
//if (validateOnly != null) formParams.Add("ValidateOnly", ApiClient.ParameterToString(validateOnly)); // form parameter
                
            // authentication setting, if any
            String[] authSettings = new String[] { "aad-jwt" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiUploadImportFileV1Post: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ApiUploadImportFileV1Post: " + response.ErrorMessage, response.ErrorMessage);
    
            return (UploadImportFileResultV1) ApiClient.Deserialize(response.Content, typeof(UploadImportFileResultV1), response.Headers);
        }
    
    }
}
