// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.SpatialAnchors.Client.Models;
using NUnit.Framework;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests.Samples
{
    public class SpatialAnchorsClientAuthenticationSamples : SamplesBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly string accountDomain;
        private readonly string accountId;
        private readonly string accountKey;
        private readonly string anchorId;

        public SpatialAnchorsClientAuthenticationSamples()
        {
            this.accountKey = TestEnvironment.AccountKey;
            this.anchorId = TestEnvironment.AnchorId;
            this.accountId = TestEnvironment.AccountId;
            this.accountDomain = TestEnvironment.AccountDomain;
        }

        [Test]
        public void UsingAccountKeyCredential()
        {
            #region Snippet:UsingAccountKeyCredential

            MixedRealityCredential credential = new MixedRealityCredential(accountId, accountDomain, accountKey);
            SpatialAnchorsClient client = new SpatialAnchorsClient(credential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:UsingAccountKeyCredential
        }

        [Test]
        public void UsingClientSecretCredential()
        {
            string clientId = TestEnvironment.ClientId;
            string clientSecret = TestEnvironment.ClientSecret;
            string tenantId = TestEnvironment.TenantId;

            #region Snippet:UsingClientSecretCredential

            TokenCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new TokenCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}")
            });

            MixedRealityCredential mrCredential = new MixedRealityCredential(accountId, accountDomain, credential);

            SpatialAnchorsClient client = new SpatialAnchorsClient(mrCredential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:UsingClientSecretCredential
        }

        [Test]
        public void UsingDefaultAzureCredential()
        {
            #region Snippet:UsingDefaultAzureCredential

            MixedRealityCredential mrCredential = new MixedRealityCredential(accountId, accountDomain, new DefaultAzureCredential());

            SpatialAnchorsClient client = new SpatialAnchorsClient(mrCredential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:UsingDefaultAzureCredential
        }

        [Test]
        public void UsingDeviceCodeCredential()
        {
            string clientId = TestEnvironment.ClientId;
            string tenantId = TestEnvironment.TenantId;

            #region Snippet:UsingDeviceCodeCredential

            Task deviceCodeCallback(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
            {
                Debug.WriteLine(deviceCodeInfo.Message);
                Console.WriteLine(deviceCodeInfo.Message);
                return Task.FromResult(0);
            }

            TokenCredential credential = new DeviceCodeCredential(deviceCodeCallback, tenantId, clientId, new TokenCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}"),
            });

            MixedRealityCredential mrCredential = new MixedRealityCredential(accountId, accountDomain, credential);

            SpatialAnchorsClient client = new SpatialAnchorsClient(mrCredential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:UsingDeviceCodeCredential
        }

        [Test]
        public void UsingVisualStudioCredential()
        {
            string tenantId = TestEnvironment.TenantId;

            #region Snippet:UsingVisualStudioCredential

            TokenCredential credential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions
            {
                AuthorityHost = new Uri($"https://login.microsoftonline.com/{tenantId}"),
                TenantId = tenantId,
            });

            MixedRealityCredential mrCredential = new MixedRealityCredential(accountId, accountDomain, credential);

            SpatialAnchorsClient client = new SpatialAnchorsClient(mrCredential);

            SpatialAnchorResponseInfo response = client.GetAnchorProperties(anchorId);

            Console.WriteLine($"The spatial anchor {response.SpatialAnchorId} was {response.Code}.");

            #endregion Snippet:UsingVisualStudioCredential
        }
    }
}
