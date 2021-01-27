

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
    /// option specific properties
    /// </summary>
    [DataContract(Name = "OptionDataResponse")]
    public partial class OptionDataResponse : IEquatable<OptionDataResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionDataResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OptionDataResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionDataResponse" /> class.
        /// </summary>
        /// <param name="optionGroupId">option group name (required).</param>
        /// <param name="right">option right, required api 2.0 only (required).</param>
        /// <param name="strikePrice">option strike price (required).</param>
        /// <param name="optionRight">option right, required api 3.0 only (required).</param>
        public OptionDataResponse(string optionGroupId = default(string), string right = default(string), string strikePrice = default(string), string optionRight = default(string))
        {
            // to ensure "optionGroupId" is required (not null)
            this.OptionGroupId = optionGroupId ?? throw new ArgumentNullException("optionGroupId is a required property for OptionDataResponse and cannot be null");
            // to ensure "right" is required (not null)
            this.Right = right ?? throw new ArgumentNullException("right is a required property for OptionDataResponse and cannot be null");
            // to ensure "strikePrice" is required (not null)
            this.StrikePrice = strikePrice ?? throw new ArgumentNullException("strikePrice is a required property for OptionDataResponse and cannot be null");
            // to ensure "optionRight" is required (not null)
            this.OptionRight = optionRight ?? throw new ArgumentNullException("optionRight is a required property for OptionDataResponse and cannot be null");
        }

        /// <summary>
        /// option group name
        /// </summary>
        /// <value>option group name</value>
        [DataMember(Name = "optionGroupId", IsRequired = true, EmitDefaultValue = false)]
        public string OptionGroupId { get; set; }

        /// <summary>
        /// option right, required api 2.0 only
        /// </summary>
        /// <value>option right, required api 2.0 only</value>
        [DataMember(Name = "right", IsRequired = true, EmitDefaultValue = false)]
        public string Right { get; set; }

        /// <summary>
        /// option strike price
        /// </summary>
        /// <value>option strike price</value>
        [DataMember(Name = "strikePrice", IsRequired = true, EmitDefaultValue = false)]
        public string StrikePrice { get; set; }

        /// <summary>
        /// option right, required api 3.0 only
        /// </summary>
        /// <value>option right, required api 3.0 only</value>
        [DataMember(Name = "optionRight", IsRequired = true, EmitDefaultValue = false)]
        public string OptionRight { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OptionDataResponse {\n");
            sb.Append("  OptionGroupId: ").Append(OptionGroupId).Append("\n");
            sb.Append("  Right: ").Append(Right).Append("\n");
            sb.Append("  StrikePrice: ").Append(StrikePrice).Append("\n");
            sb.Append("  OptionRight: ").Append(OptionRight).Append("\n");
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
            return this.Equals(input as OptionDataResponse);
        }

        /// <summary>
        /// Returns true if OptionDataResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of OptionDataResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OptionDataResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OptionGroupId == input.OptionGroupId ||
                    (this.OptionGroupId != null &&
                    this.OptionGroupId.Equals(input.OptionGroupId))
                ) && 
                (
                    this.Right == input.Right ||
                    (this.Right != null &&
                    this.Right.Equals(input.Right))
                ) && 
                (
                    this.StrikePrice == input.StrikePrice ||
                    (this.StrikePrice != null &&
                    this.StrikePrice.Equals(input.StrikePrice))
                ) && 
                (
                    this.OptionRight == input.OptionRight ||
                    (this.OptionRight != null &&
                    this.OptionRight.Equals(input.OptionRight))
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
                if (this.OptionGroupId != null)
                    hashCode = hashCode * 59 + this.OptionGroupId.GetHashCode();
                if (this.Right != null)
                    hashCode = hashCode * 59 + this.Right.GetHashCode();
                if (this.StrikePrice != null)
                    hashCode = hashCode * 59 + this.StrikePrice.GetHashCode();
                if (this.OptionRight != null)
                    hashCode = hashCode * 59 + this.OptionRight.GetHashCode();
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
