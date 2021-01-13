// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.MixedReality.SpatialAnchors.Client.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests
{
    public class SpatialAnchorsClientLiveTest : RecordedTestBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly SpatialAnchorsAccount account;

        public SpatialAnchorsClientLiveTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Live)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;

            account = new SpatialAnchorsAccount(TestEnvironment.AccountId, TestEnvironment.AccountDomain);
        }

        private SpatialAnchorsClient CreateClient(AzureKeyCredential keyCredential)
        {
            return InstrumentClient(new SpatialAnchorsClient(account, keyCredential, InstrumentClientOptions(new SpatialAnchorsClientOptions())));
        }

        [Test]
        public async Task GetAnchorPropertiesAsync()
        {
            string spatialAnchorsAccountKey = TestEnvironment.AccountKey;
            string anchorId = TestEnvironment.AnchorId;

            AzureKeyCredential accountKeyCredential = new AzureKeyCredential(spatialAnchorsAccountKey);

            SpatialAnchorsClient client = CreateClient(accountKeyCredential);

            SpatialAnchorRequestInfo requestInfo = new SpatialAnchorRequestInfo
            {
                SpatialAnchorId = anchorId
            };

            SpatialAnchorResponseInfo response = await client.GetAnchorPropertiesAsync(requestInfo);

            Assert.NotNull(response);
            Assert.AreEqual(anchorId, response.SpatialAnchorId);
            Assert.NotNull(response.Code);
        }
    }
}
