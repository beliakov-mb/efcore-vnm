// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Metadata;

/// <summary>
///     Represents entity type mapping to a table-like object.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and examples.
/// </remarks>
public interface ITableMappingBase : IAnnotatable
{
    /// <summary>
    ///     Gets the mapped entity type.
    /// </summary>
    IEntityType EntityType { get; }

    /// <summary>
    ///     Gets the target table-like object.
    /// </summary>
    ITableBase Table { get; }

    /// <summary>
    ///     Gets the properties mapped to columns on the target table.
    /// </summary>
    IEnumerable<IColumnMappingBase> ColumnMappings { get; }

    /// <summary>
    ///     Gets the value indicating whether this is the mapping for the principal entity type
    ///     if the table-like object is shared. <see langword="null" /> is the table-like object is not shared.
    /// </summary>
    bool? IsSharedTablePrincipal { get; }

    /// <summary>
    ///     Gets the value indicating whether this is the mapping for the principal table-like object
    ///     if the entity type is split. <see langword="null" /> is the entity type is not split.
    /// </summary>
    bool? IsSplitEntityTypePrincipal { get; }

    /// <summary>
    ///     Gets the value indicating whether the mapped table-like object includes rows for the derived entity types.
    ///     Set to <see langword="false" /> for inherited mappings.
    /// </summary>
    bool IncludesDerivedTypes { get; }
}
