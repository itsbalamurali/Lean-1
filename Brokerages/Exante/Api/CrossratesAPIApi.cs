

using System;
using System.Collections.Generic;

using QuantConnect.Brokerages.Exante.Client;
using QuantConnect.Brokerages.Exante.Model;

namespace QuantConnect.Brokerages.Exante.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CrossratesAPIApi 
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossratesAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CrossratesAPIApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossratesAPIApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CrossratesAPIApi(String basePath)
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
        /// Initializes a new instance of the <see cref="CrossratesAPIApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CrossratesAPIApi(Configuration configuration)
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
        /// Initializes a new instance of the <see cref="CrossratesAPIApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public CrossratesAPIApi(ISynchronousClient client, IAsynchronousClient asyncClient, IReadableConfiguration configuration)
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
        /// get crossrate Return the crossrate from one currency to another
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="from">from currency</param>
        /// <param name="to">to currency</param>
        /// <returns>Crossrate</returns>
        public Crossrate GetCrossrate(string version, string from, string to)
        {
            ApiResponse<Crossrate> localVarResponse = GetCrossrateWithHttpInfo(version, from, to);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get crossrate Return the crossrate from one currency to another
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="from">from currency</param>
        /// <param name="to">to currency</param>
        /// <returns>ApiResponse of Crossrate</returns>
        public ApiResponse<Crossrate> GetCrossrateWithHttpInfo(string version, string from, string to)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling CrossratesAPIApi->GetCrossrate");

            // verify the required parameter 'from' is set
            if (from == null)
                throw new ApiException(400, "Missing required parameter 'from' when calling CrossratesAPIApi->GetCrossrate");

            // verify the required parameter 'to' is set
            if (to == null)
                throw new ApiException(400, "Missing required parameter 'to' when calling CrossratesAPIApi->GetCrossrate");

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
            localVarRequestOptions.PathParameters.Add("from", ClientUtils.ParameterToString(from)); // path parameter
            localVarRequestOptions.PathParameters.Add("to", ClientUtils.ParameterToString(to)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<Crossrate>("/md/{version}/crossrates/{from}/{to}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCrossrate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get crossrate Return the crossrate from one currency to another
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="from">from currency</param>
        /// <param name="to">to currency</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Crossrate</returns>
        public async Task<Crossrate> GetCrossrateAsync(string version, string from, string to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<Crossrate> localVarResponse = await GetCrossrateWithHttpInfoAsync(version, from, to, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get crossrate Return the crossrate from one currency to another
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="from">from currency</param>
        /// <param name="to">to currency</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Crossrate)</returns>
        public async Task<ApiResponse<Crossrate>> GetCrossrateWithHttpInfoAsync(string version, string from, string to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling CrossratesAPIApi->GetCrossrate");

            // verify the required parameter 'from' is set
            if (from == null)
                throw new ApiException(400, "Missing required parameter 'from' when calling CrossratesAPIApi->GetCrossrate");

            // verify the required parameter 'to' is set
            if (to == null)
                throw new ApiException(400, "Missing required parameter 'to' when calling CrossratesAPIApi->GetCrossrate");


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
            localVarRequestOptions.PathParameters.Add("from", ClientUtils.ParameterToString(from)); // path parameter
            localVarRequestOptions.PathParameters.Add("to", ClientUtils.ParameterToString(to)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Crossrate>("/md/{version}/crossrates/{from}/{to}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCrossrate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get list of available currencies Return the list of available currencies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>CrossrateCurrencies</returns>
        public CrossrateCurrencies GetCurrencies(string version)
        {
            ApiResponse<CrossrateCurrencies> localVarResponse = GetCurrenciesWithHttpInfo(version);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get list of available currencies Return the list of available currencies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <returns>ApiResponse of CrossrateCurrencies</returns>
        public ApiResponse<CrossrateCurrencies> GetCurrenciesWithHttpInfo(string version)
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling CrossratesAPIApi->GetCurrencies");

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
            var localVarResponse = this.Client.Get<CrossrateCurrencies>("/md/{version}/crossrates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCurrencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// get list of available currencies Return the list of available currencies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrossrateCurrencies</returns>
        public async Task<CrossrateCurrencies> GetCurrenciesAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ApiResponse<CrossrateCurrencies> localVarResponse = await GetCurrenciesWithHttpInfoAsync(version, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// get list of available currencies Return the list of available currencies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="version">API version</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrossrateCurrencies)</returns>
        public async Task<ApiResponse<CrossrateCurrencies>> GetCurrenciesWithHttpInfoAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'version' is set
            if (version == null)
                throw new ApiException(400, "Missing required parameter 'version' when calling CrossratesAPIApi->GetCurrencies");


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

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrossrateCurrencies>("/md/{version}/crossrates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCurrencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
