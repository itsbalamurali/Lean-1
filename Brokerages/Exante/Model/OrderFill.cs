

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
    /// fill description
    /// </summary>
    [DataContract(Name = "OrderFill")]
    public partial class OrderFill : IEquatable<OrderFill>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFill" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OrderFill() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFill" /> class.
        /// </summary>
        /// <param name="time">fill time, required api 2.0 only (required).</param>
        /// <param name="quantity">fill quantity (required).</param>
        /// <param name="position">fill serial number (required).</param>
        /// <param name="timestamp">fill time, required api 3.0 only (required).</param>
        /// <param name="price">fill price (required).</param>
        public OrderFill(DateTime time = default(DateTime), string quantity = default(string), string position = default(string), DateTime timestamp = default(DateTime), string price = default(string))
        {
            this.Time = time;
            // to ensure "quantity" is required (not null)
            this.Quantity = quantity ?? throw new ArgumentNullException("quantity is a required property for OrderFill and cannot be null");
            // to ensure "position" is required (not null)
            this.Position = position ?? throw new ArgumentNullException("position is a required property for OrderFill and cannot be null");
            this.Timestamp = timestamp;
            // to ensure "price" is required (not null)
            this.Price = price ?? throw new ArgumentNullException("price is a required property for OrderFill and cannot be null");
        }

        /// <summary>
        /// fill time, required api 2.0 only
        /// </summary>
        /// <value>fill time, required api 2.0 only</value>
        [DataMember(Name = "time", IsRequired = true, EmitDefaultValue = false)]
        public DateTime Time { get; set; }

        /// <summary>
        /// fill quantity
        /// </summary>
        /// <value>fill quantity</value>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = false)]
        public string Quantity { get; set; }

        /// <summary>
        /// fill serial number
        /// </summary>
        /// <value>fill serial number</value>
        [DataMember(Name = "position", IsRequired = true, EmitDefaultValue = false)]
        public string Position { get; set; }

        /// <summary>
        /// fill time, required api 3.0 only
        /// </summary>
        /// <value>fill time, required api 3.0 only</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// fill price
        /// </summary>
        /// <value>fill price</value>
        [DataMember(Name = "price", IsRequired = true, EmitDefaultValue = false)]
        public string Price { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderFill {\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
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
            return this.Equals(input as OrderFill);
        }

        /// <summary>
        /// Returns true if OrderFill instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderFill to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderFill input)
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
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.Position == input.Position ||
                    (this.Position != null &&
                    this.Position.Equals(input.Position))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
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
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.Position != null)
                    hashCode = hashCode * 59 + this.Position.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
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
