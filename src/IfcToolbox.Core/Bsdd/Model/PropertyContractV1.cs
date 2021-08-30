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
  public class PropertyContractV1 {
    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets Example
    /// </summary>
    [DataMember(Name="example", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "example")]
    public string Example { get; set; }

    /// <summary>
    /// Gets or Sets ConnectedProperties
    /// </summary>
    [DataMember(Name="connectedProperties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "connectedProperties")]
    public string ConnectedProperties { get; set; }

    /// <summary>
    /// Gets or Sets PhysicalQuantity
    /// </summary>
    [DataMember(Name="physicalQuantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "physicalQuantity")]
    public string PhysicalQuantity { get; set; }

    /// <summary>
    /// Gets or Sets Dimension
    /// </summary>
    [DataMember(Name="dimension", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimension")]
    public string Dimension { get; set; }

    /// <summary>
    /// Gets or Sets MethodOfMeasurement
    /// </summary>
    [DataMember(Name="methodOfMeasurement", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "methodOfMeasurement")]
    public string MethodOfMeasurement { get; set; }

    /// <summary>
    /// Gets or Sets DataType
    /// </summary>
    [DataMember(Name="dataType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataType")]
    public string DataType { get; set; }

    /// <summary>
    /// Gets or Sets MinInclusive
    /// </summary>
    [DataMember(Name="minInclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minInclusive")]
    public double? MinInclusive { get; set; }

    /// <summary>
    /// Gets or Sets MaxInclusive
    /// </summary>
    [DataMember(Name="maxInclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxInclusive")]
    public double? MaxInclusive { get; set; }

    /// <summary>
    /// Gets or Sets MinExclusive
    /// </summary>
    [DataMember(Name="minExclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minExclusive")]
    public double? MinExclusive { get; set; }

    /// <summary>
    /// Gets or Sets MaxExclusive
    /// </summary>
    [DataMember(Name="maxExclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxExclusive")]
    public double? MaxExclusive { get; set; }

    /// <summary>
    /// An XML Schema Regular expression
    /// </summary>
    /// <value>An XML Schema Regular expression</value>
    [DataMember(Name="pattern", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pattern")]
    public string Pattern { get; set; }

    /// <summary>
    /// Gets or Sets IsDynamic
    /// </summary>
    [DataMember(Name="isDynamic", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isDynamic")]
    public bool? IsDynamic { get; set; }

    /// <summary>
    /// Multiple references to Unit semi-colon separated
    /// </summary>
    /// <value>Multiple references to Unit semi-colon separated</value>
    [DataMember(Name="units", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "units")]
    public string Units { get; set; }

    /// <summary>
    /// Get or set the Possible Values in array format
    /// </summary>
    /// <value>Get or set the Possible Values in array format</value>
    [DataMember(Name="possibleValuesList", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "possibleValuesList")]
    public List<string> PossibleValuesList { get; set; }

    /// <summary>
    /// Gets or Sets TextFormat
    /// </summary>
    [DataMember(Name="textFormat", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "textFormat")]
    public string TextFormat { get; set; }

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
      sb.Append("class PropertyContractV1 {\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Example: ").Append(Example).Append("\n");
      sb.Append("  ConnectedProperties: ").Append(ConnectedProperties).Append("\n");
      sb.Append("  PhysicalQuantity: ").Append(PhysicalQuantity).Append("\n");
      sb.Append("  Dimension: ").Append(Dimension).Append("\n");
      sb.Append("  MethodOfMeasurement: ").Append(MethodOfMeasurement).Append("\n");
      sb.Append("  DataType: ").Append(DataType).Append("\n");
      sb.Append("  MinInclusive: ").Append(MinInclusive).Append("\n");
      sb.Append("  MaxInclusive: ").Append(MaxInclusive).Append("\n");
      sb.Append("  MinExclusive: ").Append(MinExclusive).Append("\n");
      sb.Append("  MaxExclusive: ").Append(MaxExclusive).Append("\n");
      sb.Append("  Pattern: ").Append(Pattern).Append("\n");
      sb.Append("  IsDynamic: ").Append(IsDynamic).Append("\n");
      sb.Append("  Units: ").Append(Units).Append("\n");
      sb.Append("  PossibleValuesList: ").Append(PossibleValuesList).Append("\n");
      sb.Append("  TextFormat: ").Append(TextFormat).Append("\n");
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
