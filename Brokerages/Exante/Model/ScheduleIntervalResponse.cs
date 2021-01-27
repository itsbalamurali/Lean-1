

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
    /// instrument schedule intervals
    /// </summary>
    [DataContract(Name = "ScheduleIntervalResponse")]
    public partial class ScheduleIntervalResponse : IEquatable<ScheduleIntervalResponse>, IValidatableObject
    {
        /// <summary>
        /// trading session name
        /// </summary>
        /// <value>trading session name</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum NameEnum
        {
            /// <summary>
            /// Enum PreMarket for value: PreMarket
            /// </summary>
            [EnumMember(Value = "PreMarket")]
            PreMarket = 1,

            /// <summary>
            /// Enum MainSession for value: MainSession
            /// </summary>
            [EnumMember(Value = "MainSession")]
            MainSession = 2,

            /// <summary>
            /// Enum AfterMarket for value: AfterMarket
            /// </summary>
            [EnumMember(Value = "AfterMarket")]
            AfterMarket = 3,

            /// <summary>
            /// Enum Offline for value: Offline
            /// </summary>
            [EnumMember(Value = "Offline")]
            Offline = 4,

            /// <summary>
            /// Enum Online for value: Online
            /// </summary>
            [EnumMember(Value = "Online")]
            Online = 5,

            /// <summary>
            /// Enum Expired for value: Expired
            /// </summary>
            [EnumMember(Value = "Expired")]
            Expired = 6

        }

        /// <summary>
        /// trading session name
        /// </summary>
        /// <value>trading session name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public NameEnum Name { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleIntervalResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ScheduleIntervalResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleIntervalResponse" /> class.
        /// </summary>
        /// <param name="name">trading session name (required).</param>
        /// <param name="period">period (required).</param>
        /// <param name="orderTypes">orderTypes.</param>
        public ScheduleIntervalResponse(NameEnum name = default(NameEnum), IntervalResponse period = default(IntervalResponse), AvailableOrderDurationTypes orderTypes = default(AvailableOrderDurationTypes))
        {
            this.Name = name;
            // to ensure "period" is required (not null)
            this.Period = period ?? throw new ArgumentNullException("period is a required property for ScheduleIntervalResponse and cannot be null");
            this.OrderTypes = orderTypes;
        }

        /// <summary>
        /// Gets or Sets Period
        /// </summary>
        [DataMember(Name = "period", IsRequired = true, EmitDefaultValue = false)]
        public IntervalResponse Period { get; set; }

        /// <summary>
        /// Gets or Sets OrderTypes
        /// </summary>
        [DataMember(Name = "orderTypes", EmitDefaultValue = false)]
        public AvailableOrderDurationTypes OrderTypes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScheduleIntervalResponse {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Period: ").Append(Period).Append("\n");
            sb.Append("  OrderTypes: ").Append(OrderTypes).Append("\n");
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
            return this.Equals(input as ScheduleIntervalResponse);
        }

        /// <summary>
        /// Returns true if ScheduleIntervalResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ScheduleIntervalResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScheduleIntervalResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    this.Name.Equals(input.Name)
                ) && 
                (
                    this.Period == input.Period ||
                    (this.Period != null &&
                    this.Period.Equals(input.Period))
                ) && 
                (
                    this.OrderTypes == input.OrderTypes ||
                    (this.OrderTypes != null &&
                    this.OrderTypes.Equals(input.OrderTypes))
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
                hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Period != null)
                    hashCode = hashCode * 59 + this.Period.GetHashCode();
                if (this.OrderTypes != null)
                    hashCode = hashCode * 59 + this.OrderTypes.GetHashCode();
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
