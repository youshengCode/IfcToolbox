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
  public class ClassificationPropertyContractV2 {
    /// <summary>
    /// Name of the Domain this property belongs to
    /// </summary>
    /// <value>Name of the Domain this property belongs to</value>
    [DataMember(Name="propertyDomainName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyDomainName")]
    public string PropertyDomainName { get; set; }

    /// <summary>
    /// Unique identification of the property
    /// </summary>
    /// <value>Unique identification of the property</value>
    [DataMember(Name="propertyNamespaceUri", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertyNamespaceUri")]
    public string PropertyNamespaceUri { get; set; }

    /// <summary>
    /// Name of the property
    /// </summary>
    /// <value>Name of the property</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Plain language description of the property
    /// </summary>
    /// <value>Plain language description of the property</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Name of the Property Set (Pset), only in case it is an IFC property
    /// </summary>
    /// <value>Name of the Property Set (Pset), only in case it is an IFC property</value>
    [DataMember(Name="propertySet", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "propertySet")]
    public string PropertySet { get; set; }

    /// <summary>
    /// Predefined value: if the classification can have only one value for this property, this is it
    /// </summary>
    /// <value>Predefined value: if the classification can have only one value for this property, this is it</value>
    [DataMember(Name="predefinedValue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "predefinedValue")]
    public string PredefinedValue { get; set; }

    /// <summary>
    /// Illustrate possible values of the Property
    /// </summary>
    /// <value>Illustrate possible values of the Property</value>
    [DataMember(Name="example", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "example")]
    public string Example { get; set; }

    /// <summary>
    /// The quantity in plain text
    /// </summary>
    /// <value>The quantity in plain text</value>
    [DataMember(Name="physicalQuantity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "physicalQuantity")]
    public string PhysicalQuantity { get; set; }

    /// <summary>
    /// Dimension of the physical quantity
    /// </summary>
    /// <value>Dimension of the physical quantity</value>
    [DataMember(Name="dimension", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimension")]
    public string Dimension { get; set; }

    /// <summary>
    /// Gets or Sets DimensionLength
    /// </summary>
    [DataMember(Name="dimensionLength", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionLength")]
    public int? DimensionLength { get; set; }

    /// <summary>
    /// Gets or Sets DimensionMass
    /// </summary>
    [DataMember(Name="dimensionMass", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionMass")]
    public int? DimensionMass { get; set; }

    /// <summary>
    /// Gets or Sets DimensionTime
    /// </summary>
    [DataMember(Name="dimensionTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionTime")]
    public int? DimensionTime { get; set; }

    /// <summary>
    /// Gets or Sets DimensionElectricCurrent
    /// </summary>
    [DataMember(Name="dimensionElectricCurrent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionElectricCurrent")]
    public int? DimensionElectricCurrent { get; set; }

    /// <summary>
    /// Gets or Sets DimensionThermodynamicTemperature
    /// </summary>
    [DataMember(Name="dimensionThermodynamicTemperature", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionThermodynamicTemperature")]
    public int? DimensionThermodynamicTemperature { get; set; }

    /// <summary>
    /// Gets or Sets DimensionAmountOfSubstance
    /// </summary>
    [DataMember(Name="dimensionAmountOfSubstance", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionAmountOfSubstance")]
    public int? DimensionAmountOfSubstance { get; set; }

    /// <summary>
    /// Gets or Sets DimensionLuminousIntensity
    /// </summary>
    [DataMember(Name="dimensionLuminousIntensity", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dimensionLuminousIntensity")]
    public int? DimensionLuminousIntensity { get; set; }

    /// <summary>
    /// Method of measurement
    /// </summary>
    /// <value>Method of measurement</value>
    [DataMember(Name="methodOfMeasurement", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "methodOfMeasurement")]
    public string MethodOfMeasurement { get; set; }

    /// <summary>
    /// Format for expressing the value of the property
    /// </summary>
    /// <value>Format for expressing the value of the property</value>
    [DataMember(Name="dataType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dataType")]
    public string DataType { get; set; }

    /// <summary>
    /// Minimum value of the property, inclusive
    /// </summary>
    /// <value>Minimum value of the property, inclusive</value>
    [DataMember(Name="minInclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minInclusive")]
    public double? MinInclusive { get; set; }

    /// <summary>
    /// Maximum value of the property, inclusive
    /// </summary>
    /// <value>Maximum value of the property, inclusive</value>
    [DataMember(Name="maxInclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxInclusive")]
    public double? MaxInclusive { get; set; }

    /// <summary>
    /// Minimum value of the property, exclusive
    /// </summary>
    /// <value>Minimum value of the property, exclusive</value>
    [DataMember(Name="minExclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minExclusive")]
    public double? MinExclusive { get; set; }

    /// <summary>
    /// Maximum value of the property, exclusive
    /// </summary>
    /// <value>Maximum value of the property, exclusive</value>
    [DataMember(Name="maxExclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxExclusive")]
    public double? MaxExclusive { get; set; }

    /// <summary>
    /// An XML Schema Regular expression for the property value
    /// </summary>
    /// <value>An XML Schema Regular expression for the property value</value>
    [DataMember(Name="pattern", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pattern")]
    public string Pattern { get; set; }

    /// <summary>
    /// List of units to select from
    /// </summary>
    /// <value>List of units to select from</value>
    [DataMember(Name="units", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "units")]
    public List<string> Units { get; set; }

    /// <summary>
    /// List of possible values
    /// </summary>
    /// <value>List of possible values</value>
    [DataMember(Name="values", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "values")]
    public List<ClassificationPropertyValueContractV2> Values { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ClassificationPropertyContractV2 {\n");
      sb.Append("  PropertyDomainName: ").Append(PropertyDomainName).Append("\n");
      sb.Append("  PropertyNamespaceUri: ").Append(PropertyNamespaceUri).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  PropertySet: ").Append(PropertySet).Append("\n");
      sb.Append("  PredefinedValue: ").Append(PredefinedValue).Append("\n");
      sb.Append("  Example: ").Append(Example).Append("\n");
      sb.Append("  PhysicalQuantity: ").Append(PhysicalQuantity).Append("\n");
      sb.Append("  Dimension: ").Append(Dimension).Append("\n");
      sb.Append("  DimensionLength: ").Append(DimensionLength).Append("\n");
      sb.Append("  DimensionMass: ").Append(DimensionMass).Append("\n");
      sb.Append("  DimensionTime: ").Append(DimensionTime).Append("\n");
      sb.Append("  DimensionElectricCurrent: ").Append(DimensionElectricCurrent).Append("\n");
      sb.Append("  DimensionThermodynamicTemperature: ").Append(DimensionThermodynamicTemperature).Append("\n");
      sb.Append("  DimensionAmountOfSubstance: ").Append(DimensionAmountOfSubstance).Append("\n");
      sb.Append("  DimensionLuminousIntensity: ").Append(DimensionLuminousIntensity).Append("\n");
      sb.Append("  MethodOfMeasurement: ").Append(MethodOfMeasurement).Append("\n");
      sb.Append("  DataType: ").Append(DataType).Append("\n");
      sb.Append("  MinInclusive: ").Append(MinInclusive).Append("\n");
      sb.Append("  MaxInclusive: ").Append(MaxInclusive).Append("\n");
      sb.Append("  MinExclusive: ").Append(MinExclusive).Append("\n");
      sb.Append("  MaxExclusive: ").Append(MaxExclusive).Append("\n");
      sb.Append("  Pattern: ").Append(Pattern).Append("\n");
      sb.Append("  Units: ").Append(Units).Append("\n");
      sb.Append("  Values: ").Append(Values).Append("\n");
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
