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
  public class UploadImportFileResultV1 {
    /// <summary>
    /// Indicates if the file will be imported.  Warnings are allowed, import will continue but may lead to undesired values in the database.
    /// </summary>
    /// <value>Indicates if the file will be imported.  Warnings are allowed, import will continue but may lead to undesired values in the database.</value>
    [DataMember(Name="isOk", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isOk")]
    public bool? IsOk { get; set; }

    /// <summary>
    /// The list of errors found.  It may happen that if you fix one error new errors will be discovered.
    /// </summary>
    /// <value>The list of errors found.  It may happen that if you fix one error new errors will be discovered.</value>
    [DataMember(Name="errors", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "errors")]
    public List<UploadImportFileResultItemV1> Errors { get; set; }

    /// <summary>
    /// List of warnings.  It is best to have no warnings at all to avoid inconsistent or incorrect values in the database
    /// </summary>
    /// <value>List of warnings.  It is best to have no warnings at all to avoid inconsistent or incorrect values in the database</value>
    [DataMember(Name="warnings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "warnings")]
    public List<UploadImportFileResultItemV1> Warnings { get; set; }

    /// <summary>
    /// Informational messages
    /// </summary>
    /// <value>Informational messages</value>
    [DataMember(Name="informationalMessages", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "informationalMessages")]
    public List<UploadImportFileResultItemV1> InformationalMessages { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UploadImportFileResultV1 {\n");
      sb.Append("  IsOk: ").Append(IsOk).Append("\n");
      sb.Append("  Errors: ").Append(Errors).Append("\n");
      sb.Append("  Warnings: ").Append(Warnings).Append("\n");
      sb.Append("  InformationalMessages: ").Append(InformationalMessages).Append("\n");
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
