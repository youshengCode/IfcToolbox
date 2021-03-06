/* 
 * bSDD API prototype
 *
 * API to access the buildingSMART Data Dictionary
 *
 * OpenAPI spec version: v1
 * Contact: bsdd_support@buildingsmart.org
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// ClassificationSearchResultContractV2
    /// </summary>
    [DataContract]
        public partial class ClassificationSearchResultContractV2 :  IEquatable<ClassificationSearchResultContractV2>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationSearchResultContractV2" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="namespaceUri">namespaceUri.</param>
        /// <param name="definition">definition.</param>
        /// <param name="synonyms">synonyms.</param>
        public ClassificationSearchResultContractV2(string name = default(string), string namespaceUri = default(string), string definition = default(string), List<string> synonyms = default(List<string>))
        {
            this.Name = name;
            this.NamespaceUri = namespaceUri;
            this.Definition = definition;
            this.Synonyms = synonyms;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets NamespaceUri
        /// </summary>
        [DataMember(Name="namespaceUri", EmitDefaultValue=false)]
        public string NamespaceUri { get; set; }

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [DataMember(Name="definition", EmitDefaultValue=false)]
        public string Definition { get; set; }

        /// <summary>
        /// Gets or Sets Synonyms
        /// </summary>
        [DataMember(Name="synonyms", EmitDefaultValue=false)]
        public List<string> Synonyms { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClassificationSearchResultContractV2 {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NamespaceUri: ").Append(NamespaceUri).Append("\n");
            sb.Append("  Definition: ").Append(Definition).Append("\n");
            sb.Append("  Synonyms: ").Append(Synonyms).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ClassificationSearchResultContractV2);
        }

        /// <summary>
        /// Returns true if ClassificationSearchResultContractV2 instances are equal
        /// </summary>
        /// <param name="input">Instance of ClassificationSearchResultContractV2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ClassificationSearchResultContractV2 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.NamespaceUri == input.NamespaceUri ||
                    (this.NamespaceUri != null &&
                    this.NamespaceUri.Equals(input.NamespaceUri))
                ) && 
                (
                    this.Definition == input.Definition ||
                    (this.Definition != null &&
                    this.Definition.Equals(input.Definition))
                ) && 
                (
                    this.Synonyms == input.Synonyms ||
                    this.Synonyms != null &&
                    input.Synonyms != null &&
                    this.Synonyms.SequenceEqual(input.Synonyms)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.NamespaceUri != null)
                    hashCode = hashCode * 59 + this.NamespaceUri.GetHashCode();
                if (this.Definition != null)
                    hashCode = hashCode * 59 + this.Definition.GetHashCode();
                if (this.Synonyms != null)
                    hashCode = hashCode * 59 + this.Synonyms.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
