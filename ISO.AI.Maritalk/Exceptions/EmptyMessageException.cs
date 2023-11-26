// -----------------------------------------------------------------------
// <copyright file="EmptyMessageException.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Exceptions;
using ISO.AI.Maritalk.Models;

using System;
using System.Diagnostics.CodeAnalysis;

public class EmptyMessageException(string message) : Exception(message)
{
    /// <summary>Throws an <see cref="EmptyMessageException"/> if <paramref name="argument"/> is empty.</summary>
    /// <param name="argument">The reference type argument to validate as empty.</param>
    public static void ThrowIfEmpty(
        [NotNull] string message,
        [NotNull] IEnumerable<Message>? argument
    )
    {
        if ((argument?.Any()) == true)
            return;

        Throw(message);
    }

    [DoesNotReturn]
    internal static void Throw(string message) => throw new EmptyMessageException(message);
}
