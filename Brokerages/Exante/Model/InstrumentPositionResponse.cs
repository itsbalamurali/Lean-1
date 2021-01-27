

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
    /// open positions
    /// </summary>
    [DataContract(Name = "InstrumentPositionResponse")]
    public partial class InstrumentPositionResponse : IEquatable<InstrumentPositionResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstrumentPositionResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected InstrumentPositionResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="InstrumentPositionResponse" /> class.
        /// </summary>
        /// <param name="convertedPnl">current position PnL in the currency of the report.</param>
        /// <param name="symbolType">financial instrument type (required).</param>
        /// <param name="currency">currency code of the financial instrument (required).</param>
        /// <param name="id">financial instrument identifier, required api 2.0 only (required).</param>
        /// <param name="pnl">current position PnL.</param>
        /// <param name="price">current financial instrument price.</param>
        /// <param name="quantity">quantity on position (required).</param>
        /// <param name="symbolId">financial instrument identifier, required api 3.0 only (required).</param>
        /// <param name="convertedValue">position value in the currency of the report.</param>
        /// <param name="averagePrice">average position opening price.</param>
        /// <param name="value">position value.</param>
        public InstrumentPositionResponse(string convertedPnl = default(string), string symbolType = default(string), string currency = default(string), string id = default(string), string pnl = default(string), string price = default(string), string quantity = default(string), string symbolId = default(string), string convertedValue = default(string), string averagePrice = default(string), string value = default(string))
        {
            // to ensure "symbolType" is required (not null)
            this.SymbolType = symbolType ?? throw new ArgumentNullException("symbolType is a required property for InstrumentPositionResponse and cannot be null");
            // to ensure "currency" is required (not null)
            this.Currency = currency ?? throw new ArgumentNullException("currency is a required property for InstrumentPositionResponse and cannot be null");
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for InstrumentPositionResponse and cannot be null");
            // to ensure "quantity" is required (not null)
            this.Quantity = quantity ?? throw new ArgumentNullException("quantity is a required property for InstrumentPositionResponse and cannot be null");
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for InstrumentPositionResponse and cannot be null");
            this.ConvertedPnl = convertedPnl;
            this.Pnl = pnl;
            this.Price = price;
            this.ConvertedValue = convertedValue;
            this.AveragePrice = averagePrice;
            this.Value = value;
        }

        /// <summary>
        /// current position PnL in the currency of the report
        /// </summary>
        /// <value>current position PnL in the currency of the report</value>
        [DataMember(Name = "convertedPnl", EmitDefaultValue = false)]
        public string ConvertedPnl { get; set; }

        /// <summary>
        /// financial instrument type
        /// </summary>
        /// <value>financial instrument type</value>
        [DataMember(Name = "symbolType", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolType { get; set; }

        /// <summary>
        /// currency code of the financial instrument
        /// </summary>
        /// <value>currency code of the financial instrument</value>
        [DataMember(Name = "currency", IsRequired = true, EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// financial instrument identifier, required api 2.0 only
        /// </summary>
        /// <value>financial instrument identifier, required api 2.0 only</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// current position PnL
        /// </summary>
        /// <value>current position PnL</value>
        [DataMember(Name = "pnl", EmitDefaultValue = false)]
        public string Pnl { get; set; }

        /// <summary>
        /// current financial instrument price
        /// </summary>
        /// <value>current financial instrument price</value>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public string Price { get; set; }

        /// <summary>
        /// quantity on position
        /// </summary>
        /// <value>quantity on position</value>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = false)]
        public string Quantity { get; set; }

        /// <summary>
        /// financial instrument identifier, required api 3.0 only
        /// </summary>
        /// <value>financial instrument identifier, required api 3.0 only</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// position value in the currency of the report
        /// </summary>
        /// <value>position value in the currency of the report</value>
        [DataMember(Name = "convertedValue", EmitDefaultValue = false)]
        public string ConvertedValue { get; set; }

        /// <summary>
        /// average position opening price
        /// </summary>
        /// <value>average position opening price</value>
        [DataMember(Name = "averagePrice", EmitDefaultValue = false)]
        public string AveragePrice { get; set; }

        /// <summary>
        /// position value
        /// </summary>
        /// <value>position value</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InstrumentPositionResponse {\n");
            sb.Append("  ConvertedPnl: ").Append(ConvertedPnl).Append("\n");
            sb.Append("  SymbolType: ").Append(SymbolType).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Pnl: ").Append(Pnl).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  ConvertedValue: ").Append(ConvertedValue).Append("\n");
            sb.Append("  AveragePrice: ").Append(AveragePrice).Append("\n");
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
            return this.Equals(input as InstrumentPositionResponse);
        }

        /// <summary>
        /// Returns true if InstrumentPositionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of InstrumentPositionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InstrumentPositionResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ConvertedPnl == input.ConvertedPnl ||
                    (this.ConvertedPnl != null &&
                    this.ConvertedPnl.Equals(input.ConvertedPnl))
                ) && 
                (
                    this.SymbolType == input.SymbolType ||
                    (this.SymbolType != null &&
                    this.SymbolType.Equals(input.SymbolType))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Pnl == input.Pnl ||
                    (this.Pnl != null &&
                    this.Pnl.Equals(input.Pnl))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
                ) && 
                (
                    this.ConvertedValue == input.ConvertedValue ||
                    (this.ConvertedValue != null &&
                    this.ConvertedValue.Equals(input.ConvertedValue))
                ) && 
                (
                    this.AveragePrice == input.AveragePrice ||
                    (this.AveragePrice != null &&
                    this.AveragePrice.Equals(input.AveragePrice))
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
                if (this.ConvertedPnl != null)
                    hashCode = hashCode * 59 + this.ConvertedPnl.GetHashCode();
                if (this.SymbolType != null)
                    hashCode = hashCode * 59 + this.SymbolType.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Pnl != null)
                    hashCode = hashCode * 59 + this.Pnl.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                if (this.ConvertedValue != null)
                    hashCode = hashCode * 59 + this.ConvertedValue.GetHashCode();
                if (this.AveragePrice != null)
                    hashCode = hashCode * 59 + this.AveragePrice.GetHashCode();
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
