// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.MixedReality.SpatialAnchors.Client.Models
{
    [CodeGenModel("GetPropertiesForSpatialAnchorsResponse")]
    internal partial class SpatialAnchorsPropertiesResponse
    {
        /// <summary>
        /// A list of spatial anchors information.
        /// </summary>
        public IReadOnlyList<SpatialAnchorResponseInfo> SpatialAnchors { get; }
    }
}
