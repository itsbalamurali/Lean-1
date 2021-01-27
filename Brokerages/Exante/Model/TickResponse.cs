

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
    /// TickResponse
    /// </summary>
    [DataContract(Name = "TickResponse")]
    public partial class TickResponse : IEquatable<TickResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TickResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TickResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TickResponse" /> class.
        /// </summary>
        /// <param name="price">trade price. Appears and required only for trade request, required api 3.0 only.</param>
        /// <param name="timestamp">tick timestamp (required).</param>
        /// <param name="bid">tick bid. Appears and required only for quote request.</param>
        /// <param name="ask">tick ask. Appears and required only for quote request.</param>
        /// <param name="symbolId">financial instrument id (required).</param>
        /// <param name="size">trade size. Appears and required only for trade request.</param>
        /// <param name="value">trade price. Appears and required only for trade request, required api 2.0 only.</param>
        public TickResponse(string price = default(string), decimal timestamp = default(decimal), List<QuoteSide> bid = default(List<QuoteSide>), List<QuoteSide> ask = default(List<QuoteSide>), string symbolId = default(string), string size = default(string), string value = default(string))
        {
            this.Timestamp = timestamp;
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for TickResponse and cannot be null");
            this.Price = price;
            this.Bid = bid;
            this.Ask = ask;
            this.Size = size;
            this.Value = value;
        }

        /// <summary>
        /// trade price. Appears and required only for trade request, required api 3.0 only
        /// </summary>
        /// <value>trade price. Appears and required only for trade request, required api 3.0 only</value>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public string Price { get; set; }

        /// <summary>
        /// tick timestamp
        /// </summary>
        /// <value>tick timestamp</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public decimal Timestamp { get; set; }

        /// <summary>
        /// tick bid. Appears and required only for quote request
        /// </summary>
        /// <value>tick bid. Appears and required only for quote request</value>
        [DataMember(Name = "bid", EmitDefaultValue = false)]
        public List<QuoteSide> Bid { get; set; }

        /// <summary>
        /// tick ask. Appears and required only for quote request
        /// </summary>
        /// <value>tick ask. Appears and required only for quote request</value>
        [DataMember(Name = "ask", EmitDefaultValue = false)]
        public List<QuoteSide> Ask { get; set; }

        /// <summary>
        /// financial instrument id
        /// </summary>
        /// <value>financial instrument id</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// trade size. Appears and required only for trade request
        /// </summary>
        /// <value>trade size. Appears and required only for trade request</value>
        [DataMember(Name = "size", EmitDefaultValue = false)]
        public string Size { get; set; }

        /// <summary>
        /// trade price. Appears and required only for trade request, required api 2.0 only
        /// </summary>
        /// <value>trade price. Appears and required only for trade request, required api 2.0 only</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TickResponse {\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Bid: ").Append(Bid).Append("\n");
            sb.Append("  Ask: ").Append(Ask).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
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
            return this.Equals(input as TickResponse);
        }

        /// <summary>
        /// Returns true if TickResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TickResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TickResponse input)
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
                    this.Timestamp == input.Timestamp ||
                    this.Timestamp.Equals(input.Timestamp)
                ) && 
                (
                    this.Bid == input.Bid ||
                    this.Bid != null &&
                    input.Bid != null &&
                    this.Bid.SequenceEqual(input.Bid)
                ) && 
                (
                    this.Ask == input.Ask ||
                    this.Ask != null &&
                    input.Ask != null &&
                    this.Ask.SequenceEqual(input.Ask)
                ) && 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
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
                hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Bid != null)
                    hashCode = hashCode * 59 + this.Bid.GetHashCode();
                if (this.Ask != null)
                    hashCode = hashCode * 59 + this.Ask.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
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
