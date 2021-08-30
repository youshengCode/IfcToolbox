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
  public class ClassificationSearchResultContractV2 {
    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets NamespaceUri
    /// </summary>
    [DataMember(Name="namespaceUri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "namespaceUri")]
    public string NamespaceUri { get; set; }

    /// <summary>
    /// Gets or Sets Definition
    /// </summary>
    [DataMember(Name="definition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "definition")]
    public string Definition { get; set; }

    /// <summary>
    /// Gets or Sets Synonyms
    /// </summary>
    [DataMember(Name="synonyms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "synonyms")]
    public List<string> Synonyms { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ClassificationSearchResultContractV2 {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  NamespaceUri: ").Append(NamespaceUri).Append("\n");
      sb.Append("  Definition: ").Append(Definition).Append("\n");
      sb.Append("  Synonyms: ").Append(Synonyms).Append("\n");
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
