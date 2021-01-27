

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
    /// TransactionResponse
    /// </summary>
    [DataContract(Name = "TransactionResponse")]
    public partial class TransactionResponse : IEquatable<TransactionResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransactionResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionResponse" /> class.
        /// </summary>
        /// <param name="symbolId">transaction financial instrument (required).</param>
        /// <param name="operationType">transaction type (required).</param>
        /// <param name="timestamp">timestamp of the transaction, required api 3.0 only (required).</param>
        /// <param name="asset">transaction asset (required).</param>
        /// <param name="id">transaction id (required).</param>
        /// <param name="accountId">transaction account id (required).</param>
        /// <param name="sum">transaction amount (required).</param>
        /// <param name="when">timestamp of the transaction, required api 2.0 only (required).</param>
        public TransactionResponse(string symbolId = default(string), string operationType = default(string), decimal timestamp = default(decimal), string asset = default(string), decimal id = default(decimal), string accountId = default(string), string sum = default(string), decimal when = default(decimal))
        {
            // to ensure "symbolId" is required (not null)
            this.SymbolId = symbolId ?? throw new ArgumentNullException("symbolId is a required property for TransactionResponse and cannot be null");
            // to ensure "operationType" is required (not null)
            this.OperationType = operationType ?? throw new ArgumentNullException("operationType is a required property for TransactionResponse and cannot be null");
            this.Timestamp = timestamp;
            // to ensure "asset" is required (not null)
            this.Asset = asset ?? throw new ArgumentNullException("asset is a required property for TransactionResponse and cannot be null");
            this.Id = id;
            // to ensure "accountId" is required (not null)
            this.AccountId = accountId ?? throw new ArgumentNullException("accountId is a required property for TransactionResponse and cannot be null");
            // to ensure "sum" is required (not null)
            this.Sum = sum ?? throw new ArgumentNullException("sum is a required property for TransactionResponse and cannot be null");
            this.When = when;
        }

        /// <summary>
        /// transaction financial instrument
        /// </summary>
        /// <value>transaction financial instrument</value>
        [DataMember(Name = "symbolId", IsRequired = true, EmitDefaultValue = false)]
        public string SymbolId { get; set; }

        /// <summary>
        /// transaction type
        /// </summary>
        /// <value>transaction type</value>
        [DataMember(Name = "operationType", IsRequired = true, EmitDefaultValue = false)]
        public string OperationType { get; set; }

        /// <summary>
        /// timestamp of the transaction, required api 3.0 only
        /// </summary>
        /// <value>timestamp of the transaction, required api 3.0 only</value>
        [DataMember(Name = "timestamp", IsRequired = true, EmitDefaultValue = false)]
        public decimal Timestamp { get; set; }

        /// <summary>
        /// transaction asset
        /// </summary>
        /// <value>transaction asset</value>
        [DataMember(Name = "asset", IsRequired = true, EmitDefaultValue = false)]
        public string Asset { get; set; }

        /// <summary>
        /// transaction id
        /// </summary>
        /// <value>transaction id</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public decimal Id { get; set; }

        /// <summary>
        /// transaction account id
        /// </summary>
        /// <value>transaction account id</value>
        [DataMember(Name = "accountId", IsRequired = true, EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// transaction amount
        /// </summary>
        /// <value>transaction amount</value>
        [DataMember(Name = "sum", IsRequired = true, EmitDefaultValue = false)]
        public string Sum { get; set; }

        /// <summary>
        /// timestamp of the transaction, required api 2.0 only
        /// </summary>
        /// <value>timestamp of the transaction, required api 2.0 only</value>
        [DataMember(Name = "when", IsRequired = true, EmitDefaultValue = false)]
        public decimal When { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransactionResponse {\n");
            sb.Append("  SymbolId: ").Append(SymbolId).Append("\n");
            sb.Append("  OperationType: ").Append(OperationType).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Asset: ").Append(Asset).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  Sum: ").Append(Sum).Append("\n");
            sb.Append("  When: ").Append(When).Append("\n");
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
            return this.Equals(input as TransactionResponse);
        }

        /// <summary>
        /// Returns true if TransactionResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SymbolId == input.SymbolId ||
                    (this.SymbolId != null &&
                    this.SymbolId.Equals(input.SymbolId))
                ) && 
                (
                    this.OperationType == input.OperationType ||
                    (this.OperationType != null &&
                    this.OperationType.Equals(input.OperationType))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    this.Timestamp.Equals(input.Timestamp)
                ) && 
                (
                    this.Asset == input.Asset ||
                    (this.Asset != null &&
                    this.Asset.Equals(input.Asset))
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
                ) && 
                (
                    this.Sum == input.Sum ||
                    (this.Sum != null &&
                    this.Sum.Equals(input.Sum))
                ) && 
                (
                    this.When == input.When ||
                    this.When.Equals(input.When)
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
                if (this.SymbolId != null)
                    hashCode = hashCode * 59 + this.SymbolId.GetHashCode();
                if (this.OperationType != null)
                    hashCode = hashCode * 59 + this.OperationType.GetHashCode();
                hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.Asset != null)
                    hashCode = hashCode * 59 + this.Asset.GetHashCode();
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.AccountId != null)
                    hashCode = hashCode * 59 + this.AccountId.GetHashCode();
                if (this.Sum != null)
                    hashCode = hashCode * 59 + this.Sum.GetHashCode();
                hashCode = hashCode * 59 + this.When.GetHashCode();
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
