// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Synapse.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Managed Virtual Network Settings
    /// </summary>
    public partial class ManagedVirtualNetworkSettings
    {
        /// <summary>
        /// Initializes a new instance of the ManagedVirtualNetworkSettings
        /// class.
        /// </summary>
        public ManagedVirtualNetworkSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ManagedVirtualNetworkSettings
        /// class.
        /// </summary>
        /// <param name="preventDataExfiltration">Prevent Data
        /// Exfiltration</param>
        /// <param name="linkedAccessCheckOnTargetResource">Linked Access Check
        /// On Target Resource</param>
        /// <param name="allowedAadTenantIdsForLinking">Allowed Aad Tenant Ids
        /// For Linking</param>
        public ManagedVirtualNetworkSettings(bool? preventDataExfiltration = default(bool?), bool? linkedAccessCheckOnTargetResource = default(bool?), IList<string> allowedAadTenantIdsForLinking = default(IList<string>))
        {
            PreventDataExfiltration = preventDataExfiltration;
            LinkedAccessCheckOnTargetResource = linkedAccessCheckOnTargetResource;
            AllowedAadTenantIdsForLinking = allowedAadTenantIdsForLinking;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets prevent Data Exfiltration
        /// </summary>
        [JsonProperty(PropertyName = "preventDataExfiltration")]
        public bool? PreventDataExfiltration { get; set; }

        /// <summary>
        /// Gets or sets linked Access Check On Target Resource
        /// </summary>
        [JsonProperty(PropertyName = "linkedAccessCheckOnTargetResource")]
        public bool? LinkedAccessCheckOnTargetResource { get; set; }

        /// <summary>
        /// Gets or sets allowed Aad Tenant Ids For Linking
        /// </summary>
        [JsonProperty(PropertyName = "allowedAadTenantIdsForLinking")]
        public IList<string> AllowedAadTenantIdsForLinking { get; set; }

    }
}
