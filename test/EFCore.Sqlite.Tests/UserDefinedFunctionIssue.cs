// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore;

public class UserDefinedFunctionIssue
{
    [ConditionalFact]
    public void TestMethod()
    {
        using var context = new DemoContext();
        // var q = context.CustomerBalances
        //     .Where(c => c.Customer.Name == "123");

        var q = context.CustomerBalances
            .Where(
                c =>
                    MyDefinedFunctions.MyDefinedFunction(
                        context.CustomerBalances
                            .Count(x => x.CustomerId == 123)
                    ).Any());

        // var q = context.CustomerBalances
        //     .Where(
        //         c =>
        //             MyDefinedFunctions.MyDefinedFunction(
        //                 context.CustomerBalances
        //                     .Count(x => x.Customer.Name == "123")
        //             ).Any());docker

        Console.WriteLine(q.ToQueryString());
    }
}

public class DemoContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerBalance> CustomerBalances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ValueAsQueryableIntResultDto>().HasNoKey().ToFunction("MyDefinedFunctions");

        modelBuilder.HasDbFunction(
            typeof(MyDefinedFunctions).GetMethod(nameof(MyDefinedFunctions.MyDefinedFunction), new[] { typeof(int) })!);
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public int CustomerBalanceId { get; set; }
    // [ForeignKey("CustomerBalanceId")]
    //public CustomerBalance CustomerBalance { get; set; }
}

public class CustomerBalance
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

public static class MyDefinedFunctions
{
    public static IQueryable<ValueAsQueryableIntResultDto> MyDefinedFunction(int value)
        => throw new NotSupportedException();
}

public class ValueAsQueryableIntResultDto
{
    public int? Value { get; set; }
}
