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
    /// PropertyRelationContractV2
    /// </summary>
    [DataContract]
        public partial class PropertyRelationContractV2 :  IEquatable<PropertyRelationContractV2>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyRelationContractV2" /> class.
        /// </summary>
        /// <param name="relationType">The relation with the other property: e.g. HasReference, IsEqualTo.</param>
        /// <param name="relatedPropertyUri">Namespace URI of the related property.</param>
        /// <param name="relatedPropertyName">Name of the related property.</param>
        public PropertyRelationContractV2(string relationType = default(string), string relatedPropertyUri = default(string), string relatedPropertyName = default(string))
        {
            this.RelationType = relationType;
            this.RelatedPropertyUri = relatedPropertyUri;
            this.RelatedPropertyName = relatedPropertyName;
        }
        
        /// <summary>
        /// The relation with the other property: e.g. HasReference, IsEqualTo
        /// </summary>
        /// <value>The relation with the other property: e.g. HasReference, IsEqualTo</value>
        [DataMember(Name="relationType", EmitDefaultValue=false)]
        public string RelationType { get; set; }

        /// <summary>
        /// Namespace URI of the related property
        /// </summary>
        /// <value>Namespace URI of the related property</value>
        [DataMember(Name="relatedPropertyUri", EmitDefaultValue=false)]
        public string RelatedPropertyUri { get; set; }

        /// <summary>
        /// Name of the related property
        /// </summary>
        /// <value>Name of the related property</value>
        [DataMember(Name="relatedPropertyName", EmitDefaultValue=false)]
        public string RelatedPropertyName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PropertyRelationContractV2 {\n");
            sb.Append("  RelationType: ").Append(RelationType).Append("\n");
            sb.Append("  RelatedPropertyUri: ").Append(RelatedPropertyUri).Append("\n");
            sb.Append("  RelatedPropertyName: ").Append(RelatedPropertyName).Append("\n");
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
            return this.Equals(input as PropertyRelationContractV2);
        }

        /// <summary>
        /// Returns true if PropertyRelationContractV2 instances are equal
        /// </summary>
        /// <param name="input">Instance of PropertyRelationContractV2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PropertyRelationContractV2 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RelationType == input.RelationType ||
                    (this.RelationType != null &&
                    this.RelationType.Equals(input.RelationType))
                ) && 
                (
                    this.RelatedPropertyUri == input.RelatedPropertyUri ||
                    (this.RelatedPropertyUri != null &&
                    this.RelatedPropertyUri.Equals(input.RelatedPropertyUri))
                ) && 
                (
                    this.RelatedPropertyName == input.RelatedPropertyName ||
                    (this.RelatedPropertyName != null &&
                    this.RelatedPropertyName.Equals(input.RelatedPropertyName))
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
                if (this.RelationType != null)
                    hashCode = hashCode * 59 + this.RelationType.GetHashCode();
                if (this.RelatedPropertyUri != null)
                    hashCode = hashCode * 59 + this.RelatedPropertyUri.GetHashCode();
                if (this.RelatedPropertyName != null)
                    hashCode = hashCode * 59 + this.RelatedPropertyName.GetHashCode();
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
