

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
    /// QuoteResponse
    /// </summary>
    [DataContract(Name = "QuoteResponse")]
    public partial class QuoteResponse : IEquatable<QuoteResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuoteResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteResponse" /> class.
        /// </summary>
        /// <param name="ask">array of ask levels according to requested feed level (required).</param>
        /// <param name="symbolId">financial instrument id (required).</param>
        /// <param name="timestamp">quote timestamp (required).</param>
        /// <param name="bid">array of bid levels according to requested feed level (required).</param>
        public QuoteResponse(List<QuoteSide> ask = default(List<QuoteSide>), string symbolId = default(string), decimal timestamp = default(decimal), List<QuoteSide> bid = default(List<QuoteSide>))
        {
            // to ensure "ask" is required (not null)
            this.Ask = ask ?? throw new ArgumentNullException("ask is a required property for QuoteResponse and cannot be null");
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for QuoteResponse and cannot be null");
            this.Timestamp = timestamp;
            // to ensure "bid" is required (not null)
            this.Bid = bid ?? throw new ArgumentNullException("bid is a required property for QuoteResponse and cannot be null");
        }

        /// <summary>
        /// array of ask levels according to requested feed level
        /// </summary>
        /// <value>array of ask levels according to requested feed level</value>
        [DataMember(Name = "ask", IsRequired = true, EmitDefaultValue = false)]
        public List<QuoteSide> Ask { get; set; }

        /// <summary>
        /// financial instrument id
        /// </summary>
        /// <value>financial instrument id</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// quote timestamp
        /// </summary>
        /// <value>quote timestamp</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public decimal Timestamp { get; set; }

        /// <summary>
        /// array of bid levels according to requested feed level
        /// </summary>
        /// <value>array of bid levels according to requested feed level</value>
        [DataMember(Name = "bid", IsRequired = true, EmitDefaultValue = false)]
        public List<QuoteSide> Bid { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuoteResponse {\n");
            sb.Append("  Ask: ").Append(Ask).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Bid: ").Append(Bid).Append("\n");
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
            return this.Equals(input as QuoteResponse);
        }

        /// <summary>
        /// Returns true if QuoteResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of QuoteResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuoteResponse input)
        {
            if (input == null)
                return false;

            return 
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
                    this.Timestamp == input.Timestamp ||
                    this.Timestamp.Equals(input.Timestamp)
                ) && 
                (
                    this.Bid == input.Bid ||
                    this.Bid != null &&
                    input.Bid != null &&
                    this.Bid.SequenceEqual(input.Bid)
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
                if (this.Ask != null)
                    hashCode = hashCode * 59 + this.Ask.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Bid != null)
                    hashCode = hashCode * 59 + this.Bid.GetHashCode();
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
