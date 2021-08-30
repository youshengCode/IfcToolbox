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
  public class TextSearchResponseContractV5 {
    /// <summary>
    /// The list of Classifications found
    /// </summary>
    /// <value>The list of Classifications found</value>
    [DataMember(Name="classifications", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "classifications")]
    public List<TextSearchResponseClassificationContractV5> Classifications { get; set; }

    /// <summary>
    /// Gets or Sets Domains
    /// </summary>
    [DataMember(Name="domains", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "domains")]
    public List<TextSearchResponseDomainContractV5> Domains { get; set; }

    /// <summary>
    /// Gets or Sets Properties
    /// </summary>
    [DataMember(Name="properties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "properties")]
    public List<TextSearchResponsePropertyContractV5> Properties { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TextSearchResponseContractV5 {\n");
      sb.Append("  Classifications: ").Append(Classifications).Append("\n");
      sb.Append("  Domains: ").Append(Domains).Append("\n");
      sb.Append("  Properties: ").Append(Properties).Append("\n");
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
