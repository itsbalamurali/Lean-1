

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
    /// AvailableOrderDurationTypes
    /// </summary>
    [DataContract(Name = "AvailableOrderDurationTypes")]
    public partial class AvailableOrderDurationTypes : IEquatable<AvailableOrderDurationTypes>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableOrderDurationTypes" /> class.
        /// </summary>
        /// <param name="stop">stop.</param>
        /// <param name="limit">limit.</param>
        /// <param name="pegged">pegged.</param>
        /// <param name="market">market.</param>
        /// <param name="stopLimit">stopLimit.</param>
        public AvailableOrderDurationTypes(List<Value> stop = default(List<Value>), List<Value> limit = default(List<Value>), List<Value> pegged = default(List<Value>), List<Value> market = default(List<Value>), List<Value> stopLimit = default(List<Value>))
        {
            this.Stop = stop;
            this.Limit = limit;
            this.Pegged = pegged;
            this.Market = market;
            this.StopLimit = stopLimit;
        }

        /// <summary>
        /// Gets or Sets Stop
        /// </summary>
        [DataMember(Name = "stop", EmitDefaultValue = false)]
        public List<Value> Stop { get; set; }

        /// <summary>
        /// Gets or Sets Limit
        /// </summary>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public List<Value> Limit { get; set; }

        /// <summary>
        /// Gets or Sets Pegged
        /// </summary>
        [DataMember(Name = "pegged", EmitDefaultValue = false)]
        public List<Value> Pegged { get; set; }

        /// <summary>
        /// Gets or Sets Market
        /// </summary>
        [DataMember(Name = "market", EmitDefaultValue = false)]
        public List<Value> Market { get; set; }

        /// <summary>
        /// Gets or Sets StopLimit
        /// </summary>
        [DataMember(Name = "stop_limit", EmitDefaultValue = false)]
        public List<Value> StopLimit { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AvailableOrderDurationTypes {\n");
            sb.Append("  Stop: ").Append(Stop).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Pegged: ").Append(Pegged).Append("\n");
            sb.Append("  Market: ").Append(Market).Append("\n");
            sb.Append("  StopLimit: ").Append(StopLimit).Append("\n");
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
            return this.Equals(input as AvailableOrderDurationTypes);
        }

        /// <summary>
        /// Returns true if AvailableOrderDurationTypes instances are equal
        /// </summary>
        /// <param name="input">Instance of AvailableOrderDurationTypes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AvailableOrderDurationTypes input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Stop == input.Stop ||
                    this.Stop != null &&
                    input.Stop != null &&
                    this.Stop.SequenceEqual(input.Stop)
                ) && 
                (
                    this.Limit == input.Limit ||
                    this.Limit != null &&
                    input.Limit != null &&
                    this.Limit.SequenceEqual(input.Limit)
                ) && 
                (
                    this.Pegged == input.Pegged ||
                    this.Pegged != null &&
                    input.Pegged != null &&
                    this.Pegged.SequenceEqual(input.Pegged)
                ) && 
                (
                    this.Market == input.Market ||
                    this.Market != null &&
                    input.Market != null &&
                    this.Market.SequenceEqual(input.Market)
                ) && 
                (
                    this.StopLimit == input.StopLimit ||
                    this.StopLimit != null &&
                    input.StopLimit != null &&
                    this.StopLimit.SequenceEqual(input.StopLimit)
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
                if (this.Stop != null)
                    hashCode = hashCode * 59 + this.Stop.GetHashCode();
                if (this.Limit != null)
                    hashCode = hashCode * 59 + this.Limit.GetHashCode();
                if (this.Pegged != null)
                    hashCode = hashCode * 59 + this.Pegged.GetHashCode();
                if (this.Market != null)
                    hashCode = hashCode * 59 + this.Market.GetHashCode();
                if (this.StopLimit != null)
                    hashCode = hashCode * 59 + this.StopLimit.GetHashCode();
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
