

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
    /// order response
    /// </summary>
    [DataContract(Name = "ApiOrder")]
    public partial class ApiOrder : IEquatable<ApiOrder>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiOrder" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ApiOrder() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiOrder" /> class.
        /// </summary>
        /// <param name="id">unique order ID, required api 2.0 only (required).</param>
        /// <param name="currentModificationId">current order modification unique ID (required).</param>
        /// <param name="placeTime">order place time (required).</param>
        /// <param name="username">associated name.</param>
        /// <param name="orderId">unique order ID, required api 3.0 only (required).</param>
        /// <param name="orderState">orderState (required).</param>
        /// <param name="orderParameters">orderParameters (required).</param>
        /// <param name="clientTag">optional client tag to identify or group orders.</param>
        /// <param name="accountId">associated account ID (required).</param>
        public ApiOrder(string id = default(string), string currentModificationId = default(string), DateTime placeTime = default(DateTime), string username = default(string), string orderId = default(string), OrderState orderState = default(OrderState), OrderParameters orderParameters = default(OrderParameters), string clientTag = default(string), string accountId = default(string))
        {
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for ApiOrder and cannot be null");
            // to ensure "currentModificationId" is required (not null)
            this.CurrentModificationId = currentModificationId ?? throw new ArgumentNullException("currentModificationId is a required property for ApiOrder and cannot be null");
            this.PlaceTime = placeTime;
            // to ensure "orderId" is required (not null)
            this.OrderId = orderId ?? throw new ArgumentNullException("orderId is a required property for ApiOrder and cannot be null");
            // to ensure "orderState" is required (not null)
            this.OrderState = orderState ?? throw new ArgumentNullException("orderState is a required property for ApiOrder and cannot be null");
            // to ensure "orderParameters" is required (not null)
            this.OrderParameters = orderParameters ?? throw new ArgumentNullException("orderParameters is a required property for ApiOrder and cannot be null");
            // to ensure "accountId" is required (not null)
            this.AccountId = accountId ?? throw new ArgumentNullException("accountId is a required property for ApiOrder and cannot be null");
            this.Username = username;
            this.ClientTag = clientTag;
        }

        /// <summary>
        /// unique order ID, required api 2.0 only
        /// </summary>
        /// <value>unique order ID, required api 2.0 only</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// current order modification unique ID
        /// </summary>
        /// <value>current order modification unique ID</value>
        [DataMember(Name = "currentModificationId", IsRequired = true, EmitDefaultValue = false)]
        public string CurrentModificationId { get; set; }

        /// <summary>
        /// order place time
        /// </summary>
        /// <value>order place time</value>
        [DataMember(Name = "placeTime", IsRequired = true, EmitDefaultValue = false)]
        public DateTime PlaceTime { get; set; }

        /// <summary>
        /// associated name
        /// </summary>
        /// <value>associated name</value>
        [DataMember(Name = "username", EmitDefaultValue = false)]
        public string Username { get; set; }

        /// <summary>
        /// unique order ID, required api 3.0 only
        /// </summary>
        /// <value>unique order ID, required api 3.0 only</value>
        [DataMember(Name = "orderId", IsRequired = true, EmitDefaultValue = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or Sets OrderState
        /// </summary>
        [DataMember(Name = "orderState", IsRequired = true, EmitDefaultValue = false)]
        public OrderState OrderState { get; set; }

        /// <summary>
        /// Gets or Sets OrderParameters
        /// </summary>
        [DataMember(Name = "orderParameters", IsRequired = true, EmitDefaultValue = false)]
        public OrderParameters OrderParameters { get; set; }

        /// <summary>
        /// optional client tag to identify or group orders
        /// </summary>
        /// <value>optional client tag to identify or group orders</value>
        [DataMember(Name = "clientTag", EmitDefaultValue = false)]
        public string ClientTag { get; set; }

        /// <summary>
        /// associated account ID
        /// </summary>
        /// <value>associated account ID</value>
        [DataMember(Name = "accountId", IsRequired = true, EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiOrder {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CurrentModificationId: ").Append(CurrentModificationId).Append("\n");
            sb.Append("  PlaceTime: ").Append(PlaceTime).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  OrderState: ").Append(OrderState).Append("\n");
            sb.Append("  OrderParameters: ").Append(OrderParameters).Append("\n");
            sb.Append("  ClientTag: ").Append(ClientTag).Append("\n");
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
            return this.Equals(input as ApiOrder);
        }

        /// <summary>
        /// Returns true if ApiOrder instances are equal
        /// </summary>
        /// <param name="input">Instance of ApiOrder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiOrder input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.CurrentModificationId == input.CurrentModificationId ||
                    (this.CurrentModificationId != null &&
                    this.CurrentModificationId.Equals(input.CurrentModificationId))
                ) && 
                (
                    this.PlaceTime == input.PlaceTime ||
                    (this.PlaceTime != null &&
                    this.PlaceTime.Equals(input.PlaceTime))
                ) && 
                (
                    this.Username == input.Username ||
                    (this.Username != null &&
                    this.Username.Equals(input.Username))
                ) && 
                (
                    this.OrderId == input.OrderId ||
                    (this.OrderId != null &&
                    this.OrderId.Equals(input.OrderId))
                ) && 
                (
                    this.OrderState == input.OrderState ||
                    (this.OrderState != null &&
                    this.OrderState.Equals(input.OrderState))
                ) && 
                (
                    this.OrderParameters == input.OrderParameters ||
                    (this.OrderParameters != null &&
                    this.OrderParameters.Equals(input.OrderParameters))
                ) && 
                (
                    this.ClientTag == input.ClientTag ||
                    (this.ClientTag != null &&
                    this.ClientTag.Equals(input.ClientTag))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.CurrentModificationId != null)
                    hashCode = hashCode * 59 + this.CurrentModificationId.GetHashCode();
                if (this.PlaceTime != null)
                    hashCode = hashCode * 59 + this.PlaceTime.GetHashCode();
                if (this.Username != null)
                    hashCode = hashCode * 59 + this.Username.GetHashCode();
                if (this.OrderId != null)
                    hashCode = hashCode * 59 + this.OrderId.GetHashCode();
                if (this.OrderState != null)
                    hashCode = hashCode * 59 + this.OrderState.GetHashCode();
                if (this.OrderParameters != null)
                    hashCode = hashCode * 59 + this.OrderParameters.GetHashCode();
                if (this.ClientTag != null)
                    hashCode = hashCode * 59 + this.ClientTag.GetHashCode();
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
