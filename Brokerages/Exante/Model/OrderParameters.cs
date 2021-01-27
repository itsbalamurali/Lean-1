

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
    /// order response parameters
    /// </summary>
    [DataContract(Name = "OrderParameters")]
    public partial class OrderParameters : IEquatable<OrderParameters>, IValidatableObject
    {
        /// <summary>
        /// order type
        /// </summary>
        /// <value>order type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderTypeEnum
        {
            /// <summary>
            /// Enum Market for value: market
            /// </summary>
            [EnumMember(Value = "market")]
            Market = 1,

            /// <summary>
            /// Enum Limit for value: limit
            /// </summary>
            [EnumMember(Value = "limit")]
            Limit = 2,

            /// <summary>
            /// Enum Stop for value: stop
            /// </summary>
            [EnumMember(Value = "stop")]
            Stop = 3,

            /// <summary>
            /// Enum Stoplimit for value: stop_limit
            /// </summary>
            [EnumMember(Value = "stop_limit")]
            Stoplimit = 4,

            /// <summary>
            /// Enum Twap for value: twap
            /// </summary>
            [EnumMember(Value = "twap")]
            Twap = 5,

            /// <summary>
            /// Enum Trailingstop for value: trailing_stop
            /// </summary>
            [EnumMember(Value = "trailing_stop")]
            Trailingstop = 6,

            /// <summary>
            /// Enum Iceberg for value: iceberg
            /// </summary>
            [EnumMember(Value = "iceberg")]
            Iceberg = 7

        }

        /// <summary>
        /// order type
        /// </summary>
        /// <value>order type</value>
        [DataMember(Name = "orderType", IsRequired = true, EmitDefaultValue = false)]
        public OrderTypeEnum OrderType { get; set; }
        /// <summary>
        /// order side
        /// </summary>
        /// <value>order side</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SideEnum
        {
            /// <summary>
            /// Enum Buy for value: buy
            /// </summary>
            [EnumMember(Value = "buy")]
            Buy = 1,

            /// <summary>
            /// Enum Sell for value: sell
            /// </summary>
            [EnumMember(Value = "sell")]
            Sell = 2

        }

        /// <summary>
        /// order side
        /// </summary>
        /// <value>order side</value>
        [DataMember(Name = "side", IsRequired = true, EmitDefaultValue = false)]
        public SideEnum Side { get; set; }
        /// <summary>
        /// order duration
        /// </summary>
        /// <value>order duration</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DurationEnum
        {
            /// <summary>
            /// Enum Day for value: day
            /// </summary>
            [EnumMember(Value = "day")]
            Day = 1,

            /// <summary>
            /// Enum Fillorkill for value: fill_or_kill
            /// </summary>
            [EnumMember(Value = "fill_or_kill")]
            Fillorkill = 2,

            /// <summary>
            /// Enum Immediateorcancel for value: immediate_or_cancel
            /// </summary>
            [EnumMember(Value = "immediate_or_cancel")]
            Immediateorcancel = 3,

            /// <summary>
            /// Enum Goodtillcancel for value: good_till_cancel
            /// </summary>
            [EnumMember(Value = "good_till_cancel")]
            Goodtillcancel = 4,

            /// <summary>
            /// Enum Goodtilltime for value: good_till_time
            /// </summary>
            [EnumMember(Value = "good_till_time")]
            Goodtilltime = 5,

            /// <summary>
            /// Enum Attheopening for value: at_the_opening
            /// </summary>
            [EnumMember(Value = "at_the_opening")]
            Attheopening = 6,

            /// <summary>
            /// Enum Attheclose for value: at_the_close
            /// </summary>
            [EnumMember(Value = "at_the_close")]
            Attheclose = 7

        }

        /// <summary>
        /// order duration
        /// </summary>
        /// <value>order duration</value>
        [DataMember(Name = "duration", IsRequired = true, EmitDefaultValue = false)]
        public DurationEnum Duration { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected OrderParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderParameters" /> class.
        /// </summary>
        /// <param name="instrument">associated instrument, required api 2.0 only (required).</param>
        /// <param name="orderType">order type (required).</param>
        /// <param name="limitPrice">order limit price, Limit orders only.</param>
        /// <param name="side">order side (required).</param>
        /// <param name="symbolId">associated instrument, required api 3.0 only (required).</param>
        /// <param name="ifDoneParentId">ID of an order on which this order depends.</param>
        /// <param name="placeInterval">order place interval, Twap orders only.</param>
        /// <param name="duration">order duration (required).</param>
        /// <param name="stopPrice">order stop price, Stop orders only.</param>
        /// <param name="quantity">order quantity (required).</param>
        /// <param name="gttExpiration">order expiration if applicable.</param>
        /// <param name="ocoGroup">One-Cancels-the-Other group ID if set.</param>
        /// <param name="priceDistance">order price distance, TrailingStop orders only.</param>
        /// <param name="partQuantity">order partial quantity, Twap and Iceberg orders only.</param>
        public OrderParameters(string instrument = default(string), OrderTypeEnum orderType = default(OrderTypeEnum), string limitPrice = default(string), SideEnum side = default(SideEnum), string symbolId = default(string), string ifDoneParentId = default(string), string placeInterval = default(string), DurationEnum duration = default(DurationEnum), string stopPrice = default(string), string quantity = default(string), DateTime gttExpiration = default(DateTime), string ocoGroup = default(string), string priceDistance = default(string), string partQuantity = default(string))
        {
            // to ensure "instrument" is required (not null)
            this.Instrument = instrument ?? throw new ArgumentNullException("instrument is a required property for OrderParameters and cannot be null");
            this.OrderType = orderType;
            this.Side = side;
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for OrderParameters and cannot be null");
            this.Duration = duration;
            // to ensure "quantity" is required (not null)
            this.Quantity = quantity ?? throw new ArgumentNullException("quantity is a required property for OrderParameters and cannot be null");
            this.LimitPrice = limitPrice;
            this.IfDoneParentId = ifDoneParentId;
            this.PlaceInterval = placeInterval;
            this.StopPrice = stopPrice;
            this.GttExpiration = gttExpiration;
            this.OcoGroup = ocoGroup;
            this.PriceDistance = priceDistance;
            this.PartQuantity = partQuantity;
        }

        /// <summary>
        /// associated instrument, required api 2.0 only
        /// </summary>
        /// <value>associated instrument, required api 2.0 only</value>
        [DataMember(Name = "instrument", IsRequired = true, EmitDefaultValue = false)]
        public string Instrument { get; set; }

        /// <summary>
        /// order limit price, Limit orders only
        /// </summary>
        /// <value>order limit price, Limit orders only</value>
        [DataMember(Name = "limitPrice", EmitDefaultValue = false)]
        public string LimitPrice { get; set; }

        /// <summary>
        /// associated instrument, required api 3.0 only
        /// </summary>
        /// <value>associated instrument, required api 3.0 only</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// ID of an order on which this order depends
        /// </summary>
        /// <value>ID of an order on which this order depends</value>
        [DataMember(Name = "ifDoneParentId", EmitDefaultValue = false)]
        public string IfDoneParentId { get; set; }

        /// <summary>
        /// order place interval, Twap orders only
        /// </summary>
        /// <value>order place interval, Twap orders only</value>
        [DataMember(Name = "placeInterval", EmitDefaultValue = false)]
        public string PlaceInterval { get; set; }

        /// <summary>
        /// order stop price, Stop orders only
        /// </summary>
        /// <value>order stop price, Stop orders only</value>
        [DataMember(Name = "stopPrice", EmitDefaultValue = false)]
        public string StopPrice { get; set; }

        /// <summary>
        /// order quantity
        /// </summary>
        /// <value>order quantity</value>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = false)]
        public string Quantity { get; set; }

        /// <summary>
        /// order expiration if applicable
        /// </summary>
        /// <value>order expiration if applicable</value>
        [DataMember(Name = "gttExpiration", EmitDefaultValue = false)]
        public DateTime GttExpiration { get; set; }

        /// <summary>
        /// One-Cancels-the-Other group ID if set
        /// </summary>
        /// <value>One-Cancels-the-Other group ID if set</value>
        [DataMember(Name = "ocoGroup", EmitDefaultValue = false)]
        public string OcoGroup { get; set; }

        /// <summary>
        /// order price distance, TrailingStop orders only
        /// </summary>
        /// <value>order price distance, TrailingStop orders only</value>
        [DataMember(Name = "priceDistance", EmitDefaultValue = false)]
        public string PriceDistance { get; set; }

        /// <summary>
        /// order partial quantity, Twap and Iceberg orders only
        /// </summary>
        /// <value>order partial quantity, Twap and Iceberg orders only</value>
        [DataMember(Name = "partQuantity", EmitDefaultValue = false)]
        public string PartQuantity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderParameters {\n");
            sb.Append("  Instrument: ").Append(Instrument).Append("\n");
            sb.Append("  OrderType: ").Append(OrderType).Append("\n");
            sb.Append("  LimitPrice: ").Append(LimitPrice).Append("\n");
            sb.Append("  Side: ").Append(Side).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  IfDoneParentId: ").Append(IfDoneParentId).Append("\n");
            sb.Append("  PlaceInterval: ").Append(PlaceInterval).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  StopPrice: ").Append(StopPrice).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  GttExpiration: ").Append(GttExpiration).Append("\n");
            sb.Append("  OcoGroup: ").Append(OcoGroup).Append("\n");
            sb.Append("  PriceDistance: ").Append(PriceDistance).Append("\n");
            sb.Append("  PartQuantity: ").Append(PartQuantity).Append("\n");
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
            return this.Equals(input as OrderParameters);
        }

        /// <summary>
        /// Returns true if OrderParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Instrument == input.Instrument ||
                    (this.Instrument != null &&
                    this.Instrument.Equals(input.Instrument))
                ) && 
                (
                    this.OrderType == input.OrderType ||
                    this.OrderType.Equals(input.OrderType)
                ) && 
                (
                    this.LimitPrice == input.LimitPrice ||
                    (this.LimitPrice != null &&
                    this.LimitPrice.Equals(input.LimitPrice))
                ) && 
                (
                    this.Side == input.Side ||
                    this.Side.Equals(input.Side)
                ) && 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
                ) && 
                (
                    this.IfDoneParentId == input.IfDoneParentId ||
                    (this.IfDoneParentId != null &&
                    this.IfDoneParentId.Equals(input.IfDoneParentId))
                ) && 
                (
                    this.PlaceInterval == input.PlaceInterval ||
                    (this.PlaceInterval != null &&
                    this.PlaceInterval.Equals(input.PlaceInterval))
                ) && 
                (
                    this.Duration == input.Duration ||
                    this.Duration.Equals(input.Duration)
                ) && 
                (
                    this.StopPrice == input.StopPrice ||
                    (this.StopPrice != null &&
                    this.StopPrice.Equals(input.StopPrice))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.GttExpiration == input.GttExpiration ||
                    (this.GttExpiration != null &&
                    this.GttExpiration.Equals(input.GttExpiration))
                ) && 
                (
                    this.OcoGroup == input.OcoGroup ||
                    (this.OcoGroup != null &&
                    this.OcoGroup.Equals(input.OcoGroup))
                ) && 
                (
                    this.PriceDistance == input.PriceDistance ||
                    (this.PriceDistance != null &&
                    this.PriceDistance.Equals(input.PriceDistance))
                ) && 
                (
                    this.PartQuantity == input.PartQuantity ||
                    (this.PartQuantity != null &&
                    this.PartQuantity.Equals(input.PartQuantity))
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
                if (this.Instrument != null)
                    hashCode = hashCode * 59 + this.Instrument.GetHashCode();
                hashCode = hashCode * 59 + this.OrderType.GetHashCode();
                if (this.LimitPrice != null)
                    hashCode = hashCode * 59 + this.LimitPrice.GetHashCode();
                hashCode = hashCode * 59 + this.Side.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                if (this.IfDoneParentId != null)
                    hashCode = hashCode * 59 + this.IfDoneParentId.GetHashCode();
                if (this.PlaceInterval != null)
                    hashCode = hashCode * 59 + this.PlaceInterval.GetHashCode();
                hashCode = hashCode * 59 + this.Duration.GetHashCode();
                if (this.StopPrice != null)
                    hashCode = hashCode * 59 + this.StopPrice.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.GttExpiration != null)
                    hashCode = hashCode * 59 + this.GttExpiration.GetHashCode();
                if (this.OcoGroup != null)
                    hashCode = hashCode * 59 + this.OcoGroup.GetHashCode();
                if (this.PriceDistance != null)
                    hashCode = hashCode * 59 + this.PriceDistance.GetHashCode();
                if (this.PartQuantity != null)
                    hashCode = hashCode * 59 + this.PartQuantity.GetHashCode();
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
