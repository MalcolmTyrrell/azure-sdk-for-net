// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.MixedReality.SpatialAnchors.Client.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests.Samples
{
    public class SpatialAnchorsClientGetAnchorPropertiesSamples : SamplesBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly SpatialAnchorsAccount account;
        private readonly string accountKey;
        private readonly string anchorId;

        public SpatialAnchorsClientGetAnchorPropertiesSamples()
        {
            this.account = new SpatialAnchorsAccount(TestEnvironment.AccountId, TestEnvironment.AccountDomain);
            this.accountKey = TestEnvironment.AccountKey;
            this.anchorId = TestEnvironment.AnchorId;
        }

        [Test]
        public void GetAnchorProperties()
        {
            #region Snippet:GetAnchorProperties

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(account, accountKeyCredential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:GetAnchorProperties
        }

        [Test]
        public async Task GetAnchorPropertiesAsync()
        {
            #region Snippet:GetAnchorPropertiesAsync

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(account, accountKeyCredential);

            SpatialAnchorResponseInfo response = await client.GetAnchorPropertiesAsync(anchorId).ConfigureAwait(false);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:GetAnchorPropertiesAsync
        }
    }
}
