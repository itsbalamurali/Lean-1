

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
    /// Heartbeat
    /// </summary>
    [DataContract(Name = "Heartbeat")]
    public partial class Heartbeat : IEquatable<Heartbeat>, IValidatableObject
    {
        /// <summary>
        /// event type
        /// </summary>
        /// <value>event type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventEnum
        {
            /// <summary>
            /// Enum Heartbeat for value: heartbeat
            /// </summary>
            [EnumMember(Value = "heartbeat")]
            Heartbeat = 1

        }

        /// <summary>
        /// event type
        /// </summary>
        /// <value>event type</value>
        [DataMember(Name = "event", IsRequired = true, EmitDefaultValue = false)]
        public EventEnum Event { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Heartbeat" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Heartbeat() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Heartbeat" /> class.
        /// </summary>
        /// <param name="_event">event type (required).</param>
        public Heartbeat(EventEnum _event = default(EventEnum))
        {
            this.Event = _event;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Heartbeat {\n");
            sb.Append("  Event: ").Append(Event).Append("\n");
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
            return this.Equals(input as Heartbeat);
        }

        /// <summary>
        /// Returns true if Heartbeat instances are equal
        /// </summary>
        /// <param name="input">Instance of Heartbeat to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Heartbeat input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Event == input.Event ||
                    this.Event.Equals(input.Event)
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
