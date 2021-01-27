

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
    /// currencies on position
    /// </summary>
    [DataContract(Name = "CurrencyPositionResponse")]
    public partial class CurrencyPositionResponse : IEquatable<CurrencyPositionResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyPositionResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CurrencyPositionResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyPositionResponse" /> class.
        /// </summary>
        /// <param name="code">currency code (required).</param>
        /// <param name="convertedValue">converted value of position if crossrates are available.</param>
        /// <param name="value">value of position (required).</param>
        public CurrencyPositionResponse(string code = default(string), string convertedValue = default(string), string value = default(string))
        {
            // to ensure "code" is required (not null)
            this.Code = code ?? throw new ArgumentNullException("code is a required property for CurrencyPositionResponse and cannot be null");
            // to ensure "value" is required (not null)
            this.Value = value ?? throw new ArgumentNullException("value is a required property for CurrencyPositionResponse and cannot be null");
            this.ConvertedValue = convertedValue;
        }

        /// <summary>
        /// currency code
        /// </summary>
        /// <value>currency code</value>
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
        public string Code { get; set; }

        /// <summary>
        /// converted value of position if crossrates are available
        /// </summary>
        /// <value>converted value of position if crossrates are available</value>
        [DataMember(Name = "convertedValue", EmitDefaultValue = false)]
        public string ConvertedValue { get; set; }

        /// <summary>
        /// value of position
        /// </summary>
        /// <value>value of position</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CurrencyPositionResponse {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  ConvertedValue: ").Append(ConvertedValue).Append("\n");
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
            return this.Equals(input as CurrencyPositionResponse);
        }

        /// <summary>
        /// Returns true if CurrencyPositionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CurrencyPositionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CurrencyPositionResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.ConvertedValue == input.ConvertedValue ||
                    (this.ConvertedValue != null &&
                    this.ConvertedValue.Equals(input.ConvertedValue))
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
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.ConvertedValue != null)
                    hashCode = hashCode * 59 + this.ConvertedValue.GetHashCode();
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
