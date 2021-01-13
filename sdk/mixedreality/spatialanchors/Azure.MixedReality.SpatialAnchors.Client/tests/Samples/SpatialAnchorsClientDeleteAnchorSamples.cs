// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.MixedReality.SpatialAnchors.Client.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests.Samples
{
    public class SpatialAnchorsClientDeleteAnchorSamples : SamplesBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly SpatialAnchorsAccount account;
        private readonly string accountKey;
        private readonly string anchorId;

        public SpatialAnchorsClientDeleteAnchorSamples()
        {
            this.account = new SpatialAnchorsAccount(TestEnvironment.AccountId, TestEnvironment.AccountDomain);
            this.accountKey = TestEnvironment.AccountKey;
            this.anchorId = TestEnvironment.AnchorId;
        }

        [Test]
        public void DeleteAnchor()
        {
            #region Snippet:DeleteAnchor

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(account, accountKeyCredential);

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

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(account, accountKeyCredential);

            SpatialAnchorResponseInfo response = await client.GetAnchorPropertiesAsync(anchorId).ConfigureAwait(false);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            await client.DeleteAnchorAsync(response);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was deleted.");

            #endregion Snippet:DeleteAnchorAsync
        }
    }
}
