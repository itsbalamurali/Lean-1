

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = OpenAPIDateConverter;

namespace QuantConnect.Brokerages.Exante.Model
{
    /// <summary>
    /// array of ask levels according to requested feed level
    /// </summary>
    [DataContract(Name = "QuoteSide")]
    public partial class QuoteSide : IEquatable<QuoteSide>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteSide" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuoteSide() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteSide" /> class.
        /// </summary>
        /// <param name="price">quote value of this level, required api 3.0 only (required).</param>
        /// <param name="size">quantity value of this level (required).</param>
        /// <param name="value">quote value of this level, required api 2.0 only (required).</param>
        public QuoteSide(string price = default(string), string size = default(string), string value = default(string))
        {
            // to ensure "price" is required (not null)
            this.Price = price ?? throw new ArgumentNullException("price is a required property for QuoteSide and cannot be null");
            // to ensure "size" is required (not null)
            this.Size = size ?? throw new ArgumentNullException("size is a required property for QuoteSide and cannot be null");
            // to ensure "value" is required (not null)
            this.Value = value ?? throw new ArgumentNullException("value is a required property for QuoteSide and cannot be null");
        }

        /// <summary>
        /// quote value of this level, required api 3.0 only
        /// </summary>
        /// <value>quote value of this level, required api 3.0 only</value>
        [DataMember(Name = "price", IsRequired = true, EmitDefaultValue = false)]
        public string Price { get; set; }

        /// <summary>
        /// quantity value of this level
        /// </summary>
        /// <value>quantity value of this level</value>
        [DataMember(Name = "size", IsRequired = true, EmitDefaultValue = false)]
        public string Size { get; set; }

        /// <summary>
        /// quote value of this level, required api 2.0 only
        /// </summary>
        /// <value>quote value of this level, required api 2.0 only</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuoteSide {\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as QuoteSide);
        }

        /// <summary>
        /// Returns true if QuoteSide instances are equal
        /// </summary>
        /// <param name="input">Instance of QuoteSide to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuoteSide input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Size == input.Size ||
                    (this.Size != null &&
                    this.Size.Equals(input.Size))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Size != null)
                    hashCode = hashCode * 59 + this.Size.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
