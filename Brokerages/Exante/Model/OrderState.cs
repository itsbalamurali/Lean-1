

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
    /// order state response
    /// </summary>
    [DataContract(Name = "OrderState")]
    public partial class OrderState : IEquatable<OrderState>, IValidatableObject
    {
        /// <summary>
        /// current order status
        /// </summary>
        /// <value>current order status</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Placing for value: placing
            /// </summary>
            [EnumMember(Value = "placing")]
            Placing = 1,

            /// <summary>
            /// Enum Working for value: working
            /// </summary>
            [EnumMember(Value = "working")]
            Working = 2,

            /// <summary>
            /// Enum Cancelled for value: cancelled
            /// </summary>
            [EnumMember(Value = "cancelled")]
            Cancelled = 3,

            /// <summary>
            /// Enum Pending for value: pending
            /// </summary>
            [EnumMember(Value = "pending")]
            Pending = 4,

            /// <summary>
            /// Enum Filled for value: filled
            /// </summary>
            [EnumMember(Value = "filled")]
            Filled = 5,

            /// <summary>
            /// Enum Rejected for value: rejected
            /// </summary>
            [EnumMember(Value = "rejected")]
            Rejected = 6

        }

        /// <summary>
        /// current order status
        /// </summary>
        /// <value>current order status</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderState" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OrderState() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderState" /> class.
        /// </summary>
        /// <param name="lastUpdate">order last update time (required).</param>
        /// <param name="status">current order status (required).</param>
        /// <param name="reason">order rejected reason if applicable.</param>
        /// <param name="fills">array of order fills (required).</param>
        public OrderState(DateTime lastUpdate = default(DateTime), StatusEnum status = default(StatusEnum), string reason = default(string), List<OrderFill> fills = default(List<OrderFill>))
        {
            this.LastUpdate = lastUpdate;
            this.Status = status;
            // to ensure "fills" is required (not null)
            this.Fills = fills ?? throw new ArgumentNullException("fills is a required property for OrderState and cannot be null");
            this.Reason = reason;
        }

        /// <summary>
        /// order last update time
        /// </summary>
        /// <value>order last update time</value>
        [DataMember(Name = "lastUpdate", IsRequired = true, EmitDefaultValue = false)]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// order rejected reason if applicable
        /// </summary>
        /// <value>order rejected reason if applicable</value>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        /// <summary>
        /// array of order fills
        /// </summary>
        /// <value>array of order fills</value>
        [DataMember(Name = "fills", IsRequired = true, EmitDefaultValue = false)]
        public List<OrderFill> Fills { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderState {\n");
            sb.Append("  LastUpdate: ").Append(LastUpdate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Fills: ").Append(Fills).Append("\n");
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
            return this.Equals(input as OrderState);
        }

        /// <summary>
        /// Returns true if OrderState instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderState to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderState input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LastUpdate == input.LastUpdate ||
                    (this.LastUpdate != null &&
                    this.LastUpdate.Equals(input.LastUpdate))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Reason == input.Reason ||
                    (this.Reason != null &&
                    this.Reason.Equals(input.Reason))
                ) && 
                (
                    this.Fills == input.Fills ||
                    this.Fills != null &&
                    input.Fills != null &&
                    this.Fills.SequenceEqual(input.Fills)
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
                if (this.LastUpdate != null)
                    hashCode = hashCode * 59 + this.LastUpdate.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Reason != null)
                    hashCode = hashCode * 59 + this.Reason.GetHashCode();
                if (this.Fills != null)
                    hashCode = hashCode * 59 + this.Fills.GetHashCode();
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
