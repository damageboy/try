﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using FluentAssertions;
using System.Threading.Tasks;
using WorkspaceServer.Packaging;
using Xunit;

namespace WorkspaceServer.Tests
{
    public class PackageRestoreContextTests
    {
        [Fact]
        public async Task Returns_new_references_if_they_are_added()
        {
            var refs = await new PackageRestoreContext().AddPackage("FluentAssertions", "5.7.0");
            refs.Should().Contain(r => r.Display.Contains("FluentAssertions.dll"));
            refs.Should().Contain(r => r.Display.Contains("System.Configuration.ConfigurationManager"));
        }

        [Fact]
        public async Task Returns_null_if_package_installation_fails()
        {
            var refs = await new PackageRestoreContext().AddPackage("not-a-real-package-definitely-not", "5.7.0");
            refs.Should().BeEmpty();
        }
    }
}