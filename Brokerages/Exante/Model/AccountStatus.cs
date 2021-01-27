

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
    /// account status response
    /// </summary>
    [DataContract(Name = "AccountStatus")]
    public partial class AccountStatus : IEquatable<AccountStatus>, IValidatableObject
    {
        /// <summary>
        /// account status
        /// </summary>
        /// <value>account status</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum ReadOnly for value: ReadOnly
            /// </summary>
            [EnumMember(Value = "ReadOnly")]
            ReadOnly = 1,

            /// <summary>
            /// Enum CloseOnly for value: CloseOnly
            /// </summary>
            [EnumMember(Value = "CloseOnly")]
            CloseOnly = 2,

            /// <summary>
            /// Enum Full for value: Full
            /// </summary>
            [EnumMember(Value = "Full")]
            Full = 3

        }

        /// <summary>
        /// account status
        /// </summary>
        /// <value>account status</value>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = false)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccountStatus() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStatus" /> class.
        /// </summary>
        /// <param name="status">account status (required).</param>
        /// <param name="accountId">account ID (required).</param>
        public AccountStatus(StatusEnum status = default(StatusEnum), string accountId = default(string))
        {
            this.Status = status;
            // to ensure "accountId" is required (not null)
            this.AccountId = accountId ?? throw new ArgumentNullException("accountId is a required property for AccountStatus and cannot be null");
        }

        /// <summary>
        /// account ID
        /// </summary>
        /// <value>account ID</value>
        [DataMember(Name = "accountId", IsRequired = true, EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountStatus {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as AccountStatus);
        }

        /// <summary>
        /// Returns true if AccountStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountStatus input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
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
                hashCode = hashCode * 59 + this.Status.GetHashCode();
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
