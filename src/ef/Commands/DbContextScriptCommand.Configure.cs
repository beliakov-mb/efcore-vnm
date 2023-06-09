// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.EntityFrameworkCore.Tools.Properties;

namespace Microsoft.EntityFrameworkCore.Tools.Commands;

internal partial class DbContextScriptCommand : ContextCommandBase
{
    private CommandOption? _output;

    public override void Configure(CommandLineApplication command)
    {
        command.Description = Resources.DbContextScriptDescription;

        _output = command.Option("-o|--output <FILE>", Resources.OutputDescription);

        base.Configure(command);
    }
}
