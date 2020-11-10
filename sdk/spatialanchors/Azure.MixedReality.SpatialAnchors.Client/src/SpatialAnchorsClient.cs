// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.SpatialAnchors.Client.Models;

namespace Azure.MixedReality.SpatialAnchors.Client
{
    /// <summary>
    /// Represents the <see cref="SpatialAnchorsClient">Azure Spatial Anchors client</see>.
    /// </summary>
    public class SpatialAnchorsClient
    {
        private readonly string _accountId;

        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly HttpPipeline _pipeline;

        private readonly SpatialAnchorsRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClient" /> class.
        /// </summary>
        /// <param name="credential">The credential used to access the Azure Spatial Anchors account.</param>
        public SpatialAnchorsClient(MixedRealityCredential credential)
            : this(credential, new SpatialAnchorsClientOptions()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClient"/> class.
        /// </summary>
        /// <param name="credential">The credential used to access the Azure Spatial Anchors account.</param>
        /// <param name="options">The options.</param>
        public SpatialAnchorsClient(MixedRealityCredential credential, SpatialAnchorsClientOptions options)
            : this(ConstructAsaEndpointUrl(credential?.AccountDomain ?? throw new ArgumentNullException(nameof(credential))), credential, options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClient" /> class.
        /// </summary>
        /// <param name="endpoint">The Azure Spatial Anchors service endpoint.</param>
        /// <param name="credential">The credential used to access the Azure Spatial Anchors account.</param>
        public SpatialAnchorsClient(Uri endpoint, MixedRealityCredential credential)
            : this(endpoint, credential, new SpatialAnchorsClientOptions()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClient" /> class.
        /// </summary>
        /// <param name="endpoint">The Azure Spatial Anchors service endpoint.</param>
        /// <param name="credential">The credential used to access the Azure Spatial Anchors account.</param>
        /// <param name="options">The options.</param>
        public SpatialAnchorsClient(Uri endpoint, MixedRealityCredential credential, SpatialAnchorsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            TokenCredential tokenCredential = new MixedRealityCredentialAdapter(credential);

            this._accountId = credential.AccountId;
            this._clientDiagnostics = new ClientDiagnostics(options);
            this._pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, GetDefaultScope(endpoint)));
            this._restClient = new SpatialAnchorsRestClient(this._clientDiagnostics, this._pipeline, endpoint, options.Version);
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClient"/> class.
        /// </summary>
        /// <remarks>
        /// Required for mocking.
        /// </remarks>
        protected SpatialAnchorsClient()
        {
        }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Gets the properties for the specified anchor.
        /// </summary>
        /// <param name="spatialAnchorId">The spatial anchor identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="IReadOnlyList{SpatialAnchorResponseInfo}"/>.</returns>
        public virtual Response<SpatialAnchorResponseInfo> GetAnchorProperties(
            string spatialAnchorId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(spatialAnchorId, nameof(spatialAnchorId));

            SpatialAnchorRequestInfo request = new SpatialAnchorRequestInfo
            {
                SpatialAnchorId = spatialAnchorId
            };

            return this.GetAnchorProperties(request, cancellationToken);
        }

        /// <summary>
        /// Gets the properties for the specified anchor.
        /// </summary>
        /// <param name="spatialAnchorId">The spatial anchor identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="IReadOnlyList{SpatialAnchorResponseInfo}"/>.</returns>
        public virtual Task<Response<SpatialAnchorResponseInfo>> GetAnchorPropertiesAsync(
            string spatialAnchorId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(spatialAnchorId, nameof(spatialAnchorId));

            SpatialAnchorRequestInfo request = new SpatialAnchorRequestInfo
            {
                SpatialAnchorId = spatialAnchorId
            };

            return this.GetAnchorPropertiesAsync(request, cancellationToken);
        }

        /// <summary>
        /// Gets the properties for the specified anchor.
        /// </summary>
        /// <param name="anchorRequest">The anchor request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="IReadOnlyList{SpatialAnchorResponseInfo}"/>.</returns>
        public virtual Response<SpatialAnchorResponseInfo> GetAnchorProperties(
            SpatialAnchorRequestInfo anchorRequest,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(anchorRequest, nameof(anchorRequest));

            Response<IReadOnlyList<SpatialAnchorResponseInfo>> response = this.GetAnchorProperties(new[] { anchorRequest }, cancellationToken);

            return Response.FromValue(response.Value[0], response.GetRawResponse());
        }

        /// <summary>
        /// Gets the properties for the specified anchor.
        /// </summary>
        /// <param name="anchorRequest">The anchor request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="IReadOnlyList{SpatialAnchorResponseInfo}"/>.</returns>
        public virtual async Task<Response<SpatialAnchorResponseInfo>> GetAnchorPropertiesAsync(
            SpatialAnchorRequestInfo anchorRequest,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(anchorRequest, nameof(anchorRequest));

            Response<IReadOnlyList<SpatialAnchorResponseInfo>> response = await this.GetAnchorPropertiesAsync(new[] { anchorRequest }, cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(response.Value[0], response.GetRawResponse());
        }

        /// <summary>
        /// Gets the properties for the specified list of anchors.
        /// </summary>
        /// <param name="anchorRequests">The anchor requests.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="IReadOnlyList{SpatialAnchorResponseInfo}"/>.</returns>
        public virtual Response<IReadOnlyList<SpatialAnchorResponseInfo>> GetAnchorProperties(
            IEnumerable<SpatialAnchorRequestInfo> anchorRequests,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anchorRequests, nameof(anchorRequests));

            string requestCv = GenerateCv();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SpatialAnchorsClient)}.{nameof(GetAnchorProperties)}");
            scope.AddAttribute(nameof(requestCv), requestCv);
            scope.Start();

            try
            {
                PropertiesRequestOptions requestOptions = new PropertiesRequestOptions
                {
                    ClientRequestId = requestCv
                };

                SpatialAnchorsPropertiesRequest request = new SpatialAnchorsPropertiesRequest(anchorRequests);

                ResponseWithHeaders<SpatialAnchorsPropertiesResponse, SpatialAnchorsGetPropertiesByIdHeaders> response =
                    this._restClient.GetPropertiesById(this._accountId, request, requestOptions, cancellationToken);

                return ResponseWithHeaders.FromValue(response.Value.SpatialAnchors, response.Headers, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the properties for the specified list of anchors.
        /// </summary>
        /// <param name="anchorRequests">The anchor requests.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="IReadOnlyList{SpatialAnchorResponseInfo}"/>.</returns>
        public virtual async Task<Response<IReadOnlyList<SpatialAnchorResponseInfo>>> GetAnchorPropertiesAsync(
            IEnumerable<SpatialAnchorRequestInfo> anchorRequests,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(anchorRequests, nameof(anchorRequests));

            string requestCv = GenerateCv();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SpatialAnchorsClient)}.{nameof(GetAnchorProperties)}");
            scope.AddAttribute(nameof(requestCv), requestCv);
            scope.Start();

            try
            {
                PropertiesRequestOptions requestOptions = new PropertiesRequestOptions
                {
                    ClientRequestId = requestCv
                };

                SpatialAnchorsPropertiesRequest request = new SpatialAnchorsPropertiesRequest(anchorRequests);

                ResponseWithHeaders<SpatialAnchorsPropertiesResponse, SpatialAnchorsGetPropertiesByIdHeaders> response =
                    await this._restClient.GetPropertiesByIdAsync(this._accountId, request, requestOptions, cancellationToken)
                        .ConfigureAwait(false);

                return ResponseWithHeaders.FromValue(response.Value.SpatialAnchors, response.Headers, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified anchor.
        /// </summary>
        /// <param name="spatialAnchor">The spatial anchor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="Response"/>.</returns>
        public virtual Response DeleteAnchor(SpatialAnchorResponseInfo spatialAnchor, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(spatialAnchor, nameof(spatialAnchor));

            string requestCv = GenerateCv();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SpatialAnchorsClient)}.{nameof(DeleteAnchor)}");
            scope.AddAttribute(nameof(requestCv), requestCv);
            scope.Start();

            try
            {
                DeleteRequestOptions requestOptions = new DeleteRequestOptions
                {
                    ClientRequestId = requestCv
                };

                return this._restClient.DeleteAnchor(this._accountId, spatialAnchor.SpatialAnchorId, spatialAnchor.SpatialAnchor.Etag.ToString(), requestOptions, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified anchor.
        /// </summary>
        /// <param name="spatialAnchor">The spatial anchor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="Response"/>.</returns>
        public virtual async Task<Response> DeleteAnchorAsync(SpatialAnchorResponseInfo spatialAnchor, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(spatialAnchor, nameof(spatialAnchor));
            Argument.AssertNotNull(spatialAnchor.SpatialAnchor, nameof(spatialAnchor.SpatialAnchor));

            string requestCv = GenerateCv();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SpatialAnchorsClient)}.{nameof(DeleteAnchor)}");
            scope.AddAttribute(nameof(requestCv), requestCv);
            scope.Start();

            try
            {
                DeleteRequestOptions requestOptions = new DeleteRequestOptions
                {
                    ClientRequestId = requestCv
                };

                return await this._restClient.DeleteAnchorAsync(this._accountId, spatialAnchor.SpatialAnchorId, spatialAnchor.SpatialAnchor.Etag.ToString(), requestOptions, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static Uri ConstructAsaEndpointUrl(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            if (!Uri.TryCreate($"https://manage.sa.{accountDomain}", UriKind.Absolute, out Uri result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        private static string GenerateCv()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');
    }
}
