

using System;
using System.Collections.Generic;

using QuantConnect.Brokerages.Exante.Client;
using QuantConnect.Brokerages.Exante.Model;

namespace QuantConnect.Brokerages.Exante.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HistoricalAPIApi 
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoricalAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public HistoricalAPIApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoricalAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public HistoricalAPIApi(String basePath)
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
        /// Initializes a new instance of the <see cref="HistoricalAPIApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public HistoricalAPIApi(Configuration configuration)
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
        /// Initializes a new instance of the <see cref="HistoricalAPIApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public HistoricalAPIApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
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
        /// get OHLC Return the list of OHLC candles for the specified financial instrument and duration
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="duration">aggregation interval in seconds</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <returns>List&lt;OHLCResponse&gt;</returns>
        public List<OHLCResponse> GetOHLC(string version, string symbolId, decimal duration, string from = default(string), string to = default(string), string size = default(string))
        {
            ApiResponse<List<OHLCResponse>> localVarResponse = GetOHLCWithHttpInfo(version, symbolId, duration, from, to, size);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get OHLC Return the list of OHLC candles for the specified financial instrument and duration
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="duration">aggregation interval in seconds</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <returns>ApiResponse of List&lt;OHLCResponse&gt;</returns>
        public ApiResponse<List<OHLCResponse>> GetOHLCWithHttpInfo(string version, string symbolId, decimal duration, string from = default(string), string to = default(string), string size = default(string))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HistoricalAPIApi->GetOHLC");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling HistoricalAPIApi->GetOHLC");

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
            localVarRequestOptions.PathParameters.Add("duration", ClientUtils.ParameterToString(duration)); // path parameter
            if (from != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "from", from));
            }
            if (to != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "to", to));
            }
            if (size != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "size", size));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<OHLCResponse>>("/md/{version}/ohlc/{symbolId}/{duration}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOHLC", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get OHLC Return the list of OHLC candles for the specified financial instrument and duration
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="duration">aggregation interval in seconds</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;OHLCResponse&gt;</returns>
        public async Task<List<OHLCResponse>> GetOHLCAsync(string version, string symbolId, decimal duration, string from = default(string), string to = default(string), string size = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<OHLCResponse>> localVarResponse = await GetOHLCWithHttpInfoAsync(version, symbolId, duration, from, to, size, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get OHLC Return the list of OHLC candles for the specified financial instrument and duration
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="duration">aggregation interval in seconds</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;OHLCResponse&gt;)</returns>
        public async Task<ApiResponse<List<OHLCResponse>>> GetOHLCWithHttpInfoAsync(string version, string symbolId, decimal duration, string from = default(string), string to = default(string), string size = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HistoricalAPIApi->GetOHLC");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling HistoricalAPIApi->GetOHLC");


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
            localVarRequestOptions.PathParameters.Add("duration", ClientUtils.ParameterToString(duration)); // path parameter
            if (from != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "from", from));
            }
            if (to != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "to", to));
            }
            if (size != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "size", size));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<OHLCResponse>>("/md/{version}/ohlc/{symbolId}/{duration}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOHLC", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get ticks Return the list of ticks for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <param name="type">tick types - trades or quotes (optional, default to quotes)</param>
        /// <returns>List&lt;TickResponse&gt;</returns>
        public List<TickResponse> GetTicks(string version, string symbolId, string from = default(string), string to = default(string), string size = default(string), string type = default(string))
        {
            ApiResponse<List<TickResponse>> localVarResponse = GetTicksWithHttpInfo(version, symbolId, from, to, size, type);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get ticks Return the list of ticks for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <param name="type">tick types - trades or quotes (optional, default to quotes)</param>
        /// <returns>ApiResponse of List&lt;TickResponse&gt;</returns>
        public ApiResponse<List<TickResponse>> GetTicksWithHttpInfo(string version, string symbolId, string from = default(string), string to = default(string), string size = default(string), string type = default(string))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HistoricalAPIApi->GetTicks");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling HistoricalAPIApi->GetTicks");

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
            if (from != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "from", from));
            }
            if (to != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "to", to));
            }
            if (size != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "size", size));
            }
            if (type != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "type", type));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<TickResponse>>("/md/{version}/ticks/{symbolId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTicks", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get ticks Return the list of ticks for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <param name="type">tick types - trades or quotes (optional, default to quotes)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;TickResponse&gt;</returns>
        public async Task<List<TickResponse>> GetTicksAsync(string version, string symbolId, string from = default(string), string to = default(string), string size = default(string), string type = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<List<TickResponse>> localVarResponse = await GetTicksWithHttpInfoAsync(version, symbolId, from, to, size, type, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get ticks Return the list of ticks for the specified financial instrument
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="symbolId">financial instrument id to get candles</param>
        /// <param name="from">starting timestamp in ms (optional)</param>
        /// <param name="to">ending timestamp in ms (optional)</param>
        /// <param name="size">maximum amount of candles to retrieve (optional, default to &quot;60&quot;)</param>
        /// <param name="type">tick types - trades or quotes (optional, default to quotes)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;TickResponse&gt;)</returns>
        public async Task<ApiResponse<List<TickResponse>>> GetTicksWithHttpInfoAsync(string version, string symbolId, string from = default(string), string to = default(string), string size = default(string), string type = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling HistoricalAPIApi->GetTicks");

            // verify the required parameter 'symbolId' is set
            if (symbolId == null)
                throw new ApiException(400, "Missing required parameter 'symbolId' when calling HistoricalAPIApi->GetTicks");


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
            if (from != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "from", from));
            }
            if (to != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "to", to));
            }
            if (size != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "size", size));
            }
            if (type != null)
            {
                localVarRequestOptions.QueryParameters.Add(ClientUtils.ParameterToMultiMap("", "type", type));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<TickResponse>>("/md/{version}/ticks/{symbolId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTicks", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
