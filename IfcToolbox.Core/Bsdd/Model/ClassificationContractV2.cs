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
  public class ClassificationContractV2 {
    /// <summary>
    /// Gets or Sets Synonyms
    /// </summary>
    [DataMember(Name="synonyms", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "synonyms")]
    public List<string> Synonyms { get; set; }

    /// <summary>
    /// Gets or Sets RelatedIfcEntityNames
    /// </summary>
    [DataMember(Name="relatedIfcEntityNames", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relatedIfcEntityNames")]
    public List<string> RelatedIfcEntityNames { get; set; }

    /// <summary>
    /// Gets or Sets ParentClassificationReference
    /// </summary>
    [DataMember(Name="parentClassificationReference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parentClassificationReference")]
    public ClassificationReferenceContractV2 ParentClassificationReference { get; set; }

    /// <summary>
    /// Gets or Sets ClassificationProperties
    /// </summary>
    [DataMember(Name="classificationProperties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "classificationProperties")]
    public List<ClassificationPropertyContractV2> ClassificationProperties { get; set; }

    /// <summary>
    /// Gets or Sets ClassificationRelations
    /// </summary>
    [DataMember(Name="classificationRelations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "classificationRelations")]
    public List<ClassificationRelationContractV2> ClassificationRelations { get; set; }

    /// <summary>
    /// Gets or Sets ChildClassificationReferences
    /// </summary>
    [DataMember(Name="childClassificationReferences", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "childClassificationReferences")]
    public List<ClassificationReferenceContractV2> ChildClassificationReferences { get; set; }

    /// <summary>
    /// Code used originally by the domain
    /// </summary>
    /// <value>Code used originally by the domain</value>
    [DataMember(Name="code", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "code")]
    public string Code { get; set; }

    /// <summary>
    /// Gets or Sets Uid
    /// </summary>
    [DataMember(Name="uid", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "uid")]
    public string Uid { get; set; }

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
    /// Gets or Sets Definition
    /// </summary>
    [DataMember(Name="definition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "definition")]
    public string Definition { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// Gets or Sets ActivationDateUtc
    /// </summary>
    [DataMember(Name="activationDateUtc", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "activationDateUtc")]
    public DateTime? ActivationDateUtc { get; set; }

    /// <summary>
    /// Gets or Sets RevisionDateUtc
    /// </summary>
    [DataMember(Name="revisionDateUtc", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionDateUtc")]
    public DateTime? RevisionDateUtc { get; set; }

    /// <summary>
    /// Gets or Sets VersionDateUtc
    /// </summary>
    [DataMember(Name="versionDateUtc", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionDateUtc")]
    public DateTime? VersionDateUtc { get; set; }

    /// <summary>
    /// Gets or Sets DeActivationDateUtc
    /// </summary>
    [DataMember(Name="deActivationDateUtc", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deActivationDateUtc")]
    public DateTime? DeActivationDateUtc { get; set; }

    /// <summary>
    /// Gets or Sets VersionNumber
    /// </summary>
    [DataMember(Name="versionNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionNumber")]
    public int? VersionNumber { get; set; }

    /// <summary>
    /// Gets or Sets RevisionNumber
    /// </summary>
    [DataMember(Name="revisionNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionNumber")]
    public int? RevisionNumber { get; set; }

    /// <summary>
    /// Gets or Sets ReplacedObjectCodes
    /// </summary>
    [DataMember(Name="replacedObjectCodes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "replacedObjectCodes")]
    public string ReplacedObjectCodes { get; set; }

    /// <summary>
    /// Gets or Sets ReplacingObjectCodes
    /// </summary>
    [DataMember(Name="replacingObjectCodes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "replacingObjectCodes")]
    public string ReplacingObjectCodes { get; set; }

    /// <summary>
    /// Gets or Sets DeprecationExplanation
    /// </summary>
    [DataMember(Name="deprecationExplanation", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deprecationExplanation")]
    public string DeprecationExplanation { get; set; }

    /// <summary>
    /// Gets or Sets CreatorLanguageCode
    /// </summary>
    [DataMember(Name="creatorLanguageCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "creatorLanguageCode")]
    public string CreatorLanguageCode { get; set; }

    /// <summary>
    /// Gets or Sets VisualRepresentationUri
    /// </summary>
    [DataMember(Name="visualRepresentationUri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "visualRepresentationUri")]
    public string VisualRepresentationUri { get; set; }

    /// <summary>
    /// Gets or Sets CountriesOfUse
    /// </summary>
    [DataMember(Name="countriesOfUse", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countriesOfUse")]
    public string CountriesOfUse { get; set; }

    /// <summary>
    /// Gets or Sets SubdivisionsOfUse
    /// </summary>
    [DataMember(Name="subdivisionsOfUse", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "subdivisionsOfUse")]
    public string SubdivisionsOfUse { get; set; }

    /// <summary>
    /// Gets or Sets CountryOfOrigin
    /// </summary>
    [DataMember(Name="countryOfOrigin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "countryOfOrigin")]
    public string CountryOfOrigin { get; set; }

    /// <summary>
    /// Gets or Sets DocumentReference
    /// </summary>
    [DataMember(Name="documentReference", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "documentReference")]
    public string DocumentReference { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ClassificationContractV2 {\n");
      sb.Append("  Synonyms: ").Append(Synonyms).Append("\n");
      sb.Append("  RelatedIfcEntityNames: ").Append(RelatedIfcEntityNames).Append("\n");
      sb.Append("  ParentClassificationReference: ").Append(ParentClassificationReference).Append("\n");
      sb.Append("  ClassificationProperties: ").Append(ClassificationProperties).Append("\n");
      sb.Append("  ClassificationRelations: ").Append(ClassificationRelations).Append("\n");
      sb.Append("  ChildClassificationReferences: ").Append(ChildClassificationReferences).Append("\n");
      sb.Append("  Code: ").Append(Code).Append("\n");
      sb.Append("  Uid: ").Append(Uid).Append("\n");
      sb.Append("  NamespaceUri: ").Append(NamespaceUri).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Definition: ").Append(Definition).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  ActivationDateUtc: ").Append(ActivationDateUtc).Append("\n");
      sb.Append("  RevisionDateUtc: ").Append(RevisionDateUtc).Append("\n");
      sb.Append("  VersionDateUtc: ").Append(VersionDateUtc).Append("\n");
      sb.Append("  DeActivationDateUtc: ").Append(DeActivationDateUtc).Append("\n");
      sb.Append("  VersionNumber: ").Append(VersionNumber).Append("\n");
      sb.Append("  RevisionNumber: ").Append(RevisionNumber).Append("\n");
      sb.Append("  ReplacedObjectCodes: ").Append(ReplacedObjectCodes).Append("\n");
      sb.Append("  ReplacingObjectCodes: ").Append(ReplacingObjectCodes).Append("\n");
      sb.Append("  DeprecationExplanation: ").Append(DeprecationExplanation).Append("\n");
      sb.Append("  CreatorLanguageCode: ").Append(CreatorLanguageCode).Append("\n");
      sb.Append("  VisualRepresentationUri: ").Append(VisualRepresentationUri).Append("\n");
      sb.Append("  CountriesOfUse: ").Append(CountriesOfUse).Append("\n");
      sb.Append("  SubdivisionsOfUse: ").Append(SubdivisionsOfUse).Append("\n");
      sb.Append("  CountryOfOrigin: ").Append(CountryOfOrigin).Append("\n");
      sb.Append("  DocumentReference: ").Append(DocumentReference).Append("\n");
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
