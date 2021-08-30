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
  public class GraphQLQuery {
    /// <summary>
    /// Gets or Sets OperationName
    /// </summary>
    [DataMember(Name="operationName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "operationName")]
    public string OperationName { get; set; }

    /// <summary>
    /// Gets or Sets NamedQuery
    /// </summary>
    [DataMember(Name="namedQuery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "namedQuery")]
    public string NamedQuery { get; set; }

    /// <summary>
    /// Gets or Sets Query
    /// </summary>
    [DataMember(Name="query", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "query")]
    public string Query { get; set; }

    /// <summary>
    /// Gets or Sets Variables
    /// </summary>
    [DataMember(Name="variables", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "variables")]
    public Dictionary<string, Object> Variables { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GraphQLQuery {\n");
      sb.Append("  OperationName: ").Append(OperationName).Append("\n");
      sb.Append("  NamedQuery: ").Append(NamedQuery).Append("\n");
      sb.Append("  Query: ").Append(Query).Append("\n");
      sb.Append("  Variables: ").Append(Variables).Append("\n");
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
