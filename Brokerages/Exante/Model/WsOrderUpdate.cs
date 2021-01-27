

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
    /// WsOrderUpdate
    /// </summary>
    [DataContract(Name = "WsOrderUpdate")]
    public partial class WsOrderUpdate : IEquatable<WsOrderUpdate>, IValidatableObject
    {
        /// <summary>
        /// event type
        /// </summary>
        /// <value>event type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventEnum
        {
            /// <summary>
            /// Enum Order for value: order
            /// </summary>
            [EnumMember(Value = "order")]
            Order = 1

        }

        /// <summary>
        /// event type
        /// </summary>
        /// <value>event type</value>
        [DataMember(Name = "event", IsRequired = true, EmitDefaultValue = false)]
        public EventEnum Event { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WsOrderUpdate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WsOrderUpdate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WsOrderUpdate" /> class.
        /// </summary>
        /// <param name="_event">event type (required).</param>
        /// <param name="sequenceNumber">sequence number (required).</param>
        /// <param name="order">order (required).</param>
        public WsOrderUpdate(EventEnum _event = default(EventEnum), long sequenceNumber = default(long), ApiOrder order = default(ApiOrder))
        {
            this.Event = _event;
            this.SequenceNumber = sequenceNumber;
            // to ensure "order" is required (not null)
            this.Order = order ?? throw new ArgumentNullException("order is a required property for WsOrderUpdate and cannot be null");
        }

        /// <summary>
        /// sequence number
        /// </summary>
        /// <value>sequence number</value>
        [DataMember(Name = "sequence_number", IsRequired = true, EmitDefaultValue = false)]
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [DataMember(Name = "order", IsRequired = true, EmitDefaultValue = false)]
        public ApiOrder Order { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WsOrderUpdate {\n");
            sb.Append("  Event: ").Append(Event).Append("\n");
            sb.Append("  SequenceNumber: ").Append(SequenceNumber).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
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
            return this.Equals(input as WsOrderUpdate);
        }

        /// <summary>
        /// Returns true if WsOrderUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of WsOrderUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WsOrderUpdate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Event == input.Event ||
                    this.Event.Equals(input.Event)
                ) && 
                (
                    this.SequenceNumber == input.SequenceNumber ||
                    this.SequenceNumber.Equals(input.SequenceNumber)
                ) && 
                (
                    this.Order == input.Order ||
                    (this.Order != null &&
                    this.Order.Equals(input.Order))
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
                hashCode = hashCode * 59 + this.Event.GetHashCode();
                hashCode = hashCode * 59 + this.SequenceNumber.GetHashCode();
                if (this.Order != null)
                    hashCode = hashCode * 59 + this.Order.GetHashCode();
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
