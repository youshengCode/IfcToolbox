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
  public class ClassificationRelationContractV2 {
    /// <summary>
    /// String value of the RelationType enum
    /// </summary>
    /// <value>String value of the RelationType enum</value>
    [DataMember(Name="relationType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relationType")]
    public string RelationType { get; set; }

    /// <summary>
    /// Namespace URI of the related classification
    /// </summary>
    /// <value>Namespace URI of the related classification</value>
    [DataMember(Name="relatedClassificationUri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relatedClassificationUri")]
    public string RelatedClassificationUri { get; set; }

    /// <summary>
    /// Name of the related classification
    /// </summary>
    /// <value>Name of the related classification</value>
    [DataMember(Name="relatedClassificationName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relatedClassificationName")]
    public string RelatedClassificationName { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ClassificationRelationContractV2 {\n");
      sb.Append("  RelationType: ").Append(RelationType).Append("\n");
      sb.Append("  RelatedClassificationUri: ").Append(RelatedClassificationUri).Append("\n");
      sb.Append("  RelatedClassificationName: ").Append(RelatedClassificationName).Append("\n");
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
