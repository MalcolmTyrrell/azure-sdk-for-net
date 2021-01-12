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
    public class SpatialAnchorsClientDeleteAnchorSamples : SamplesBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly string accountDomain;
        private readonly string accountId;
        private readonly string accountKey;
        private readonly string anchorId;

        public SpatialAnchorsClientDeleteAnchorSamples()
        {
            this.accountKey = TestEnvironment.AccountKey;
            this.anchorId = TestEnvironment.AnchorId;
            this.accountId = TestEnvironment.AccountId;
            this.accountDomain = TestEnvironment.AccountDomain;
        }

        [Test]
        public void DeleteAnchor()
        {
            #region Snippet:DeleteAnchor

            MixedRealityCredential credential = new MixedRealityCredential(accountId, accountDomain, accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(credential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            client.DeleteAnchor(response);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was deleted.");

            #endregion Snippet:DeleteAnchor
        }

        [Test]
        public async Task DeleteAnchorAsync()
        {
            #region Snippet:DeleteAnchorAsync

            MixedRealityCredential credential = new MixedRealityCredential(accountId, accountDomain, accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(credential);

            SpatialAnchorResponseInfo response = await client.GetAnchorPropertiesAsync(anchorId).ConfigureAwait(false);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            await client.DeleteAnchorAsync(response);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was deleted.");

            #endregion Snippet:DeleteAnchorAsync
        }
    }
}
