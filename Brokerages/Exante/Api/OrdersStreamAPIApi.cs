

using System;
using System.Collections.Generic;

using QuantConnect.Brokerages.Exante.Client;
using QuantConnect.Brokerages.Exante.Model;

namespace QuantConnect.Brokerages.Exante.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OrdersStreamAPIApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersStreamAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrdersStreamAPIApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersStreamAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public OrdersStreamAPIApi(String basePath)
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
        /// Initializes a new instance of the <see cref="OrdersStreamAPIApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public OrdersStreamAPIApi(Configuration configuration)
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
        /// Initializes a new instance of the <see cref="OrdersStreamAPIApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public OrdersStreamAPIApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
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
        /// order updates stream Order updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>OneOfOrderUpdateHeartbeat</returns>
        public OneOfOrderUpdateHeartbeat OrderUpdatesHttp(string version)
        {
            ApiResponse<OneOfOrderUpdateHeartbeat> localVarResponse = OrderUpdatesHttpWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// order updates stream Order updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of OneOfOrderUpdateHeartbeat</returns>
        public ApiResponse<OneOfOrderUpdateHeartbeat> OrderUpdatesHttpWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersStreamAPIApi->OrderUpdatesHttp");

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
            var localVarResponse = this.Client.Get<OneOfOrderUpdateHeartbeat>("/trade/{version}/stream/orders", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("OrderUpdatesHttp", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// order updates stream Order updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfOrderUpdateHeartbeat</returns>
        public async Task<OneOfOrderUpdateHeartbeat> OrderUpdatesHttpAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<OneOfOrderUpdateHeartbeat> localVarResponse = await OrderUpdatesHttpWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// order updates stream Order updates stream via HTTP
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfOrderUpdateHeartbeat)</returns>
        public async Task<ApiResponse<OneOfOrderUpdateHeartbeat>> OrderUpdatesHttpWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersStreamAPIApi->OrderUpdatesHttp");


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

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfOrderUpdateHeartbeat>("/trade/{version}/stream/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("OrderUpdatesHttp", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// order updates ws stream Order updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>OneOfWsOrderUpdateWsHeartbeat</returns>
        public OneOfWsOrderUpdateWsHeartbeat OrderUpdatesWs(string version)
        {
            ApiResponse<OneOfWsOrderUpdateWsHeartbeat> localVarResponse = OrderUpdatesWsWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// order updates ws stream Order updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of OneOfWsOrderUpdateWsHeartbeat</returns>
        public ApiResponse<OneOfWsOrderUpdateWsHeartbeat> OrderUpdatesWsWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersStreamAPIApi->OrderUpdatesWs");

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
            var localVarResponse = this.Client.Get<OneOfWsOrderUpdateWsHeartbeat>("/trade/{version}/ws/orders", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("OrderUpdatesWs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// order updates ws stream Order updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfWsOrderUpdateWsHeartbeat</returns>
        public async Task<OneOfWsOrderUpdateWsHeartbeat> OrderUpdatesWsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<OneOfWsOrderUpdateWsHeartbeat> localVarResponse = await OrderUpdatesWsWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// order updates ws stream Order updates stream via websocket
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfWsOrderUpdateWsHeartbeat)</returns>
        public async Task<ApiResponse<OneOfWsOrderUpdateWsHeartbeat>> OrderUpdatesWsWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling OrdersStreamAPIApi->OrderUpdatesWs");


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

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfWsOrderUpdateWsHeartbeat>("/trade/{version}/ws/orders", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("OrderUpdatesWs", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
