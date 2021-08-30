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
  public class Body {
    /// <summary>
    /// The format the download should be in. Only applicable for Export Format 'Custom'
    /// </summary>
    /// <value>The format the download should be in. Only applicable for Export Format 'Custom'</value>
    [DataMember(Name="XsltFormFile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "XsltFormFile")]
    public byte[] XsltFormFile { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Body {\n");
      sb.Append("  XsltFormFile: ").Append(XsltFormFile).Append("\n");
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
