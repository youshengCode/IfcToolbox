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
  public class ClassificationPropertyValueContractV2 {
    /// <summary>
    /// Possible value of the property
    /// </summary>
    /// <value>Possible value of the property</value>
    [DataMember(Name="value", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "value")]
    public string Value { get; set; }

    /// <summary>
    /// (Optional) Sort number of value within the list of values for the Property
    /// </summary>
    /// <value>(Optional) Sort number of value within the list of values for the Property</value>
    [DataMember(Name="sortNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sortNumber")]
    public int? SortNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ClassificationPropertyValueContractV2 {\n");
      sb.Append("  Value: ").Append(Value).Append("\n");
      sb.Append("  SortNumber: ").Append(SortNumber).Append("\n");
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
