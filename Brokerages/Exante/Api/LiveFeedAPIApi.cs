

using System;
using System.Collections.Generic;

using QuantConnect.Brokerages.Exante.Client;
using QuantConnect.Brokerages.Exante.Model;

namespace QuantConnect.Brokerages.Exante.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class LiveFeedAPIApi 
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveFeedAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LiveFeedAPIApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveFeedAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LiveFeedAPIApi(String basePath)
        {
            this.Configuration = Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new Configuration { BasePath = basePath }
            );
            this.Client = new ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveFeedAPIApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LiveFeedAPIApi(Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Configuration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveFeedAPIApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public LiveFeedAPIApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

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
        /// get last quote Return the last quote for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <returns>List&lt;QuoteResponse&gt;</returns>
        public List<QuoteResponse> GetQuoteLast(string version, string symbolIds, string level = default(string))
        {
            ApiResponse<List<QuoteResponse>> localVarResponse = GetQuoteLastWithHttpInfo(version, symbolIds, level);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get last quote Return the last quote for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <returns>ApiResponse of List&lt;QuoteResponse&gt;</returns>
        public ApiResponse<List<QuoteResponse>> GetQuoteLastWithHttpInfo(string version, string symbolIds, string level = default(string))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling LiveFeedAPIApi->GetQuoteLast");

            // verify the required parameter 'symbolIds' is set
            if (symbolIds == null)
                throw new ApiException(400, "Missing required parameter 'symbolIds' when calling LiveFeedAPIApi->GetQuoteLast");

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
            localVarRequestOptions.PathParameters.Add("symbolIds", ClientUtils.ParameterToString(symbolIds)); // path parameter
            if (level != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "level", level));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<QuoteResponse>>("/md/{version}/feed/{symbolIds}/last", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetQuoteLast", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get last quote Return the last quote for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;QuoteResponse&gt;</returns>
        public async Task<List<QuoteResponse>> GetQuoteLastAsync(string version, string symbolIds, string level = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<QuoteResponse>> localVarResponse = await GetQuoteLastWithHttpInfoAsync(version, symbolIds, level, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get last quote Return the last quote for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;QuoteResponse&gt;)</returns>
        public async Task<ApiResponse<List<QuoteResponse>>> GetQuoteLastWithHttpInfoAsync(string version, string symbolIds, string level = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling LiveFeedAPIApi->GetQuoteLast");

            // verify the required parameter 'symbolIds' is set
            if (symbolIds == null)
                throw new ApiException(400, "Missing required parameter 'symbolIds' when calling LiveFeedAPIApi->GetQuoteLast");


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
            localVarRequestOptions.PathParameters.Add("symbolIds", ClientUtils.ParameterToString(symbolIds)); // path parameter
            if (level != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "level", level));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<QuoteResponse>>("/md/{version}/feed/{symbolIds}/last", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetQuoteLast", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get quote stream Return the life quote stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <returns>QuoteResponse</returns>
        public QuoteResponse GetQuoteStream(string version, string accept, string symbolIds, string level = default(string))
        {
            ApiResponse<QuoteResponse> localVarResponse = GetQuoteStreamWithHttpInfo(version, accept, symbolIds, level);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get quote stream Return the life quote stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <returns>ApiResponse of QuoteResponse</returns>
        public ApiResponse<QuoteResponse> GetQuoteStreamWithHttpInfo(string version, string accept, string symbolIds, string level = default(string))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling LiveFeedAPIApi->GetQuoteStream");

            // verify the required parameter 'accept' is set
            if (accept == null)
                throw new ApiException(400, "Missing required parameter 'accept' when calling LiveFeedAPIApi->GetQuoteStream");

            // verify the required parameter 'symbolIds' is set
            if (symbolIds == null)
                throw new ApiException(400, "Missing required parameter 'symbolIds' when calling LiveFeedAPIApi->GetQuoteStream");

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
            localVarRequestOptions.PathParameters.Add("symbolIds", ClientUtils.ParameterToString(symbolIds)); // path parameter
            if (level != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "level", level));
            }
            localVarRequestOptions.HeaderParameters.Add("Accept", ClientUtils.ParameterToString(accept)); // header parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<QuoteResponse>("/md/{version}/feed/{symbolIds}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetQuoteStream", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get quote stream Return the life quote stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of QuoteResponse</returns>
        public async Task<QuoteResponse> GetQuoteStreamAsync(string version, string accept, string symbolIds, string level = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<QuoteResponse> localVarResponse = await GetQuoteStreamWithHttpInfoAsync(version, accept, symbolIds, level, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get quote stream Return the life quote stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request quotes</param>
        /// <param name="level">quote level to request (optional, default to best_price)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (QuoteResponse)</returns>
        public async Task<ApiResponse<QuoteResponse>> GetQuoteStreamWithHttpInfoAsync(string version, string accept, string symbolIds, string level = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling LiveFeedAPIApi->GetQuoteStream");

            // verify the required parameter 'accept' is set
            if (accept == null)
                throw new ApiException(400, "Missing required parameter 'accept' when calling LiveFeedAPIApi->GetQuoteStream");

            // verify the required parameter 'symbolIds' is set
            if (symbolIds == null)
                throw new ApiException(400, "Missing required parameter 'symbolIds' when calling LiveFeedAPIApi->GetQuoteStream");


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
            localVarRequestOptions.PathParameters.Add("symbolIds", ClientUtils.ParameterToString(symbolIds)); // path parameter
            if (level != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "level", level));
            }
            localVarRequestOptions.HeaderParameters.Add("Accept", ClientUtils.ParameterToString(accept)); // header parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<QuoteResponse>("/md/{version}/feed/{symbolIds}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetQuoteStream", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get trades stream Return the trades stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request trades</param>
        /// <returns>List&lt;TradeResponse&gt;</returns>
        public List<TradeResponse> GetTradesStream(string version, string accept, string symbolIds)
        {
            ApiResponse<List<TradeResponse>> localVarResponse = GetTradesStreamWithHttpInfo(version, accept, symbolIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get trades stream Return the trades stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request trades</param>
        /// <returns>ApiResponse of List&lt;TradeResponse&gt;</returns>
        public ApiResponse<List<TradeResponse>> GetTradesStreamWithHttpInfo(string version, string accept, string symbolIds)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling LiveFeedAPIApi->GetTradesStream");

            // verify the required parameter 'accept' is set
            if (accept == null)
                throw new ApiException(400, "Missing required parameter 'accept' when calling LiveFeedAPIApi->GetTradesStream");

            // verify the required parameter 'symbolIds' is set
            if (symbolIds == null)
                throw new ApiException(400, "Missing required parameter 'symbolIds' when calling LiveFeedAPIApi->GetTradesStream");

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
            localVarRequestOptions.PathParameters.Add("symbolIds", ClientUtils.ParameterToString(symbolIds)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Accept", ClientUtils.ParameterToString(accept)); // header parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<TradeResponse>>("/md/{version}/feed/trades/{symbolIds}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTradesStream", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get trades stream Return the trades stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request trades</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;TradeResponse&gt;</returns>
        public async Task<List<TradeResponse>> GetTradesStreamAsync(string version, string accept, string symbolIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<TradeResponse>> localVarResponse = await GetTradesStreamWithHttpInfoAsync(version, accept, symbolIds, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get trades stream Return the trades stream for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="accept">Acceptiong stream type data</param>
        /// <param name="symbolIds">financial instrument id or comma-delimited list of instruments to request trades</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;TradeResponse&gt;)</returns>
        public async Task<ApiResponse<List<TradeResponse>>> GetTradesStreamWithHttpInfoAsync(string version, string accept, string symbolIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling LiveFeedAPIApi->GetTradesStream");

            // verify the required parameter 'accept' is set
            if (accept == null)
                throw new ApiException(400, "Missing required parameter 'accept' when calling LiveFeedAPIApi->GetTradesStream");

            // verify the required parameter 'symbolIds' is set
            if (symbolIds == null)
                throw new ApiException(400, "Missing required parameter 'symbolIds' when calling LiveFeedAPIApi->GetTradesStream");


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
            localVarRequestOptions.PathParameters.Add("symbolIds", ClientUtils.ParameterToString(symbolIds)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Accept", ClientUtils.ParameterToString(accept)); // header parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<TradeResponse>>("/md/{version}/feed/trades/{symbolIds}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTradesStream", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
