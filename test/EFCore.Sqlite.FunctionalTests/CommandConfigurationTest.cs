// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable InconsistentNaming

namespace Microsoft.EntityFrameworkCore;

public class CommandConfigurationTest : IClassFixture<CommandConfigurationTest.CommandConfigurationTestFixture>
{
    public CommandConfigurationTest(CommandConfigurationTestFixture fixture)
    {
        Fixture = fixture;
    }

    protected CommandConfigurationTestFixture Fixture { get; }

    [ConditionalFact]
    public void Constructed_select_query_CommandBuilder_throws_when_negative_CommandTimeout_is_used()
    {
        using var context = CreateContext();
        Assert.Throws<ArgumentException>(() => context.Database.SetCommandTimeout(-5));
    }

    protected DbContext CreateContext()
        => Fixture.CreateContext();

    public class CommandConfigurationTestFixture : SharedStoreFixtureBase<PoolableDbContext>
    {
        protected override string StoreName
            => "Empty";

        protected override ITestStoreFactory TestStoreFactory
            => SqliteTestStoreFactory.Instance;
    }
}
