// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.MixedReality.SpatialAnchors.Client.Models
{
    [CodeGenModel("GetPropertiesForSpatialAnchorsRequest")]
    internal partial class SpatialAnchorsPropertiesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialAnchorsPropertiesRequest"/> class.
        /// </summary>
        /// <param name="spatialAnchors">The spatial anchors.</param>
        internal SpatialAnchorsPropertiesRequest(IEnumerable<SpatialAnchorRequestInfo> spatialAnchors)
        {
            SpatialAnchors = spatialAnchors;
        }

        /// <summary> The list of spatial anchors to request information. </summary>
        public IEnumerable<SpatialAnchorRequestInfo> SpatialAnchors { get; }
    }
}
