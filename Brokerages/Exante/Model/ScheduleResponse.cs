

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
    /// ScheduleResponse
    /// </summary>
    [DataContract(Name = "ScheduleResponse")]
    public partial class ScheduleResponse : IEquatable<ScheduleResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleResponse" /> class.
        /// </summary>
        /// <param name="intervals">instrument schedule intervals (required).</param>
        public ScheduleResponse(List<ScheduleIntervalResponse> intervals = default(List<ScheduleIntervalResponse>))
        {
            // to ensure "intervals" is required (not null)
            this.Intervals = intervals ?? throw new ArgumentNullException("intervals is a required property for ScheduleResponse and cannot be null");
        }

        /// <summary>
        /// instrument schedule intervals
        /// </summary>
        /// <value>instrument schedule intervals</value>
        [DataMember(Name = "intervals", IsRequired = true, EmitDefaultValue = false)]
        public List<ScheduleIntervalResponse> Intervals { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScheduleResponse {\n");
            sb.Append("  Intervals: ").Append(Intervals).Append("\n");
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
            return this.Equals(input as ScheduleResponse);
        }

        /// <summary>
        /// Returns true if ScheduleResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Intervals == input.Intervals ||
                    this.Intervals != null &&
                    input.Intervals != null &&
                    this.Intervals.SequenceEqual(input.Intervals)
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
                if (this.Intervals != null)
                    hashCode = hashCode * 59 + this.Intervals.GetHashCode();
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
