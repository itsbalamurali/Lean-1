

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
    /// SymbolInfoResponse
    /// </summary>
    [DataContract(Name = "SymbolInfoResponse")]
    public partial class SymbolInfoResponse : IEquatable<SymbolInfoResponse>, IValidatableObject
    {
        /// <summary>
        /// symbol type, required api 3.0 only
        /// </summary>
        /// <value>symbol type, required api 3.0 only</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SymbolTypeEnum
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
        /// symbol type, required api 3.0 only
        /// </summary>
        /// <value>symbol type, required api 3.0 only</value>
        [DataMember(Name = "symbolType", IsRequired = true, EmitDefaultValue = false)]
        public SymbolTypeEnum SymbolType { get; set; }
        /// <summary>
        /// symbol type, required api 2.0 only
        /// </summary>
        /// <value>symbol type, required api 2.0 only</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
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
        /// symbol type, required api 2.0 only
        /// </summary>
        /// <value>symbol type, required api 2.0 only</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolInfoResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SymbolInfoResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SymbolInfoResponse" /> class.
        /// </summary>
        /// <param name="exchange">exchange id where the symbol is traded.</param>
        /// <param name="name">short symbol description.</param>
        /// <param name="id">internal symbol id, required api 2.0 only (required).</param>
        /// <param name="symbolType">symbol type, required api 3.0 only (required).</param>
        /// <param name="symbolId">internal symbol id, required api 3.0 only (required).</param>
        /// <param name="expiration">expiration timestamp in ms if applicable.</param>
        /// <param name="country">country of symbol&#39;s exchange.</param>
        /// <param name="group">group of symbol, applicable to futures and options.</param>
        /// <param name="description">long symbol description (required).</param>
        /// <param name="currency">currency of symbol price (required).</param>
        /// <param name="type">symbol type, required api 2.0 only (required).</param>
        /// <param name="minPriceIncrement">minimum possible increment of symbol price, required api 3.0 only (required).</param>
        /// <param name="ticker">exchange ticker (required).</param>
        /// <param name="optionData">optionData.</param>
        /// <param name="mpi">minimum possible increment of symbol price, required api 2.0 only (required).</param>
        public SymbolInfoResponse(string exchange = default(string), string name = default(string), string id = default(string), SymbolTypeEnum symbolType = default(SymbolTypeEnum), string symbolId = default(string), decimal expiration = default(decimal), string country = default(string), string group = default(string), string description = default(string), string currency = default(string), TypeEnum type = default(TypeEnum), string minPriceIncrement = default(string), string ticker = default(string), OptionDataResponse optionData = default(OptionDataResponse), string mpi = default(string))
        {
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for SymbolInfoResponse and cannot be null");
            this.SymbolType = symbolType;
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for SymbolInfoResponse and cannot be null");
            // to ensure "description" is required (not null)
            this.Description = description ?? throw new ArgumentNullException("description is a required property for SymbolInfoResponse and cannot be null");
            // to ensure "currency" is required (not null)
            this.Currency = currency ?? throw new ArgumentNullException("currency is a required property for SymbolInfoResponse and cannot be null");
            this.Type = type;
            // to ensure "minPriceIncrement" is required (not null)
            this.MinPriceIncrement = minPriceIncrement ?? throw new ArgumentNullException("minPriceIncrement is a required property for SymbolInfoResponse and cannot be null");
            // to ensure "ticker" is required (not null)
            this.Ticker = ticker ?? throw new ArgumentNullException("ticker is a required property for SymbolInfoResponse and cannot be null");
            // to ensure "mpi" is required (not null)
            this.Mpi = mpi ?? throw new ArgumentNullException("mpi is a required property for SymbolInfoResponse and cannot be null");
            this.Exchange = exchange;
            this.Name = name;
            this.Expiration = expiration;
            this.Country = country;
            this.Group = group;
            this.OptionData = optionData;
        }

        /// <summary>
        /// exchange id where the symbol is traded
        /// </summary>
        /// <value>exchange id where the symbol is traded</value>
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public string Exchange { get; set; }

        /// <summary>
        /// short symbol description
        /// </summary>
        /// <value>short symbol description</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// internal symbol id, required api 2.0 only
        /// </summary>
        /// <value>internal symbol id, required api 2.0 only</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// internal symbol id, required api 3.0 only
        /// </summary>
        /// <value>internal symbol id, required api 3.0 only</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// expiration timestamp in ms if applicable
        /// </summary>
        /// <value>expiration timestamp in ms if applicable</value>
        [DataMember(Name = "expiration", EmitDefaultValue = false)]
        public decimal Expiration { get; set; }

        /// <summary>
        /// country of symbol&#39;s exchange
        /// </summary>
        /// <value>country of symbol&#39;s exchange</value>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// group of symbol, applicable to futures and options
        /// </summary>
        /// <value>group of symbol, applicable to futures and options</value>
        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group { get; set; }

        /// <summary>
        /// long symbol description
        /// </summary>
        /// <value>long symbol description</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// currency of symbol price
        /// </summary>
        /// <value>currency of symbol price</value>
        [DataMember(Name = "currency", IsRequired = true, EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// minimum possible increment of symbol price, required api 3.0 only
        /// </summary>
        /// <value>minimum possible increment of symbol price, required api 3.0 only</value>
        [DataMember(Name = "minPriceIncrement", IsRequired = true, EmitDefaultValue = false)]
        public string MinPriceIncrement { get; set; }

        /// <summary>
        /// exchange ticker
        /// </summary>
        /// <value>exchange ticker</value>
        [DataMember(Name = "ticker", IsRequired = true, EmitDefaultValue = false)]
        public string Ticker { get; set; }

        /// <summary>
        /// Gets or Sets OptionData
        /// </summary>
        [DataMember(Name = "optionData", EmitDefaultValue = false)]
        public OptionDataResponse OptionData { get; set; }

        /// <summary>
        /// minimum possible increment of symbol price, required api 2.0 only
        /// </summary>
        /// <value>minimum possible increment of symbol price, required api 2.0 only</value>
        [DataMember(Name = "mpi", IsRequired = true, EmitDefaultValue = false)]
        public string Mpi { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SymbolInfoResponse {\n");
            sb.Append("  Exchange: ").Append(Exchange).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  SymbolType: ").Append(SymbolType).Append("\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  Expiration: ").Append(Expiration).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Group: ").Append(Group).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  MinPriceIncrement: ").Append(MinPriceIncrement).Append("\n");
            sb.Append("  Ticker: ").Append(Ticker).Append("\n");
            sb.Append("  OptionData: ").Append(OptionData).Append("\n");
            sb.Append("  Mpi: ").Append(Mpi).Append("\n");
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
            return this.Equals(input as SymbolInfoResponse);
        }

        /// <summary>
        /// Returns true if SymbolInfoResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SymbolInfoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SymbolInfoResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Exchange == input.Exchange ||
                    (this.Exchange != null &&
                    this.Exchange.Equals(input.Exchange))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.SymbolType == input.SymbolType ||
                    this.SymbolType.Equals(input.SymbolType)
                ) && 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
                ) && 
                (
                    this.Expiration == input.Expiration ||
                    this.Expiration.Equals(input.Expiration)
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.Group == input.Group ||
                    (this.Group != null &&
                    this.Group.Equals(input.Group))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.MinPriceIncrement == input.MinPriceIncrement ||
                    (this.MinPriceIncrement != null &&
                    this.MinPriceIncrement.Equals(input.MinPriceIncrement))
                ) && 
                (
                    this.Ticker == input.Ticker ||
                    (this.Ticker != null &&
                    this.Ticker.Equals(input.Ticker))
                ) && 
                (
                    this.OptionData == input.OptionData ||
                    (this.OptionData != null &&
                    this.OptionData.Equals(input.OptionData))
                ) && 
                (
                    this.Mpi == input.Mpi ||
                    (this.Mpi != null &&
                    this.Mpi.Equals(input.Mpi))
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
                if (this.Exchange != null)
                    hashCode = hashCode * 59 + this.Exchange.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                hashCode = hashCode * 59 + this.SymbolType.GetHashCode();
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                hashCode = hashCode * 59 + this.Expiration.GetHashCode();
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
                if (this.Group != null)
                    hashCode = hashCode * 59 + this.Group.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.MinPriceIncrement != null)
                    hashCode = hashCode * 59 + this.MinPriceIncrement.GetHashCode();
                if (this.Ticker != null)
                    hashCode = hashCode * 59 + this.Ticker.GetHashCode();
                if (this.OptionData != null)
                    hashCode = hashCode * 59 + this.OptionData.GetHashCode();
                if (this.Mpi != null)
                    hashCode = hashCode * 59 + this.Mpi.GetHashCode();
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
