using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class SearchResultContractV2 {
    /// <summary>
    /// The total number of Classifications matching the search criteria
    /// </summary>
    /// <value>The total number of Classifications matching the search criteria</value>
    [DataMember(Name="numberOfClassificationsFound", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numberOfClassificationsFound")]
    public int? NumberOfClassificationsFound { get; set; }

    /// <summary>
    /// The list of Domains with found Classification and ClassificationProperties
    /// </summary>
    /// <value>The list of Domains with found Classification and ClassificationProperties</value>
    [DataMember(Name="domains", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "domains")]
    public List<DomainSearchResultContractV2> Domains { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SearchResultContractV2 {\n");
      sb.Append("  NumberOfClassificationsFound: ").Append(NumberOfClassificationsFound).Append("\n");
      sb.Append("  Domains: ").Append(Domains).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
