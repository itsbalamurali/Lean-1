

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
    /// ModifyParameters
    /// </summary>
    [DataContract(Name = "ModifyParameters")]
    public partial class ModifyParameters : IEquatable<ModifyParameters>, IValidatableObject
    {
        /// <summary>
        /// order modification action
        /// </summary>
        /// <value>order modification action</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActionEnum
        {
            /// <summary>
            /// Enum Replace for value: replace
            /// </summary>
            [EnumMember(Value = "replace")]
            Replace = 1,

            /// <summary>
            /// Enum Cancel for value: cancel
            /// </summary>
            [EnumMember(Value = "cancel")]
            Cancel = 2

        }

        /// <summary>
        /// order modification action
        /// </summary>
        /// <value>order modification action</value>
        [DataMember(Name = "action", IsRequired = true, EmitDefaultValue = false)]
        public ActionEnum Action { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ModifyParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyParameters" /> class.
        /// </summary>
        /// <param name="parameters">parameters.</param>
        /// <param name="action">order modification action (required).</param>
        public ModifyParameters(ReplaceParameters parameters = default(ReplaceParameters), ActionEnum action = default(ActionEnum))
        {
            this.Action = action;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Gets or Sets Parameters
        /// </summary>
        [DataMember(Name = "parameters", EmitDefaultValue = false)]
        public ReplaceParameters Parameters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ModifyParameters {\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
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
            return this.Equals(input as ModifyParameters);
        }

        /// <summary>
        /// Returns true if ModifyParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of ModifyParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ModifyParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Parameters == input.Parameters ||
                    (this.Parameters != null &&
                    this.Parameters.Equals(input.Parameters))
                ) && 
                (
                    this.Action == input.Action ||
                    this.Action.Equals(input.Action)
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
                if (this.Parameters != null)
                    hashCode = hashCode * 59 + this.Parameters.GetHashCode();
                hashCode = hashCode * 59 + this.Action.GetHashCode();
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
