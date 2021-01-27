

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
    /// CrossrateCurrencies
    /// </summary>
    [DataContract(Name = "CrossrateCurrencies")]
    public partial class CrossrateCurrencies : IEquatable<CrossrateCurrencies>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossrateCurrencies" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CrossrateCurrencies() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossrateCurrencies" /> class.
        /// </summary>
        /// <param name="currencies">list of available currencies (required).</param>
        public CrossrateCurrencies(List<string> currencies = default(List<string>))
        {
            // to ensure "currencies" is required (not null)
            this.Currencies = currencies ?? throw new ArgumentNullException("currencies is a required property for CrossrateCurrencies and cannot be null");
        }

        /// <summary>
        /// list of available currencies
        /// </summary>
        /// <value>list of available currencies</value>
        [DataMember(Name = "currencies", IsRequired = true, EmitDefaultValue = false)]
        public List<string> Currencies { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrossrateCurrencies {\n");
            sb.Append("  Currencies: ").Append(Currencies).Append("\n");
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
            return this.Equals(input as CrossrateCurrencies);
        }

        /// <summary>
        /// Returns true if CrossrateCurrencies instances are equal
        /// </summary>
        /// <param name="input">Instance of CrossrateCurrencies to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrossrateCurrencies input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Currencies == input.Currencies ||
                    this.Currencies != null &&
                    input.Currencies != null &&
                    this.Currencies.SequenceEqual(input.Currencies)
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
                if (this.Currencies != null)
                    hashCode = hashCode * 59 + this.Currencies.GetHashCode();
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
