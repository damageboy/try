﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Microsoft.DotNet.Interactive.Commands
{
    public class LoadExtensionFromNuGetPackage : KernelCommandBase
    {
        public LoadExtensionFromNuGetPackage(NugetPackageReference nugetPackageReference, IEnumerable<FileInfo> metadataReferences)
        {
            NugetPackageReference = nugetPackageReference ?? throw new ArgumentNullException(nameof(nugetPackageReference));
            MetadataReferences = metadataReferences ?? throw new ArgumentNullException(nameof(metadataReferences));
        }

        [JsonIgnore]
        public NugetPackageReference NugetPackageReference { get; }

        [JsonIgnore]
        public IEnumerable<FileInfo> MetadataReferences { get; }
    }
}