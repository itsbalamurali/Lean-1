

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
    /// Crossrate
    /// </summary>
    [DataContract(Name = "Crossrate")]
    public partial class Crossrate : IEquatable<Crossrate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Crossrate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Crossrate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Crossrate" /> class.
        /// </summary>
        /// <param name="pair">crossrate pair (required).</param>
        /// <param name="symbolId">optional symbol id, which can be used to request history or subscribe to feed.</param>
        /// <param name="rate">current crossrate (required).</param>
        public Crossrate(string pair = default(string), string symbolId = default(string), string rate = default(string))
        {
            // to ensure "pair" is required (not null)
            this.Pair = pair ?? throw new ArgumentNullException("pair is a required property for Crossrate and cannot be null");
            // to ensure "rate" is required (not null)
            this.Rate = rate ?? throw new ArgumentNullException("rate is a required property for Crossrate and cannot be null");
            this.SymbolId = symbolId;
        }

        /// <summary>
        /// crossrate pair
        /// </summary>
        /// <value>crossrate pair</value>
        [DataMember(Name = "pair", IsRequired = true, EmitDefaultValue = false)]
        public string Pair { get; set; }

        /// <summary>
        /// optional symbol id, which can be used to request history or subscribe to feed
        /// </summary>
        /// <value>optional symbol id, which can be used to request history or subscribe to feed</value>
        [DataMember(Name = "symbolId", EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// current crossrate
        /// </summary>
        /// <value>current crossrate</value>
        [DataMember(Name = "rate", IsRequired = true, EmitDefaultValue = false)]
        public string Rate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Crossrate {\n");
            sb.Append("  Pair: ").Append(Pair).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  Rate: ").Append(Rate).Append("\n");
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
            return this.Equals(input as Crossrate);
        }

        /// <summary>
        /// Returns true if Crossrate instances are equal
        /// </summary>
        /// <param name="input">Instance of Crossrate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Crossrate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Pair == input.Pair ||
                    (this.Pair != null &&
                    this.Pair.Equals(input.Pair))
                ) && 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
                ) && 
                (
                    this.Rate == input.Rate ||
                    (this.Rate != null &&
                    this.Rate.Equals(input.Rate))
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
                if (this.Pair != null)
                    hashCode = hashCode * 59 + this.Pair.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                if (this.Rate != null)
                    hashCode = hashCode * 59 + this.Rate.GetHashCode();
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
