// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Management.Compute.Models
{
    /// <summary> Specifies a list of virtual machine instance IDs from the VM scale set. </summary>
    public partial class VirtualMachineScaleSetVMInstanceRequiredIDs
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMInstanceRequiredIDs. </summary>
        /// <param name="instanceIds"> The virtual machine scale set instance ids. </param>
        public VirtualMachineScaleSetVMInstanceRequiredIDs(IEnumerable<string> instanceIds)
        {
            if (instanceIds == null)
            {
                throw new ArgumentNullException(nameof(instanceIds));
            }

            InstanceIds = instanceIds.ToArray();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMInstanceRequiredIDs. </summary>
        /// <param name="instanceIds"> The virtual machine scale set instance ids. </param>
        internal VirtualMachineScaleSetVMInstanceRequiredIDs(IList<string> instanceIds)
        {
            InstanceIds = instanceIds ?? new List<string>();
        }

        /// <summary> The virtual machine scale set instance ids. </summary>
        public IList<string> InstanceIds { get; }
    }
}