// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.MixedReality.Authentication;
using Azure.MixedReality.SpatialAnchors.Client.Models;
using NUnit.Framework;

namespace Azure.MixedReality.SpatialAnchors.Client.Tests
{
    public class SpatialAnchorsClientLiveTest : RecordedTestBase<SpatialAnchorsClientTestEnvironment>
    {
        private readonly string spatialAnchorsAccountDomain;
        private readonly string spatialAnchorsAccountId;

        public SpatialAnchorsClientLiveTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Live)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;

            this.spatialAnchorsAccountId = TestEnvironment.AccountId;
            this.spatialAnchorsAccountDomain = TestEnvironment.AccountDomain;
        }

        private SpatialAnchorsClient CreateClient(MixedRealityCredential credential)
        {
            return InstrumentClient(new SpatialAnchorsClient(credential, InstrumentClientOptions(new SpatialAnchorsClientOptions())));
        }

        [Test]
        public async Task GetAnchorPropertiesAsync()
        {
            string spatialAnchorsAccountKey = TestEnvironment.AccountKey;
            string anchorId = TestEnvironment.AnchorId;

            MixedRealityCredential credential = new MixedRealityCredential(spatialAnchorsAccountId, spatialAnchorsAccountDomain, spatialAnchorsAccountKey);
            SpatialAnchorsClient client = CreateClient(credential);

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
