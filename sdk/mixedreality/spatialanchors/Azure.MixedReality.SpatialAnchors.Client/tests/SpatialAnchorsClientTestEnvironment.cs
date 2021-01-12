// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests
{
    public class SpatialAnchorsClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the SPATIALANCHORS_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetVariable("ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the SPATIALANCHORS_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetVariable("ACCOUNT_ID");

        /// <summary>
        /// Gets the account key.
        /// </summary>
        /// <remarks>
        /// Set the SPATIALANCHORS_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetVariable("ACCOUNT_KEY");

        /// <summary>
        /// Gets the anchor identifier.
        /// </summary>
        /// <remarks>
        /// Set the SPATIALANCHORS_ANCHOR_ID environment variable.
        /// </remarks>
        public string AnchorId => GetVariable("ANCHOR_ID");

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsClientTestEnvironment"/> class.
        /// </summary>
        public SpatialAnchorsClientTestEnvironment() : base("spatialanchors")
        {
        }
    }
}
