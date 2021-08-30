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
  public class Body1 {
    /// <summary>
    /// Code of the organization owning the domain.  If you do not know the code, contact us (see e-mail adres on top of this page)
    /// </summary>
    /// <value>Code of the organization owning the domain.  If you do not know the code, contact us (see e-mail adres on top of this page)</value>
    [DataMember(Name="OrganizationCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OrganizationCode")]
    public string OrganizationCode { get; set; }

    /// <summary>
    /// The bsdd import file in json format
    /// </summary>
    /// <value>The bsdd import file in json format</value>
    [DataMember(Name="FormFile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "FormFile")]
    public byte[] FormFile { get; set; }

    /// <summary>
    /// Set to true if you only want to validate the file. Even when there are no validation errors the file wil not be imported.  The validation result will not be send via e-mail.
    /// </summary>
    /// <value>Set to true if you only want to validate the file. Even when there are no validation errors the file wil not be imported.  The validation result will not be send via e-mail.</value>
    [DataMember(Name="ValidateOnly", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ValidateOnly")]
    public bool? ValidateOnly { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Body1 {\n");
      sb.Append("  OrganizationCode: ").Append(OrganizationCode).Append("\n");
      sb.Append("  FormFile: ").Append(FormFile).Append("\n");
      sb.Append("  ValidateOnly: ").Append(ValidateOnly).Append("\n");
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
