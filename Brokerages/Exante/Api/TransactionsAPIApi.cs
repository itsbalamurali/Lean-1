

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuantConnect.Brokerages.Exante.Client;
using QuantConnect.Brokerages.Exante.Model;

namespace QuantConnect.Brokerages.Exante.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TransactionsAPIApi 
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;


        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// get user accounts Return the list of user accounts and their statuses
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>List&lt;AccountStatus&gt;</returns>
        public List<AccountStatus> GetAccounts(string version)
        {
            ApiResponse<List<AccountStatus>> localVarResponse = GetAccountsWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get user accounts Return the list of user accounts and their statuses
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of List&lt;AccountStatus&gt;</returns>
        public ApiResponse<List<AccountStatus>> GetAccountsWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling AccountsAPIApi->GetAccounts");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<AccountStatus>>("/md/{version}/accounts", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccounts", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get user accounts Return the list of user accounts and their statuses
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;AccountStatus&gt;</returns>
        public async Task<List<AccountStatus>> GetAccountsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<AccountStatus>> localVarResponse = await GetAccountsWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get user accounts Return the list of user accounts and their statuses
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;AccountStatus&gt;)</returns>
        public async Task<ApiResponse<List<AccountStatus>>> GetAccountsWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling AccountsAPIApi->GetAccounts");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<AccountStatus>>("/md/{version}/accounts", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccounts", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }


        /// <summary>
        /// get account summary by date Return the summary for the specified account and session date
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="date">session date of the account summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <returns>AccountSummaryResponse</returns>
        public AccountSummaryResponse GetAccountSummary(string version, string id, string date, string currency)
        {
            ApiResponse<AccountSummaryResponse> localVarResponse = GetAccountSummaryWithHttpInfo(version, id, date, currency);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get account summary by date Return the summary for the specified account and session date
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="date">session date of the account summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <returns>ApiResponse of AccountSummaryResponse</returns>
        public ApiResponse<AccountSummaryResponse> GetAccountSummaryWithHttpInfo(string version, string id, string date, string currency)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling AccountSummaryAPIApi->GetAccountSummary");

            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountSummaryAPIApi->GetAccountSummary");

            // verify the required parameter 'date' is set
            if (date == null)
                throw new ApiException(400, "Missing required parameter 'date' when calling AccountSummaryAPIApi->GetAccountSummary");

            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling AccountSummaryAPIApi->GetAccountSummary");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("date", ClientUtils.ParameterToString(date)); // path parameter
            localVarRequestOptions.PathParameters.Add("currency", ClientUtils.ParameterToString(currency)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<AccountSummaryResponse>("/md/{version}/summary/{id}/{date}/{currency}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccountSummary", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get account summary by date Return the summary for the specified account and session date
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="date">session date of the account summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AccountSummaryResponse</returns>
        public async Task<AccountSummaryResponse> GetAccountSummaryAsync(string version, string id, string date, string currency, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<AccountSummaryResponse> localVarResponse = await GetAccountSummaryWithHttpInfoAsync(version, id, date, currency, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get account summary by date Return the summary for the specified account and session date
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="date">session date of the account summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AccountSummaryResponse)</returns>
        public async Task<ApiResponse<AccountSummaryResponse>> GetAccountSummaryWithHttpInfoAsync(string version, string id, string date, string currency, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling AccountSummaryAPIApi->GetAccountSummary");

            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountSummaryAPIApi->GetAccountSummary");

            // verify the required parameter 'date' is set
            if (date == null)
                throw new ApiException(400, "Missing required parameter 'date' when calling AccountSummaryAPIApi->GetAccountSummary");

            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling AccountSummaryAPIApi->GetAccountSummary");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("date", ClientUtils.ParameterToString(date)); // path parameter
            localVarRequestOptions.PathParameters.Add("currency", ClientUtils.ParameterToString(currency)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<AccountSummaryResponse>("/md/{version}/summary/{id}/{date}/{currency}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccountSummary", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get account summary Return the summary for the specified account
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <returns>AccountSummaryResponse</returns>
        public AccountSummaryResponse GetAccountSummaryWithoutDate(string version, string id, string currency)
        {
            ApiResponse<AccountSummaryResponse> localVarResponse = GetAccountSummaryWithoutDateWithHttpInfo(version, id, currency);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get account summary Return the summary for the specified account
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <returns>ApiResponse of AccountSummaryResponse</returns>
        public ApiResponse<AccountSummaryResponse> GetAccountSummaryWithoutDateWithHttpInfo(string version, string id, string currency)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling AccountSummaryAPIApi->GetAccountSummaryWithoutDate");

            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountSummaryAPIApi->GetAccountSummaryWithoutDate");

            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling AccountSummaryAPIApi->GetAccountSummaryWithoutDate");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("currency", ClientUtils.ParameterToString(currency)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<AccountSummaryResponse>("/md/{version}/summary/{id}/{currency}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccountSummaryWithoutDate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get account summary Return the summary for the specified account
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AccountSummaryResponse</returns>
        public async Task<AccountSummaryResponse> GetAccountSummaryWithoutDateAsync(string version, string id, string currency, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<AccountSummaryResponse> localVarResponse = await GetAccountSummaryWithoutDateWithHttpInfoAsync(version, id, currency, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get account summary Return the summary for the specified account
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="id">account id to get summary</param>
        /// <param name="currency">currency to convert summary</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AccountSummaryResponse)</returns>
        public async Task<ApiResponse<AccountSummaryResponse>> GetAccountSummaryWithoutDateWithHttpInfoAsync(string version, string id, string currency, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling AccountSummaryAPIApi->GetAccountSummaryWithoutDate");

            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountSummaryAPIApi->GetAccountSummaryWithoutDate");

            // verify the required parameter 'currency' is set
            if (currency == null)
                throw new ApiException(400, "Missing required parameter 'currency' when calling AccountSummaryAPIApi->GetAccountSummaryWithoutDate");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("currency", ClientUtils.ParameterToString(currency)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<AccountSummaryResponse>("/md/{version}/summary/{id}/{currency}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccountSummaryWithoutDate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }


        /// <summary>
        /// get daily changes Return the list of daily changes for requested instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">symbol or comma-delimited symbols to request daily change</param>
        /// <returns>List&lt;DailyChangeResponse&gt;</returns>
        public List<DailyChangeResponse> GetDailyChange(string version, string symbolId)
        {
            ApiResponse<List<DailyChangeResponse>> localVarResponse = GetDailyChangeWithHttpInfo(version, symbolId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get daily changes Return the list of daily changes for requested instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">symbol or comma-delimited symbols to request daily change</param>
        /// <returns>ApiResponse of List&lt;DailyChangeResponse&gt;</returns>
        public ApiResponse<List<DailyChangeResponse>> GetDailyChangeWithHttpInfo(string version, string symbolId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling DailyChangeAPIApi->GetDailyChange");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling DailyChangeAPIApi->GetDailyChange");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<DailyChangeResponse>>("/md/{version}/change/{symbolId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDailyChange", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get daily changes Return the list of daily changes for requested instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">symbol or comma-delimited symbols to request daily change</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;DailyChangeResponse&gt;</returns>
        public async Task<List<DailyChangeResponse>> GetDailyChangeAsync(string version, string symbolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<DailyChangeResponse>> localVarResponse = await GetDailyChangeWithHttpInfoAsync(version, symbolId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get daily changes Return the list of daily changes for requested instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">symbol or comma-delimited symbols to request daily change</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;DailyChangeResponse&gt;)</returns>
        public async Task<ApiResponse<List<DailyChangeResponse>>> GetDailyChangeWithHttpInfoAsync(string version, string symbolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling DailyChangeAPIApi->GetDailyChange");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling DailyChangeAPIApi->GetDailyChange");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<DailyChangeResponse>>("/md/{version}/change/{symbolId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDailyChange", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get all daily changes Return the list of daily changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>List&lt;DailyChangeResponse&gt;</returns>
        public List<DailyChangeResponse> GetDailyChanges(string version)
        {
            ApiResponse<List<DailyChangeResponse>> localVarResponse = GetDailyChangesWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get all daily changes Return the list of daily changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of List&lt;DailyChangeResponse&gt;</returns>
        public ApiResponse<List<DailyChangeResponse>> GetDailyChangesWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling DailyChangeAPIApi->GetDailyChanges");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<DailyChangeResponse>>("/md/{version}/change", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDailyChanges", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get all daily changes Return the list of daily changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;DailyChangeResponse&gt;</returns>
        public async Task<List<DailyChangeResponse>> GetDailyChangesAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<DailyChangeResponse>> localVarResponse = await GetDailyChangesWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get all daily changes Return the list of daily changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;DailyChangeResponse&gt;)</returns>
        public async Task<ApiResponse<List<DailyChangeResponse>>> GetDailyChangesWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling DailyChangeAPIApi->GetDailyChanges");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<DailyChangeResponse>>("/md/{version}/change", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDailyChanges", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instruments by exchange Return the requested exchange financial instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="exchangeId">exchange id to search instruments</param>
        /// <returns>List&lt;SymbolInfoResponse&gt;</returns>
        public List<SymbolInfoResponse> GetExchangeSymbols(string version, string exchangeId)
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = GetExchangeSymbolsWithHttpInfo(version, exchangeId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instruments by exchange Return the requested exchange financial instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="exchangeId">exchange id to search instruments</param>
        /// <returns>ApiResponse of List&lt;SymbolInfoResponse&gt;</returns>
        public ApiResponse<List<SymbolInfoResponse>> GetExchangeSymbolsWithHttpInfo(string version, string exchangeId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetExchangeSymbols");

            // verify the required parameter 'exchangeId' is set
            if (exchangeId == null)
                throw new ApiException(400, "Missing required parameter 'exchangeId' when calling SymbolsAPIApi->GetExchangeSymbols");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("exchangeId", ClientUtils.ParameterToString(exchangeId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<SymbolInfoResponse>>("/md/{version}/exchanges/{exchangeId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExchangeSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instruments by exchange Return the requested exchange financial instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="exchangeId">exchange id to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;SymbolInfoResponse&gt;</returns>
        public async Task<List<SymbolInfoResponse>> GetExchangeSymbolsAsync(string version, string exchangeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = await GetExchangeSymbolsWithHttpInfoAsync(version, exchangeId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instruments by exchange Return the requested exchange financial instruments
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="exchangeId">exchange id to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;SymbolInfoResponse&gt;)</returns>
        public async Task<ApiResponse<List<SymbolInfoResponse>>> GetExchangeSymbolsWithHttpInfoAsync(string version, string exchangeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetExchangeSymbols");

            // verify the required parameter 'exchangeId' is set
            if (exchangeId == null)
                throw new ApiException(400, "Missing required parameter 'exchangeId' when calling SymbolsAPIApi->GetExchangeSymbols");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("exchangeId", ClientUtils.ParameterToString(exchangeId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<SymbolInfoResponse>>("/md/{version}/exchanges/{exchangeId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExchangeSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get exchanges Return list of exchanges
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>List&lt;ExchangeResponse&gt;</returns>
        public List<ExchangeResponse> GetExchanges(string version)
        {
            ApiResponse<List<ExchangeResponse>> localVarResponse = GetExchangesWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get exchanges Return list of exchanges
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of List&lt;ExchangeResponse&gt;</returns>
        public ApiResponse<List<ExchangeResponse>> GetExchangesWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetExchanges");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<ExchangeResponse>>("/md/{version}/exchanges", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExchanges", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }


        /// <summary>
        /// get exchanges Return list of exchanges
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ExchangeResponse&gt;</returns>
        public async Task<List<ExchangeResponse>> GetExchangesAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<ExchangeResponse>> localVarResponse = await GetExchangesWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get exchanges Return list of exchanges
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ExchangeResponse&gt;)</returns>
        public async Task<ApiResponse<List<ExchangeResponse>>> GetExchangesWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetExchanges");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<ExchangeResponse>>("/md/{version}/exchanges", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetExchanges", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get nearest expiration in group Return financial instrument which has the nearest expiration in the group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <returns>SymbolInfoResponse</returns>
        public SymbolInfoResponse GetGroupNearestSymbol(string version, string groupId)
        {
            ApiResponse<SymbolInfoResponse> localVarResponse = GetGroupNearestSymbolWithHttpInfo(version, groupId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get nearest expiration in group Return financial instrument which has the nearest expiration in the group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <returns>ApiResponse of SymbolInfoResponse</returns>
        public ApiResponse<SymbolInfoResponse> GetGroupNearestSymbolWithHttpInfo(string version, string groupId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetGroupNearestSymbol");

            // verify the required parameter 'groupId' is set
            if (groupId == null)
                throw new ApiException(400, "Missing required parameter 'groupId' when calling SymbolsAPIApi->GetGroupNearestSymbol");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("groupId", ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<SymbolInfoResponse>("/md/{version}/groups/{groupId}/nearest", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroupNearestSymbol", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get nearest expiration in group Return financial instrument which has the nearest expiration in the group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of SymbolInfoResponse</returns>
        public async Task<SymbolInfoResponse> GetGroupNearestSymbolAsync(string version, string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<SymbolInfoResponse> localVarResponse = await GetGroupNearestSymbolWithHttpInfoAsync(version, groupId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get nearest expiration in group Return financial instrument which has the nearest expiration in the group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (SymbolInfoResponse)</returns>
        public async Task<ApiResponse<SymbolInfoResponse>> GetGroupNearestSymbolWithHttpInfoAsync(string version, string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetGroupNearestSymbol");

            // verify the required parameter 'groupId' is set
            if (groupId == null)
                throw new ApiException(400, "Missing required parameter 'groupId' when calling SymbolsAPIApi->GetGroupNearestSymbol");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("groupId", ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<SymbolInfoResponse>("/md/{version}/groups/{groupId}/nearest", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroupNearestSymbol", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instruments by group Return financial instruments which belong to specified group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <returns>List&lt;SymbolInfoResponse&gt;</returns>
        public List<SymbolInfoResponse> GetGroupSymbols(string version, string groupId)
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = GetGroupSymbolsWithHttpInfo(version, groupId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instruments by group Return financial instruments which belong to specified group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <returns>ApiResponse of List&lt;SymbolInfoResponse&gt;</returns>
        public ApiResponse<List<SymbolInfoResponse>> GetGroupSymbolsWithHttpInfo(string version, string groupId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetGroupSymbols");

            // verify the required parameter 'groupId' is set
            if (groupId == null)
                throw new ApiException(400, "Missing required parameter 'groupId' when calling SymbolsAPIApi->GetGroupSymbols");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("groupId", ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<SymbolInfoResponse>>("/md/{version}/groups/{groupId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroupSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instruments by group Return financial instruments which belong to specified group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;SymbolInfoResponse&gt;</returns>
        public async Task<List<SymbolInfoResponse>> GetGroupSymbolsAsync(string version, string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = await GetGroupSymbolsWithHttpInfoAsync(version, groupId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instruments by group Return financial instruments which belong to specified group
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="groupId">group id to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;SymbolInfoResponse&gt;)</returns>
        public async Task<ApiResponse<List<SymbolInfoResponse>>> GetGroupSymbolsWithHttpInfoAsync(string version, string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetGroupSymbols");

            // verify the required parameter 'groupId' is set
            if (groupId == null)
                throw new ApiException(400, "Missing required parameter 'groupId' when calling SymbolsAPIApi->GetGroupSymbols");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("groupId", ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<SymbolInfoResponse>>("/md/{version}/groups/{groupId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroupSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument groups Return list of available instrument groups
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>List&lt;GroupResponse&gt;</returns>
        public List<GroupResponse> GetGroups(string version)
        {
            ApiResponse<List<GroupResponse>> localVarResponse = GetGroupsWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument groups Return list of available instrument groups
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of List&lt;GroupResponse&gt;</returns>
        public ApiResponse<List<GroupResponse>> GetGroupsWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetGroups");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<GroupResponse>>("/md/{version}/groups", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroups", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument groups Return list of available instrument groups
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;GroupResponse&gt;</returns>
        public async Task<List<GroupResponse>> GetGroupsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<GroupResponse>> localVarResponse = await GetGroupsWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument groups Return list of available instrument groups
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;GroupResponse&gt;)</returns>
        public async Task<ApiResponse<List<GroupResponse>>> GetGroupsWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetGroups");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<GroupResponse>>("/md/{version}/groups", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetGroups", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument Return instrument available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <returns>SymbolInfoResponse</returns>
        public SymbolInfoResponse GetSymbol(string version, string symbolId)
        {
            ApiResponse<SymbolInfoResponse> localVarResponse = GetSymbolWithHttpInfo(version, symbolId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument Return instrument available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <returns>ApiResponse of SymbolInfoResponse</returns>
        public ApiResponse<SymbolInfoResponse> GetSymbolWithHttpInfo(string version, string symbolId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbol");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling SymbolsAPIApi->GetSymbol");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<SymbolInfoResponse>("/md/{version}/symbols/{symbolId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbol", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument Return instrument available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of SymbolInfoResponse</returns>
        public async Task<SymbolInfoResponse> GetSymbolAsync(string version, string symbolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<SymbolInfoResponse> localVarResponse = await GetSymbolWithHttpInfoAsync(version, symbolId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument Return instrument available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (SymbolInfoResponse)</returns>
        public async Task<ApiResponse<SymbolInfoResponse>> GetSymbolWithHttpInfoAsync(string version, string symbolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbol");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling SymbolsAPIApi->GetSymbol");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<SymbolInfoResponse>("/md/{version}/symbols/{symbolId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbol", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument schedule Return financial schedule for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="types">show available order types (optional)</param>
        /// <returns>ScheduleResponse</returns>
        public ScheduleResponse GetSymbolSchedule(string version, string symbolId, bool? types = default(bool?))
        {
            ApiResponse<ScheduleResponse> localVarResponse = GetSymbolScheduleWithHttpInfo(version, symbolId, types);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument schedule Return financial schedule for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="types">show available order types (optional)</param>
        /// <returns>ApiResponse of ScheduleResponse</returns>
        public ApiResponse<ScheduleResponse> GetSymbolScheduleWithHttpInfo(string version, string symbolId, bool? types = default(bool?))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbolSchedule");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling SymbolsAPIApi->GetSymbolSchedule");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter
            if (types != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "types", types));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<ScheduleResponse>("/md/{version}/symbols/{symbolId}/schedule", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbolSchedule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument schedule Return financial schedule for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="types">show available order types (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScheduleResponse</returns>
        public async Task<ScheduleResponse> GetSymbolScheduleAsync(string version, string symbolId, bool? types = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<ScheduleResponse> localVarResponse = await GetSymbolScheduleWithHttpInfoAsync(version, symbolId, types, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument schedule Return financial schedule for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="types">show available order types (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScheduleResponse)</returns>
        public async Task<ApiResponse<ScheduleResponse>> GetSymbolScheduleWithHttpInfoAsync(string version, string symbolId, bool? types = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbolSchedule");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling SymbolsAPIApi->GetSymbolSchedule");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter
            if (types != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "types", types));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ScheduleResponse>("/md/{version}/symbols/{symbolId}/schedule", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbolSchedule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument specification Return additional parameters for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <returns>RequirementsResponse</returns>
        public RequirementsResponse GetSymbolSpecification(string version, string symbolId)
        {
            ApiResponse<RequirementsResponse> localVarResponse = GetSymbolSpecificationWithHttpInfo(version, symbolId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument specification Return additional parameters for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <returns>ApiResponse of RequirementsResponse</returns>
        public ApiResponse<RequirementsResponse> GetSymbolSpecificationWithHttpInfo(string version, string symbolId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbolSpecification");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling SymbolsAPIApi->GetSymbolSpecification");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<RequirementsResponse>("/md/{version}/symbols/{symbolId}/specification", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbolSpecification", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument specification Return additional parameters for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RequirementsResponse</returns>
        public async Task<RequirementsResponse> GetSymbolSpecificationAsync(string version, string symbolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<RequirementsResponse> localVarResponse = await GetSymbolSpecificationWithHttpInfoAsync(version, symbolId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument specification Return additional parameters for requested instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">instrument id to search</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RequirementsResponse)</returns>
        public async Task<ApiResponse<RequirementsResponse>> GetSymbolSpecificationWithHttpInfoAsync(string version, string symbolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbolSpecification");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling SymbolsAPIApi->GetSymbolSpecification");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolId", ClientUtils.ParameterToString(symbolId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<RequirementsResponse>("/md/{version}/symbols/{symbolId}/specification", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbolSpecification", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument list Return list of instruments available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>List&lt;SymbolInfoResponse&gt;</returns>
        public List<SymbolInfoResponse> GetSymbols(string version)
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = GetSymbolsWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument list Return list of instruments available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of List&lt;SymbolInfoResponse&gt;</returns>
        public ApiResponse<List<SymbolInfoResponse>> GetSymbolsWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbols");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<SymbolInfoResponse>>("/md/{version}/symbols", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument list Return list of instruments available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;SymbolInfoResponse&gt;</returns>
        public async Task<List<SymbolInfoResponse>> GetSymbolsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = await GetSymbolsWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument list Return list of instruments available for authorized user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;SymbolInfoResponse&gt;)</returns>
        public async Task<ApiResponse<List<SymbolInfoResponse>>> GetSymbolsWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetSymbols");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<SymbolInfoResponse>>("/md/{version}/symbols", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instruments by type Return financial instruments of the requrested type
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolType">type name to search instruments</param>
        /// <returns>List&lt;SymbolInfoResponse&gt;</returns>
        public List<SymbolInfoResponse> GetTypeSymbols(string version, string symbolType)
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = GetTypeSymbolsWithHttpInfo(version, symbolType);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instruments by type Return financial instruments of the requrested type
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolType">type name to search instruments</param>
        /// <returns>ApiResponse of List&lt;SymbolInfoResponse&gt;</returns>
        public ApiResponse<List<SymbolInfoResponse>> GetTypeSymbolsWithHttpInfo(string version, string symbolType)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetTypeSymbols");

            // verify the required parameter 'symbolType' is set
            if (symbolType == null)
                throw new ApiException(400, "Missing required parameter 'symbolType' when calling SymbolsAPIApi->GetTypeSymbols");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolType", ClientUtils.ParameterToString(symbolType)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<SymbolInfoResponse>>("/md/{version}/types/{symbolType}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTypeSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instruments by type Return financial instruments of the requrested type
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolType">type name to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;SymbolInfoResponse&gt;</returns>
        public async Task<List<SymbolInfoResponse>> GetTypeSymbolsAsync(string version, string symbolType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<SymbolInfoResponse>> localVarResponse = await GetTypeSymbolsWithHttpInfoAsync(version, symbolType, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instruments by type Return financial instruments of the requrested type
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolType">type name to search instruments</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;SymbolInfoResponse&gt;)</returns>
        public async Task<ApiResponse<List<SymbolInfoResponse>>> GetTypeSymbolsWithHttpInfoAsync(string version, string symbolType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetTypeSymbols");

            // verify the required parameter 'symbolType' is set
            if (symbolType == null)
                throw new ApiException(400, "Missing required parameter 'symbolType' when calling SymbolsAPIApi->GetTypeSymbols");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("symbolType", ClientUtils.ParameterToString(symbolType)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<SymbolInfoResponse>>("/md/{version}/types/{symbolType}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTypeSymbols", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument types Return list of known instrument types
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>List&lt;TypeDescriptor&gt;</returns>
        public List<TypeDescriptor> GetTypes(string version)
        {
            ApiResponse<List<TypeDescriptor>> localVarResponse = GetTypesWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument types Return list of known instrument types
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of List&lt;TypeDescriptor&gt;</returns>
        public ApiResponse<List<TypeDescriptor>> GetTypesWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetTypes");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<TypeDescriptor>>("/md/{version}/types", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTypes", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get instrument types Return list of known instrument types
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;TypeDescriptor&gt;</returns>
        public async Task<List<TypeDescriptor>> GetTypesAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<TypeDescriptor>> localVarResponse = await GetTypesWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get instrument types Return list of known instrument types
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;TypeDescriptor&gt;)</returns>
        public async Task<ApiResponse<List<TypeDescriptor>>> GetTypesWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling SymbolsAPIApi->GetTypes");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<TypeDescriptor>>("/md/{version}/types", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTypes", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }


        /// <summary>
        /// get active orders Return the list of active trading orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <param name="instrument">the instrument identifier, required api 2.0 only (optional)</param>
        /// <param name="symbolId">the instrument identifier, required api 3.0 only (optional)</param>
        /// <returns>List&lt;ApiOrder&gt;</returns>
        public List<ApiOrder> GetActiveOrders(string version, string limit = default(string), string account = default(string), string accountId = default(string), string instrument = default(string), string symbolId = default(string))
        {
            ApiResponse<List<ApiOrder>> localVarResponse = GetActiveOrdersWithHttpInfo(version, limit, account, accountId, instrument, symbolId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get active orders Return the list of active trading orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <param name="instrument">the instrument identifier, required api 2.0 only (optional)</param>
        /// <param name="symbolId">the instrument identifier, required api 3.0 only (optional)</param>
        /// <returns>ApiResponse of List&lt;ApiOrder&gt;</returns>
        public ApiResponse<List<ApiOrder>> GetActiveOrdersWithHttpInfo(string version, string limit = default(string), string account = default(string), string accountId = default(string), string instrument = default(string), string symbolId = default(string))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->GetActiveOrders");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (account != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "account", account));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (instrument != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "instrument", instrument));
            }
            if (symbolId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "symbolId", symbolId));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<ApiOrder>>("/trade/{version}/orders/active", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetActiveOrders", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get active orders Return the list of active trading orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <param name="instrument">the instrument identifier, required api 2.0 only (optional)</param>
        /// <param name="symbolId">the instrument identifier, required api 3.0 only (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ApiOrder&gt;</returns>
        public async Task<List<ApiOrder>> GetActiveOrdersAsync(string version, string limit = default(string), string account = default(string), string accountId = default(string), string instrument = default(string), string symbolId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<ApiOrder>> localVarResponse = await GetActiveOrdersWithHttpInfoAsync(version, limit, account, accountId, instrument, symbolId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get active orders Return the list of active trading orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <param name="instrument">the instrument identifier, required api 2.0 only (optional)</param>
        /// <param name="symbolId">the instrument identifier, required api 3.0 only (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ApiOrder&gt;)</returns>
        public async Task<ApiResponse<List<ApiOrder>>> GetActiveOrdersWithHttpInfoAsync(string version, string limit = default(string), string account = default(string), string accountId = default(string), string instrument = default(string), string symbolId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->GetActiveOrders");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (account != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "account", account));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (instrument != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "instrument", instrument));
            }
            if (symbolId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "symbolId", symbolId));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<ApiOrder>>("/trade/{version}/orders/active", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetActiveOrders", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get order Return the order with specified identifier
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <returns>ApiOrder</returns>
        public ApiOrder GetOrder(string version, string orderId)
        {
            ApiResponse<ApiOrder> localVarResponse = GetOrderWithHttpInfo(version, orderId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get order Return the order with specified identifier
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <returns>ApiResponse of ApiOrder</returns>
        public ApiResponse<ApiOrder> GetOrderWithHttpInfo(string version, string orderId)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->GetOrder");

            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersAPIApi->GetOrder");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("orderId", ClientUtils.ParameterToString(orderId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiOrder>("/trade/{version}/orders/{orderId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOrder", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get order Return the order with specified identifier
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiOrder</returns>
        public async Task<ApiOrder> GetOrderAsync(string version, string orderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<ApiOrder> localVarResponse = await GetOrderWithHttpInfoAsync(version, orderId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get order Return the order with specified identifier
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiOrder)</returns>
        public async Task<ApiResponse<ApiOrder>> GetOrderWithHttpInfoAsync(string version, string orderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->GetOrder");

            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersAPIApi->GetOrder");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("orderId", ClientUtils.ParameterToString(orderId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiOrder>("/trade/{version}/orders/{orderId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOrder", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get historical orders Return the list of historical orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="from">the start date (optional)</param>
        /// <param name="to">the stop date (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <returns>List&lt;ApiOrder&gt;</returns>
        public List<ApiOrder> GetOrders(string version, string limit = default(string), string from = default(string), string to = default(string), string account = default(string), string accountId = default(string))
        {
            ApiResponse<List<ApiOrder>> localVarResponse = GetOrdersWithHttpInfo(version, limit, from, to, account, accountId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get historical orders Return the list of historical orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="from">the start date (optional)</param>
        /// <param name="to">the stop date (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <returns>ApiResponse of List&lt;ApiOrder&gt;</returns>
        public ApiResponse<List<ApiOrder>> GetOrdersWithHttpInfo(string version, string limit = default(string), string from = default(string), string to = default(string), string account = default(string), string accountId = default(string))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->GetOrders");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (from != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "from", from));
            }
            if (to != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "to", to));
            }
            if (account != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "account", account));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<ApiOrder>>("/trade/{version}/orders", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOrders", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get historical orders Return the list of historical orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="from">the start date (optional)</param>
        /// <param name="to">the stop date (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ApiOrder&gt;</returns>
        public async Task<List<ApiOrder>> GetOrdersAsync(string version, string limit = default(string), string from = default(string), string to = default(string), string account = default(string), string accountId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<ApiOrder>> localVarResponse = await GetOrdersWithHttpInfoAsync(version, limit, from, to, account, accountId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get historical orders Return the list of historical orders
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="limit">the limit for max items of the order list (optional)</param>
        /// <param name="from">the start date (optional)</param>
        /// <param name="to">the stop date (optional)</param>
        /// <param name="account">the user account list, required api 2.0 only (optional)</param>
        /// <param name="accountId">the user account list, required api 3.0 only (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ApiOrder&gt;)</returns>
        public async Task<ApiResponse<List<ApiOrder>>> GetOrdersWithHttpInfoAsync(string version, string limit = default(string), string from = default(string), string to = default(string), string account = default(string), string accountId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->GetOrders");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (from != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "from", from));
            }
            if (to != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "to", to));
            }
            if (account != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "account", account));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<ApiOrder>>("/trade/{version}/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOrders", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// modify order Replace or cancel trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <param name="modifyParameters">modification parameters</param>
        /// <returns>ApiOrder</returns>
        public ApiOrder ModifyOrder(string version, string orderId, ModifyParameters modifyParameters)
        {
            ApiResponse<ApiOrder> localVarResponse = ModifyOrderWithHttpInfo(version, orderId, modifyParameters);
            return localVarResponse.Data;
        }

        /// <summary>
        /// modify order Replace or cancel trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <param name="modifyParameters">modification parameters</param>
        /// <returns>ApiResponse of ApiOrder</returns>
        public ApiResponse<ApiOrder> ModifyOrderWithHttpInfo(string version, string orderId, ModifyParameters modifyParameters)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->ModifyOrder");

            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersAPIApi->ModifyOrder");

            // verify the required parameter 'modifyParameters' is set
            if (modifyParameters == null)
                throw new ApiException(400, "Missing required parameter 'modifyParameters' when calling OrdersAPIApi->ModifyOrder");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("orderId", ClientUtils.ParameterToString(orderId)); // path parameter
            localVarRequestOptions.Data = modifyParameters;


            // make the HTTP request
            var localVarResponse = this.Client.Post<ApiOrder>("/trade/{version}/orders/{orderId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ModifyOrder", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// modify order Replace or cancel trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <param name="modifyParameters">modification parameters</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiOrder</returns>
        public async Task<ApiOrder> ModifyOrderAsync(string version, string orderId, ModifyParameters modifyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<ApiOrder> localVarResponse = await ModifyOrderWithHttpInfoAsync(version, orderId, modifyParameters, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// modify order Replace or cancel trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="orderId">the order identifier</param>
        /// <param name="modifyParameters">modification parameters</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiOrder)</returns>
        public async Task<ApiResponse<ApiOrder>> ModifyOrderWithHttpInfoAsync(string version, string orderId, ModifyParameters modifyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->ModifyOrder");

            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersAPIApi->ModifyOrder");

            // verify the required parameter 'modifyParameters' is set
            if (modifyParameters == null)
                throw new ApiException(400, "Missing required parameter 'modifyParameters' when calling OrdersAPIApi->ModifyOrder");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.PathParameters.Add("orderId", ClientUtils.ParameterToString(orderId)); // path parameter
            localVarRequestOptions.Data = modifyParameters;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiOrder>("/trade/{version}/orders/{orderId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ModifyOrder", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// place order Place new trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="placeParameters">order parameters</param>
        /// <returns>ApiOrder</returns>
        public ApiOrder PlaceOrder(string version, PlaceParameters placeParameters)
        {
            ApiResponse<ApiOrder> localVarResponse = PlaceOrderWithHttpInfo(version, placeParameters);
            return localVarResponse.Data;
        }

        /// <summary>
        /// place order Place new trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="placeParameters">order parameters</param>
        /// <returns>ApiResponse of ApiOrder</returns>
        public ApiResponse<ApiOrder> PlaceOrderWithHttpInfo(string version, PlaceParameters placeParameters)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->PlaceOrder");

            // verify the required parameter 'placeParameters' is set
            if (placeParameters == null)
                throw new ApiException(400, "Missing required parameter 'placeParameters' when calling OrdersAPIApi->PlaceOrder");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.Data = placeParameters;


            // make the HTTP request
            var localVarResponse = this.Client.Post<ApiOrder>("/trade/{version}/orders", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PlaceOrder", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// place order Place new trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="placeParameters">order parameters</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiOrder</returns>
        public async Task<ApiOrder> PlaceOrderAsync(string version, PlaceParameters placeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<ApiOrder> localVarResponse = await PlaceOrderWithHttpInfoAsync(version, placeParameters, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// place order Place new trading order
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="placeParameters">order parameters</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiOrder)</returns>
        public async Task<ApiResponse<ApiOrder>> PlaceOrderWithHttpInfoAsync(string version, PlaceParameters placeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersAPIApi->PlaceOrder");

            // verify the required parameter 'placeParameters' is set
            if (placeParameters == null)
                throw new ApiException(400, "Missing required parameter 'placeParameters' when calling OrdersAPIApi->PlaceOrder");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            localVarRequestOptions.Data = placeParameters;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiOrder>("/trade/{version}/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PlaceOrder", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }


        /// <summary>
        /// trades stream Trades updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>OneOfTradeHeartbeat</returns>
        public OneOfTradeHeartbeat TradesHttp(string version)
        {
            ApiResponse<OneOfTradeHeartbeat> localVarResponse = TradesHttpWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// trades stream Trades updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of OneOfTradeHeartbeat</returns>
        public ApiResponse<OneOfTradeHeartbeat> TradesHttpWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling TradesStreamAPIApi->TradesHttp");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/x-json-stream"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<OneOfTradeHeartbeat>("/trade/{version}/stream/trades", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("TradesHttp", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// trades stream Trades updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfTradeHeartbeat</returns>
        public async Task<OneOfTradeHeartbeat> TradesHttpAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<OneOfTradeHeartbeat> localVarResponse = await TradesHttpWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// trades stream Trades updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfTradeHeartbeat)</returns>
        public async Task<ApiResponse<OneOfTradeHeartbeat>> TradesHttpWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling TradesStreamAPIApi->TradesHttp");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/x-json-stream"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfTradeHeartbeat>("/trade/{version}/stream/trades", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("TradesHttp", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// trades ws stream Trades updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>OneOfWsTradeWsHeartbeat</returns>
        public OneOfWsTradeWsHeartbeat TradesWs(string version)
        {
            ApiResponse<OneOfWsTradeWsHeartbeat> localVarResponse = TradesWsWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// trades ws stream Trades updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of OneOfWsTradeWsHeartbeat</returns>
        public ApiResponse<OneOfWsTradeWsHeartbeat> TradesWsWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling TradesStreamAPIApi->TradesWs");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/x-json-stream"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<OneOfWsTradeWsHeartbeat>("/trade/{version}/ws/trades", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("TradesWs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// trades ws stream Trades updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfWsTradeWsHeartbeat</returns>
        public async Task<OneOfWsTradeWsHeartbeat> TradesWsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<OneOfWsTradeWsHeartbeat> localVarResponse = await TradesWsWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// trades ws stream Trades updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfWsTradeWsHeartbeat)</returns>
        public async Task<ApiResponse<OneOfWsTradeWsHeartbeat>> TradesWsWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling TradesStreamAPIApi->TradesWs");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/x-json-stream"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfWsTradeWsHeartbeat>("/trade/{version}/ws/trades", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("TradesWs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get transactions Return the list of transactions with the specified filter
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="uuid">transaction UUID (optional)</param>
        /// <param name="accountId">transaction account ID (optional)</param>
        /// <param name="symbolId">filter transactions by the financial instrument (optional)</param>
        /// <param name="asset">filter transactions by the asset (optional)</param>
        /// <param name="operationType">transaction type or comma-separated list of transaction types to filter (optional)</param>
        /// <param name="offset">offset to list transactions (optional)</param>
        /// <param name="limit">limit response to this amount of transactions (optional)</param>
        /// <param name="order">order transactions by descending (DESC) or ascending (ASC) (optional, default to ASC)</param>
        /// <param name="fromDate">starting timestamp of transactions in ISO format (optional)</param>
        /// <param name="toDate">ending timestamp of transactions in ISO format (optional)</param>
        /// <param name="orderId">filter transactions by the order id (optional)</param>
        /// <param name="orderPos">filter transactions by the position in the order (optional)</param>
        /// <returns>List&lt;TransactionResponse&gt;</returns>
        public List<TransactionResponse> GetTransactions(string version, Guid? uuid = default(Guid?), string accountId = default(string), string symbolId = default(string), string asset = default(string), string operationType = default(string), decimal? offset = default(decimal?), decimal? limit = default(decimal?), string order = default(string), string fromDate = default(string), string toDate = default(string), Guid? orderId = default(Guid?), decimal? orderPos = default(decimal?))
        {
            ApiResponse<List<TransactionResponse>> localVarResponse = GetTransactionsWithHttpInfo(version, uuid, accountId, symbolId, asset, operationType, offset, limit, order, fromDate, toDate, orderId, orderPos);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get transactions Return the list of transactions with the specified filter
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="uuid">transaction UUID (optional)</param>
        /// <param name="accountId">transaction account ID (optional)</param>
        /// <param name="symbolId">filter transactions by the financial instrument (optional)</param>
        /// <param name="asset">filter transactions by the asset (optional)</param>
        /// <param name="operationType">transaction type or comma-separated list of transaction types to filter (optional)</param>
        /// <param name="offset">offset to list transactions (optional)</param>
        /// <param name="limit">limit response to this amount of transactions (optional)</param>
        /// <param name="order">order transactions by descending (DESC) or ascending (ASC) (optional, default to ASC)</param>
        /// <param name="fromDate">starting timestamp of transactions in ISO format (optional)</param>
        /// <param name="toDate">ending timestamp of transactions in ISO format (optional)</param>
        /// <param name="orderId">filter transactions by the order id (optional)</param>
        /// <param name="orderPos">filter transactions by the position in the order (optional)</param>
        /// <returns>ApiResponse of List&lt;TransactionResponse&gt;</returns>
        public ApiResponse<List<TransactionResponse>> GetTransactionsWithHttpInfo(string version, Guid? uuid = default(Guid?), string accountId = default(string), string symbolId = default(string), string asset = default(string), string operationType = default(string), decimal? offset = default(decimal?), decimal? limit = default(decimal?), string order = default(string), string fromDate = default(string), string toDate = default(string), Guid? orderId = default(Guid?), decimal? orderPos = default(decimal?))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling TransactionsAPIApi->GetTransactions");

            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            if (uuid != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "uuid", uuid));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (symbolId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "symbolId", symbolId));
            }
            if (asset != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "asset", asset));
            }
            if (operationType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "operationType", operationType));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (order != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "order", order));
            }
            if (fromDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "fromDate", fromDate));
            }
            if (toDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "toDate", toDate));
            }
            if (orderId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "orderId", orderId));
            }
            if (orderPos != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "orderPos", orderPos));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<TransactionResponse>>("/md/{version}/transactions", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTransactions", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get transactions Return the list of transactions with the specified filter
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="uuid">transaction UUID (optional)</param>
        /// <param name="accountId">transaction account ID (optional)</param>
        /// <param name="symbolId">filter transactions by the financial instrument (optional)</param>
        /// <param name="asset">filter transactions by the asset (optional)</param>
        /// <param name="operationType">transaction type or comma-separated list of transaction types to filter (optional)</param>
        /// <param name="offset">offset to list transactions (optional)</param>
        /// <param name="limit">limit response to this amount of transactions (optional)</param>
        /// <param name="order">order transactions by descending (DESC) or ascending (ASC) (optional, default to ASC)</param>
        /// <param name="fromDate">starting timestamp of transactions in ISO format (optional)</param>
        /// <param name="toDate">ending timestamp of transactions in ISO format (optional)</param>
        /// <param name="orderId">filter transactions by the order id (optional)</param>
        /// <param name="orderPos">filter transactions by the position in the order (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;TransactionResponse&gt;</returns>
        public async Task<List<TransactionResponse>> GetTransactionsAsync(string version, Guid? uuid = default(Guid?), string accountId = default(string), string symbolId = default(string), string asset = default(string), string operationType = default(string), decimal? offset = default(decimal?), decimal? limit = default(decimal?), string order = default(string), string fromDate = default(string), string toDate = default(string), Guid? orderId = default(Guid?), decimal? orderPos = default(decimal?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<TransactionResponse>> localVarResponse = await GetTransactionsWithHttpInfoAsync(version, uuid, accountId, symbolId, asset, operationType, offset, limit, order, fromDate, toDate, orderId, orderPos, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get transactions Return the list of transactions with the specified filter
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="uuid">transaction UUID (optional)</param>
        /// <param name="accountId">transaction account ID (optional)</param>
        /// <param name="symbolId">filter transactions by the financial instrument (optional)</param>
        /// <param name="asset">filter transactions by the asset (optional)</param>
        /// <param name="operationType">transaction type or comma-separated list of transaction types to filter (optional)</param>
        /// <param name="offset">offset to list transactions (optional)</param>
        /// <param name="limit">limit response to this amount of transactions (optional)</param>
        /// <param name="order">order transactions by descending (DESC) or ascending (ASC) (optional, default to ASC)</param>
        /// <param name="fromDate">starting timestamp of transactions in ISO format (optional)</param>
        /// <param name="toDate">ending timestamp of transactions in ISO format (optional)</param>
        /// <param name="orderId">filter transactions by the order id (optional)</param>
        /// <param name="orderPos">filter transactions by the position in the order (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;TransactionResponse&gt;)</returns>
        public async Task<ApiResponse<List<TransactionResponse>>> GetTransactionsWithHttpInfoAsync(string version, Guid? uuid = default(Guid?), string accountId = default(string), string symbolId = default(string), string asset = default(string), string operationType = default(string), decimal? offset = default(decimal?), decimal? limit = default(decimal?), string order = default(string), string fromDate = default(string), string toDate = default(string), Guid? orderId = default(Guid?), decimal? orderPos = default(decimal?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling TransactionsAPIApi->GetTransactions");


            RequestOptions localVarRequestOptions = new RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };


            var localVarContentType = ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("version", ClientUtils.ParameterToString(version)); // path parameter
            if (uuid != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "uuid", uuid));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (symbolId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "symbolId", symbolId));
            }
            if (asset != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "asset", asset));
            }
            if (operationType != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "operationType", operationType));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (order != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "order", order));
            }
            if (fromDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "fromDate", fromDate));
            }
            if (toDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "toDate", toDate));
            }
            if (orderId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "orderId", orderId));
            }
            if (orderPos != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "orderPos", orderPos));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<TransactionResponse>>("/md/{version}/transactions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTransactions", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
