

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
    /// AccountSummaryResponse
    /// </summary>
    [DataContract(Name = "AccountSummaryResponse")]
    public partial class AccountSummaryResponse : IEquatable<AccountSummaryResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSummaryResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccountSummaryResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSummaryResponse" /> class.
        /// </summary>
        /// <param name="netAssetValue">total NAV of user in the currency of the report.</param>
        /// <param name="positions">open positions (required).</param>
        /// <param name="currency">currency of the report (required).</param>
        /// <param name="marginUtilization">margin utilization in fraction of NAV.</param>
        /// <param name="timestamp">timestamp of the report (required).</param>
        /// <param name="moneyUsedForMargin">money used for margin in the currency of the report.</param>
        /// <param name="currencies">currencies on position (required).</param>
        /// <param name="account">user account id, required api 2.0 only (required).</param>
        /// <param name="sessionDate">session date of the report.</param>
        /// <param name="freeMoney">free money in the currency of the report.</param>
        /// <param name="accountId">user account id, required api 3.0 only (required).</param>
        public AccountSummaryResponse(string netAssetValue = default(string), List<InstrumentPositionResponse> positions = default(List<InstrumentPositionResponse>), string currency = default(string), string marginUtilization = default(string), decimal timestamp = default(decimal), string moneyUsedForMargin = default(string), List<CurrencyPositionResponse> currencies = default(List<CurrencyPositionResponse>), string account = default(string), string sessionDate = default(string), string freeMoney = default(string), string accountId = default(string))
        {
            // to ensure "positions" is required (not null)
            this.Positions = positions ?? throw new ArgumentNullException("positions is a required property for AccountSummaryResponse and cannot be null");
            // to ensure "currency" is required (not null)
            this.Currency = currency ?? throw new ArgumentNullException("currency is a required property for AccountSummaryResponse and cannot be null");
            this.Timestamp = timestamp;
            // to ensure "currencies" is required (not null)
            this.Currencies = currencies ?? throw new ArgumentNullException("currencies is a required property for AccountSummaryResponse and cannot be null");
            // to ensure "account" is required (not null)
            this.Account = account ?? throw new ArgumentNullException("account is a required property for AccountSummaryResponse and cannot be null");
            // to ensure "accountId" is required (not null)
            this.AccountId = accountId ?? throw new ArgumentNullException("accountId is a required property for AccountSummaryResponse and cannot be null");
            this.NetAssetValue = netAssetValue;
            this.MarginUtilization = marginUtilization;
            this.MoneyUsedForMargin = moneyUsedForMargin;
            this.SessionDate = sessionDate;
            this.FreeMoney = freeMoney;
        }

        /// <summary>
        /// total NAV of user in the currency of the report
        /// </summary>
        /// <value>total NAV of user in the currency of the report</value>
        [DataMember(Name = "netAssetValue", EmitDefaultValue = false)]
        public string NetAssetValue { get; set; }

        /// <summary>
        /// open positions
        /// </summary>
        /// <value>open positions</value>
        [DataMember(Name = "positions", IsRequired = true, EmitDefaultValue = false)]
        public List<InstrumentPositionResponse> Positions { get; set; }

        /// <summary>
        /// currency of the report
        /// </summary>
        /// <value>currency of the report</value>
        [DataMember(Name = "currency", IsRequired = true, EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// margin utilization in fraction of NAV
        /// </summary>
        /// <value>margin utilization in fraction of NAV</value>
        [DataMember(Name = "marginUtilization", EmitDefaultValue = false)]
        public string MarginUtilization { get; set; }

        /// <summary>
        /// timestamp of the report
        /// </summary>
        /// <value>timestamp of the report</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public decimal Timestamp { get; set; }

        /// <summary>
        /// money used for margin in the currency of the report
        /// </summary>
        /// <value>money used for margin in the currency of the report</value>
        [DataMember(Name = "moneyUsedForMargin", EmitDefaultValue = false)]
        public string MoneyUsedForMargin { get; set; }

        /// <summary>
        /// currencies on position
        /// </summary>
        /// <value>currencies on position</value>
        [DataMember(Name = "currencies", IsRequired = true, EmitDefaultValue = false)]
        public List<CurrencyPositionResponse> Currencies { get; set; }

        /// <summary>
        /// user account id, required api 2.0 only
        /// </summary>
        /// <value>user account id, required api 2.0 only</value>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = false)]
        public string Account { get; set; }

        /// <summary>
        /// session date of the report
        /// </summary>
        /// <value>session date of the report</value>
        [DataMember(Name = "sessionDate", EmitDefaultValue = false)]
        public string SessionDate { get; set; }

        /// <summary>
        /// free money in the currency of the report
        /// </summary>
        /// <value>free money in the currency of the report</value>
        [DataMember(Name = "freeMoney", EmitDefaultValue = false)]
        public string FreeMoney { get; set; }

        /// <summary>
        /// user account id, required api 3.0 only
        /// </summary>
        /// <value>user account id, required api 3.0 only</value>
        [DataMember(Name = "accountId", IsRequired = true, EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountSummaryResponse {\n");
            sb.Append("  NetAssetValue: ").Append(NetAssetValue).Append("\n");
            sb.Append("  Positions: ").Append(Positions).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  MarginUtilization: ").Append(MarginUtilization).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  MoneyUsedForMargin: ").Append(MoneyUsedForMargin).Append("\n");
            sb.Append("  Currencies: ").Append(Currencies).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  SessionDate: ").Append(SessionDate).Append("\n");
            sb.Append("  FreeMoney: ").Append(FreeMoney).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
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
            return this.Equals(input as AccountSummaryResponse);
        }

        /// <summary>
        /// Returns true if AccountSummaryResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountSummaryResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountSummaryResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NetAssetValue == input.NetAssetValue ||
                    (this.NetAssetValue != null &&
                    this.NetAssetValue.Equals(input.NetAssetValue))
                ) && 
                (
                    this.Positions == input.Positions ||
                    this.Positions != null &&
                    input.Positions != null &&
                    this.Positions.SequenceEqual(input.Positions)
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.MarginUtilization == input.MarginUtilization ||
                    (this.MarginUtilization != null &&
                    this.MarginUtilization.Equals(input.MarginUtilization))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    this.Timestamp.Equals(input.Timestamp)
                ) && 
                (
                    this.MoneyUsedForMargin == input.MoneyUsedForMargin ||
                    (this.MoneyUsedForMargin != null &&
                    this.MoneyUsedForMargin.Equals(input.MoneyUsedForMargin))
                ) && 
                (
                    this.Currencies == input.Currencies ||
                    this.Currencies != null &&
                    input.Currencies != null &&
                    this.Currencies.SequenceEqual(input.Currencies)
                ) && 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.SessionDate == input.SessionDate ||
                    (this.SessionDate != null &&
                    this.SessionDate.Equals(input.SessionDate))
                ) && 
                (
                    this.FreeMoney == input.FreeMoney ||
                    (this.FreeMoney != null &&
                    this.FreeMoney.Equals(input.FreeMoney))
                ) && 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
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
                if (this.NetAssetValue != null)
                    hashCode = hashCode * 59 + this.NetAssetValue.GetHashCode();
                if (this.Positions != null)
                    hashCode = hashCode * 59 + this.Positions.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                if (this.MarginUtilization != null)
                    hashCode = hashCode * 59 + this.MarginUtilization.GetHashCode();
                hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.MoneyUsedForMargin != null)
                    hashCode = hashCode * 59 + this.MoneyUsedForMargin.GetHashCode();
                if (this.Currencies != null)
                    hashCode = hashCode * 59 + this.Currencies.GetHashCode();
                if (this.Account != null)
                    hashCode = hashCode * 59 + this.Account.GetHashCode();
                if (this.SessionDate != null)
                    hashCode = hashCode * 59 + this.SessionDate.GetHashCode();
                if (this.FreeMoney != null)
                    hashCode = hashCode * 59 + this.FreeMoney.GetHashCode();
                if (this.AccountId != null)
                    hashCode = hashCode * 59 + this.AccountId.GetHashCode();
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
