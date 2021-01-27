

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
    /// DailyChangeResponse
    /// </summary>
    [DataContract(Name = "DailyChangeResponse")]
    public partial class DailyChangeResponse : IEquatable<DailyChangeResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyChangeResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DailyChangeResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyChangeResponse" /> class.
        /// </summary>
        /// <param name="dailyChange">absolute daily change of the price at the moment of request.</param>
        /// <param name="basePrice">previous session close price, required api 2.0 only.</param>
        /// <param name="symbolId">symbol id (required).</param>
        /// <param name="lastSessionClosePrice">previous session close price, required api 3.0 only.</param>
        public DailyChangeResponse(string dailyChange = default(string), string basePrice = default(string), string symbolId = default(string), string lastSessionClosePrice = default(string))
        {
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for DailyChangeResponse and cannot be null");
            this.DailyChange = dailyChange;
            this.BasePrice = basePrice;
            this.LastSessionClosePrice = lastSessionClosePrice;
        }

        /// <summary>
        /// absolute daily change of the price at the moment of request
        /// </summary>
        /// <value>absolute daily change of the price at the moment of request</value>
        [DataMember(Name = "dailyChange", EmitDefaultValue = false)]
        public string DailyChange { get; set; }

        /// <summary>
        /// previous session close price, required api 2.0 only
        /// </summary>
        /// <value>previous session close price, required api 2.0 only</value>
        [DataMember(Name = "basePrice", EmitDefaultValue = false)]
        public string BasePrice { get; set; }

        /// <summary>
        /// symbol id
        /// </summary>
        /// <value>symbol id</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// previous session close price, required api 3.0 only
        /// </summary>
        /// <value>previous session close price, required api 3.0 only</value>
        [DataMember(Name = "lastSessionClosePrice", EmitDefaultValue = false)]
        public string LastSessionClosePrice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DailyChangeResponse {\n");
            sb.Append("  DailyChange: ").Append(DailyChange).Append("\n");
            sb.Append("  BasePrice: ").Append(BasePrice).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  LastSessionClosePrice: ").Append(LastSessionClosePrice).Append("\n");
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
            return this.Equals(input as DailyChangeResponse);
        }

        /// <summary>
        /// Returns true if DailyChangeResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of DailyChangeResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DailyChangeResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DailyChange == input.DailyChange ||
                    (this.DailyChange != null &&
                    this.DailyChange.Equals(input.DailyChange))
                ) && 
                (
                    this.BasePrice == input.BasePrice ||
                    (this.BasePrice != null &&
                    this.BasePrice.Equals(input.BasePrice))
                ) && 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
                ) && 
                (
                    this.LastSessionClosePrice == input.LastSessionClosePrice ||
                    (this.LastSessionClosePrice != null &&
                    this.LastSessionClosePrice.Equals(input.LastSessionClosePrice))
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
                if (this.DailyChange != null)
                    hashCode = hashCode * 59 + this.DailyChange.GetHashCode();
                if (this.BasePrice != null)
                    hashCode = hashCode * 59 + this.BasePrice.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                if (this.LastSessionClosePrice != null)
                    hashCode = hashCode * 59 + this.LastSessionClosePrice.GetHashCode();
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
