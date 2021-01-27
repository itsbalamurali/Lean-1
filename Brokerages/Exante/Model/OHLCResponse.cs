

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
    /// OHLCResponse
    /// </summary>
    [DataContract(Name = "OHLCResponse")]
    public partial class OHLCResponse : IEquatable<OHLCResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OHLCResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OHLCResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OHLCResponse" /> class.
        /// </summary>
        /// <param name="close">candle close price (required).</param>
        /// <param name="timestamp">candle timestamp (required).</param>
        /// <param name="open">candle open price (required).</param>
        /// <param name="low">candle low price (required).</param>
        /// <param name="high">candle high price (required).</param>
        /// <param name="volume">total volume for specified period. Appears and required only for trade candle request (required).</param>
        public OHLCResponse(string close = default(string), decimal timestamp = default(decimal), string open = default(string), string low = default(string), string high = default(string), string volume = default(string))
        {
            // to ensure "close" is required (not null)
            this.Close = close ?? throw new ArgumentNullException("close is a required property for OHLCResponse and cannot be null");
            this.Timestamp = timestamp;
            // to ensure "open" is required (not null)
            this.Open = open ?? throw new ArgumentNullException("open is a required property for OHLCResponse and cannot be null");
            // to ensure "low" is required (not null)
            this.Low = low ?? throw new ArgumentNullException("low is a required property for OHLCResponse and cannot be null");
            // to ensure "high" is required (not null)
            this.High = high ?? throw new ArgumentNullException("high is a required property for OHLCResponse and cannot be null");
            // to ensure "volume" is required (not null)
            this.Volume = volume ?? throw new ArgumentNullException("volume is a required property for OHLCResponse and cannot be null");
        }

        /// <summary>
        /// candle close price
        /// </summary>
        /// <value>candle close price</value>
        [DataMember(Name = "close", IsRequired = true, EmitDefaultValue = false)]
        public string Close { get; set; }

        /// <summary>
        /// candle timestamp
        /// </summary>
        /// <value>candle timestamp</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public decimal Timestamp { get; set; }

        /// <summary>
        /// candle open price
        /// </summary>
        /// <value>candle open price</value>
        [DataMember(Name = "open", IsRequired = true, EmitDefaultValue = false)]
        public string Open { get; set; }

        /// <summary>
        /// candle low price
        /// </summary>
        /// <value>candle low price</value>
        [DataMember(Name = "low", IsRequired = true, EmitDefaultValue = false)]
        public string Low { get; set; }

        /// <summary>
        /// candle high price
        /// </summary>
        /// <value>candle high price</value>
        [DataMember(Name = "high", IsRequired = true, EmitDefaultValue = false)]
        public string High { get; set; }

        /// <summary>
        /// total volume for specified period. Appears and required only for trade candle request
        /// </summary>
        /// <value>total volume for specified period. Appears and required only for trade candle request</value>
        [DataMember(Name = "volume", IsRequired = true, EmitDefaultValue = false)]
        public string Volume { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OHLCResponse {\n");
            sb.Append("  Close: ").Append(Close).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Open: ").Append(Open).Append("\n");
            sb.Append("  Low: ").Append(Low).Append("\n");
            sb.Append("  High: ").Append(High).Append("\n");
            sb.Append("  Volume: ").Append(Volume).Append("\n");
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
            return this.Equals(input as OHLCResponse);
        }

        /// <summary>
        /// Returns true if OHLCResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of OHLCResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OHLCResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Close == input.Close ||
                    (this.Close != null &&
                    this.Close.Equals(input.Close))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    this.Timestamp.Equals(input.Timestamp)
                ) && 
                (
                    this.Open == input.Open ||
                    (this.Open != null &&
                    this.Open.Equals(input.Open))
                ) && 
                (
                    this.Low == input.Low ||
                    (this.Low != null &&
                    this.Low.Equals(input.Low))
                ) && 
                (
                    this.High == input.High ||
                    (this.High != null &&
                    this.High.Equals(input.High))
                ) && 
                (
                    this.Volume == input.Volume ||
                    (this.Volume != null &&
                    this.Volume.Equals(input.Volume))
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
                if (this.Close != null)
                    hashCode = hashCode * 59 + this.Close.GetHashCode();
                hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Open != null)
                    hashCode = hashCode * 59 + this.Open.GetHashCode();
                if (this.Low != null)
                    hashCode = hashCode * 59 + this.Low.GetHashCode();
                if (this.High != null)
                    hashCode = hashCode * 59 + this.High.GetHashCode();
                if (this.Volume != null)
                    hashCode = hashCode * 59 + this.Volume.GetHashCode();
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
