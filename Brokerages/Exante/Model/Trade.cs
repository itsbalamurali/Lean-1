

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
    /// Trade
    /// </summary>
    [DataContract(Name = "Trade")]
    public partial class Trade : IEquatable<Trade>, IValidatableObject
    {
        /// <summary>
        /// event type
        /// </summary>
        /// <value>event type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventEnum
        {
            /// <summary>
            /// Enum Trade for value: trade
            /// </summary>
            [EnumMember(Value = "trade")]
            Trade = 1

        }

        /// <summary>
        /// event type
        /// </summary>
        /// <value>event type</value>
        [DataMember(Name = "event", IsRequired = true, EmitDefaultValue = false)]
        public EventEnum Event { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Trade() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade" /> class.
        /// </summary>
        /// <param name="time">trade timestamp, required api 2.0 only (required).</param>
        /// <param name="price">trade price (required).</param>
        /// <param name="timestamp">trade timestamp, required api 3.0 only (required).</param>
        /// <param name="_event">event type (required).</param>
        /// <param name="quantity">trade quantity (required).</param>
        /// <param name="orderId">respected order ID (required).</param>
        /// <param name="position">order fill serial number for the trade (required).</param>
        public Trade(string time = default(string), string price = default(string), string timestamp = default(string), EventEnum _event = default(EventEnum), string quantity = default(string), Guid orderId = default(Guid), string position = default(string))
        {
            // to ensure "time" is required (not null)
            this.Time = time ?? throw new ArgumentNullException("time is a required property for Trade and cannot be null");
            // to ensure "price" is required (not null)
            this.Price = price ?? throw new ArgumentNullException("price is a required property for Trade and cannot be null");
            // to ensure "timestamp" is required (not null)
            this.Timestamp = timestamp ?? throw new ArgumentNullException("timestamp is a required property for Trade and cannot be null");
            this.Event = _event;
            // to ensure "quantity" is required (not null)
            this.Quantity = quantity ?? throw new ArgumentNullException("quantity is a required property for Trade and cannot be null");
            this.OrderId = orderId;
            // to ensure "position" is required (not null)
            this.Position = position ?? throw new ArgumentNullException("position is a required property for Trade and cannot be null");
        }

        /// <summary>
        /// trade timestamp, required api 2.0 only
        /// </summary>
        /// <value>trade timestamp, required api 2.0 only</value>
        [DataMember(Name = "time", IsRequired = true, EmitDefaultValue = false)]
        public string Time { get; set; }

        /// <summary>
        /// trade price
        /// </summary>
        /// <value>trade price</value>
        [DataMember(Name = "price", IsRequired = true, EmitDefaultValue = false)]
        public string Price { get; set; }

        /// <summary>
        /// trade timestamp, required api 3.0 only
        /// </summary>
        /// <value>trade timestamp, required api 3.0 only</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public string Timestamp { get; set; }

        /// <summary>
        /// trade quantity
        /// </summary>
        /// <value>trade quantity</value>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = false)]
        public string Quantity { get; set; }

        /// <summary>
        /// respected order ID
        /// </summary>
        /// <value>respected order ID</value>
        [DataMember(Name = "orderId", IsRequired = true, EmitDefaultValue = false)]
        public Guid OrderId { get; set; }

        /// <summary>
        /// order fill serial number for the trade
        /// </summary>
        /// <value>order fill serial number for the trade</value>
        [DataMember(Name = "position", IsRequired = true, EmitDefaultValue = false)]
        public string Position { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Trade {\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Event: ").Append(Event).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
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
            return this.Equals(input as Trade);
        }

        /// <summary>
        /// Returns true if Trade instances are equal
        /// </summary>
        /// <param name="input">Instance of Trade to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Trade input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Time == input.Time ||
                    (this.Time != null &&
                    this.Time.Equals(input.Time))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.Event == input.Event ||
                    this.Event.Equals(input.Event)
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.OrderId == input.OrderId ||
                    (this.OrderId != null &&
                    this.OrderId.Equals(input.OrderId))
                ) && 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
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
                if (this.Time != null)
                    hashCode = hashCode * 59 + this.Time.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                hashCode = hashCode * 59 + this.Event.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.OrderId != null)
                    hashCode = hashCode * 59 + this.OrderId.GetHashCode();
                if (this.Position != null)
                    hashCode = hashCode * 59 + this.Position.GetHashCode();
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
