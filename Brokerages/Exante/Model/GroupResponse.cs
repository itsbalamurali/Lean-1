

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
    /// GroupResponse
    /// </summary>
    [DataContract(Name = "GroupResponse")]
    public partial class GroupResponse : IEquatable<GroupResponse>, IValidatableObject
    {
        /// <summary>
        /// list of symbol types in the group
        /// </summary>
        /// <value>list of symbol types in the group</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypesEnum
        {
            /// <summary>
            /// Enum FXSPOT for value: FX_SPOT
            /// </summary>
            [EnumMember(Value = "FX_SPOT")]
            FXSPOT = 1,

            /// <summary>
            /// Enum CURRENCY for value: CURRENCY
            /// </summary>
            [EnumMember(Value = "CURRENCY")]
            CURRENCY = 2,

            /// <summary>
            /// Enum INDEX for value: INDEX
            /// </summary>
            [EnumMember(Value = "INDEX")]
            INDEX = 3,

            /// <summary>
            /// Enum STOCK for value: STOCK
            /// </summary>
            [EnumMember(Value = "STOCK")]
            STOCK = 4,

            /// <summary>
            /// Enum BOND for value: BOND
            /// </summary>
            [EnumMember(Value = "BOND")]
            BOND = 5,

            /// <summary>
            /// Enum FUND for value: FUND
            /// </summary>
            [EnumMember(Value = "FUND")]
            FUND = 6,

            /// <summary>
            /// Enum FUTURE for value: FUTURE
            /// </summary>
            [EnumMember(Value = "FUTURE")]
            FUTURE = 7,

            /// <summary>
            /// Enum OPTION for value: OPTION
            /// </summary>
            [EnumMember(Value = "OPTION")]
            OPTION = 8,

            /// <summary>
            /// Enum CFD for value: CFD
            /// </summary>
            [EnumMember(Value = "CFD")]
            CFD = 9,

            /// <summary>
            /// Enum CALENDARSPREAD for value: CALENDAR_SPREAD
            /// </summary>
            [EnumMember(Value = "CALENDAR_SPREAD")]
            CALENDARSPREAD = 10

        }

        /// <summary>
        /// list of symbol types in the group
        /// </summary>
        /// <value>list of symbol types in the group</value>
        [DataMember(Name = "types", IsRequired = true, EmitDefaultValue = false)]
        public TypesEnum Types { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GroupResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupResponse" /> class.
        /// </summary>
        /// <param name="group">group id (required).</param>
        /// <param name="name">group title.</param>
        /// <param name="exchange">exchange id where the group is traded.</param>
        /// <param name="types">list of symbol types in the group (required).</param>
        public GroupResponse(string group = default(string), string name = default(string), string exchange = default(string), TypesEnum types = default(TypesEnum))
        {
            // to ensure "group" is required (not null)
            this.Group = group ?? throw new ArgumentNullException("group is a required property for GroupResponse and cannot be null");
            this.Types = types;
            this.Name = name;
            this.Exchange = exchange;
        }

        /// <summary>
        /// group id
        /// </summary>
        /// <value>group id</value>
        [DataMember(Name = "group", IsRequired = true, EmitDefaultValue = false)]
        public string Group { get; set; }

        /// <summary>
        /// group title
        /// </summary>
        /// <value>group title</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// exchange id where the group is traded
        /// </summary>
        /// <value>exchange id where the group is traded</value>
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public string Exchange { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GroupResponse {\n");
            sb.Append("  Group: ").Append(Group).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Exchange: ").Append(Exchange).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
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
            return this.Equals(input as GroupResponse);
        }

        /// <summary>
        /// Returns true if GroupResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of GroupResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GroupResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Group == input.Group ||
                    (this.Group != null &&
                    this.Group.Equals(input.Group))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Exchange == input.Exchange ||
                    (this.Exchange != null &&
                    this.Exchange.Equals(input.Exchange))
                ) && 
                (
                    this.Types == input.Types ||
                    this.Types.Equals(input.Types)
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
                if (this.Group != null)
                    hashCode = hashCode * 59 + this.Group.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Exchange != null)
                    hashCode = hashCode * 59 + this.Exchange.GetHashCode();
                hashCode = hashCode * 59 + this.Types.GetHashCode();
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
