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
  public class DomainContractV2 {
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
    /// Gets or Sets Version
    /// </summary>
    [DataMember(Name="version", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "version")]
    public string Version { get; set; }

    /// <summary>
    /// Gets or Sets OrganizationNameOwner
    /// </summary>
    [DataMember(Name="organizationNameOwner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "organizationNameOwner")]
    public string OrganizationNameOwner { get; set; }

    /// <summary>
    /// Gets or Sets DefaultLanguageCode
    /// </summary>
    [DataMember(Name="defaultLanguageCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "defaultLanguageCode")]
    public string DefaultLanguageCode { get; set; }

    /// <summary>
    /// Gets or Sets License
    /// </summary>
    [DataMember(Name="license", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "license")]
    public string License { get; set; }

    /// <summary>
    /// Gets or Sets LicenseUrl
    /// </summary>
    [DataMember(Name="licenseUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "licenseUrl")]
    public string LicenseUrl { get; set; }

    /// <summary>
    /// Gets or Sets QualityAssuranceProcedure
    /// </summary>
    [DataMember(Name="qualityAssuranceProcedure", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "qualityAssuranceProcedure")]
    public string QualityAssuranceProcedure { get; set; }

    /// <summary>
    /// Gets or Sets QualityAssuranceProcedureUrl
    /// </summary>
    [DataMember(Name="qualityAssuranceProcedureUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "qualityAssuranceProcedureUrl")]
    public string QualityAssuranceProcedureUrl { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DomainContractV2 {\n");
      sb.Append("  NamespaceUri: ").Append(NamespaceUri).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Version: ").Append(Version).Append("\n");
      sb.Append("  OrganizationNameOwner: ").Append(OrganizationNameOwner).Append("\n");
      sb.Append("  DefaultLanguageCode: ").Append(DefaultLanguageCode).Append("\n");
      sb.Append("  License: ").Append(License).Append("\n");
      sb.Append("  LicenseUrl: ").Append(LicenseUrl).Append("\n");
      sb.Append("  QualityAssuranceProcedure: ").Append(QualityAssuranceProcedure).Append("\n");
      sb.Append("  QualityAssuranceProcedureUrl: ").Append(QualityAssuranceProcedureUrl).Append("\n");
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
