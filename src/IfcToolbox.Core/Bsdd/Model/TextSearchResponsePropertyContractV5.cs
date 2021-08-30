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
  public class TextSearchResponsePropertyContractV5 {
    /// <summary>
    /// Gets or Sets DomainNamespaceUri
    /// </summary>
    [DataMember(Name="domainNamespaceUri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "domainNamespaceUri")]
    public string DomainNamespaceUri { get; set; }

    /// <summary>
    /// Gets or Sets DomainName
    /// </summary>
    [DataMember(Name="domainName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "domainName")]
    public string DomainName { get; set; }

    /// <summary>
    /// Gets or Sets NamespaceUri
    /// </summary>
    [DataMember(Name="namespaceUri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "namespaceUri")]
    public string NamespaceUri { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class TextSearchResponsePropertyContractV5 {\n");
      sb.Append("  DomainNamespaceUri: ").Append(DomainNamespaceUri).Append("\n");
      sb.Append("  DomainName: ").Append(DomainName).Append("\n");
      sb.Append("  NamespaceUri: ").Append(NamespaceUri).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
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
