

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
    /// modification parameters if applicable
    /// </summary>
    [DataContract(Name = "ReplaceParameters")]
    public partial class ReplaceParameters : IEquatable<ReplaceParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ReplaceParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceParameters" /> class.
        /// </summary>
        /// <param name="quantity">new order quantity to replace (required).</param>
        /// <param name="stopPrice">new order stop price if applicable.</param>
        /// <param name="priceDistance">new order price distance if applicable.</param>
        /// <param name="limitPrice">new order limit price if applicable.</param>
        public ReplaceParameters(string quantity = default(string), string stopPrice = default(string), string priceDistance = default(string), string limitPrice = default(string))
        {
            // to ensure "quantity" is required (not null)
            this.Quantity = quantity ?? throw new ArgumentNullException("quantity is a required property for ReplaceParameters and cannot be null");
            this.StopPrice = stopPrice;
            this.PriceDistance = priceDistance;
            this.LimitPrice = limitPrice;
        }

        /// <summary>
        /// new order quantity to replace
        /// </summary>
        /// <value>new order quantity to replace</value>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = false)]
        public string Quantity { get; set; }

        /// <summary>
        /// new order stop price if applicable
        /// </summary>
        /// <value>new order stop price if applicable</value>
        [DataMember(Name = "stopPrice", EmitDefaultValue = false)]
        public string StopPrice { get; set; }

        /// <summary>
        /// new order price distance if applicable
        /// </summary>
        /// <value>new order price distance if applicable</value>
        [DataMember(Name = "priceDistance", EmitDefaultValue = false)]
        public string PriceDistance { get; set; }

        /// <summary>
        /// new order limit price if applicable
        /// </summary>
        /// <value>new order limit price if applicable</value>
        [DataMember(Name = "limitPrice", EmitDefaultValue = false)]
        public string LimitPrice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReplaceParameters {\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  StopPrice: ").Append(StopPrice).Append("\n");
            sb.Append("  PriceDistance: ").Append(PriceDistance).Append("\n");
            sb.Append("  LimitPrice: ").Append(LimitPrice).Append("\n");
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
            return this.Equals(input as ReplaceParameters);
        }

        /// <summary>
        /// Returns true if ReplaceParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of ReplaceParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReplaceParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.StopPrice == input.StopPrice ||
                    (this.StopPrice != null &&
                    this.StopPrice.Equals(input.StopPrice))
                ) && 
                (
                    this.PriceDistance == input.PriceDistance ||
                    (this.PriceDistance != null &&
                    this.PriceDistance.Equals(input.PriceDistance))
                ) && 
                (
                    this.LimitPrice == input.LimitPrice ||
                    (this.LimitPrice != null &&
                    this.LimitPrice.Equals(input.LimitPrice))
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
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.StopPrice != null)
                    hashCode = hashCode * 59 + this.StopPrice.GetHashCode();
                if (this.PriceDistance != null)
                    hashCode = hashCode * 59 + this.PriceDistance.GetHashCode();
                if (this.LimitPrice != null)
                    hashCode = hashCode * 59 + this.LimitPrice.GetHashCode();
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
