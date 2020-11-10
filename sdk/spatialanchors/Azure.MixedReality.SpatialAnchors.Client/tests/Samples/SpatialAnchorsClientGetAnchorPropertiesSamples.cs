// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.SpatialAnchors.Client.Models;
using NUnit.Framework;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests.Samples
{
    public class SpatialAnchorsClientGetAnchorPropertiesSamples : SamplesBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly string accountDomain;
        private readonly string accountId;
        private readonly string accountKey;
        private readonly string anchorId;

        public SpatialAnchorsClientGetAnchorPropertiesSamples()
        {
            this.accountKey = TestEnvironment.AccountKey;
            this.anchorId = TestEnvironment.AnchorId;
            this.accountId = TestEnvironment.AccountId;
            this.accountDomain = TestEnvironment.AccountDomain;
        }

        [Test]
        public void GetAnchorProperties()
        {
            #region Snippet:GetAnchorProperties

            MixedRealityCredential credential = new MixedRealityCredential(accountId, accountDomain, accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(credential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:GetAnchorProperties
        }

        [Test]
        public async Task GetAnchorPropertiesAsync()
        {
            #region Snippet:GetAnchorPropertiesAsync

            MixedRealityCredential credential = new MixedRealityCredential(accountId, accountDomain, accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(credential);

            SpatialAnchorResponseInfo response = await client.GetAnchorPropertiesAsync(anchorId).ConfigureAwait(false);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:GetAnchorPropertiesAsync
        }
    }
}
