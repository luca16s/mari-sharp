// -----------------------------------------------------------------------
// <copyright file="Role.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Models;

using System.ComponentModel;

/// <summary>
/// Initializes a new instance of <see cref="Role"/>.
/// </summary>
/// <exception cref="ArgumentNullException">
/// <paramref name="value"/> is null.
/// </exception>
public readonly struct Role(string value) : IEquatable<Role>
{
    private readonly string value = value ?? throw new ArgumentNullException(nameof(value));
    private const string UserValue = "user";
    private const string AssistantValue = "assistant";

    public static Role User { get; } = new Role(UserValue);
    public static Role Assistant { get; } = new Role(AssistantValue);

    /// <summary>
    /// Converts a string to a <see cref="Role"/>.
    /// </summary>
    public static implicit operator Role(string value) => new(value);

    /// <summary>
    /// Determines if two <see cref="Role"/> values are the same.
    /// </summary>
    public static bool operator ==(Role left, Role right) => left.Equals(right);

    /// <summary>
    /// Determines if two <see cref="ChatRole"/> values are not the same.
    /// </summary>
    public static bool operator !=(Role left, Role right) => !left.Equals(right);

    /// <inheritdoc />
    public override string ToString() => value;

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => value?.GetHashCode() ?? 0;

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is Role other && Equals(other);

    /// <inheritdoc />
    public bool Equals(Role other) => string.Equals(value, other.value, StringComparison.InvariantCultureIgnoreCase);
}
