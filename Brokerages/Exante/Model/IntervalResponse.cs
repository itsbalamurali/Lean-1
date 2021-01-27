

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
    /// trading session period
    /// </summary>
    [DataContract(Name = "IntervalResponse")]
    public partial class IntervalResponse : IEquatable<IntervalResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IntervalResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IntervalResponse" /> class.
        /// </summary>
        /// <param name="end">session end timestamp in ms (required).</param>
        /// <param name="start">session start timestamp in ms (required).</param>
        public IntervalResponse(decimal end = default(decimal), decimal start = default(decimal))
        {
            this.End = end;
            this.Start = start;
        }

        /// <summary>
        /// session end timestamp in ms
        /// </summary>
        /// <value>session end timestamp in ms</value>
        [DataMember(Name = "end", IsRequired = true, EmitDefaultValue = false)]
        public decimal End { get; set; }

        /// <summary>
        /// session start timestamp in ms
        /// </summary>
        /// <value>session start timestamp in ms</value>
        [DataMember(Name = "start", IsRequired = true, EmitDefaultValue = false)]
        public decimal Start { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IntervalResponse {\n");
            sb.Append("  End: ").Append(End).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
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
            return this.Equals(input as IntervalResponse);
        }

        /// <summary>
        /// Returns true if IntervalResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of IntervalResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IntervalResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.End == input.End ||
                    this.End.Equals(input.End)
                ) && 
                (
                    this.Start == input.Start ||
                    this.Start.Equals(input.Start)
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
                hashCode = hashCode * 59 + this.End.GetHashCode();
                hashCode = hashCode * 59 + this.Start.GetHashCode();
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
