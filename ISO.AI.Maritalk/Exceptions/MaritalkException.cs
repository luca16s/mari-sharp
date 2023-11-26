// -----------------------------------------------------------------------
// <copyright file="MaritalkException.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Net;

public class MaritalkException(string message) : Exception(message)
{
    [DoesNotReturn]
    internal static void Throw([NotNull] string message) => throw new MaritalkException(message);

    /// <summary>Throws an <see cref="MaritalkException"/> if <paramref name="response"/> is empty.</summary>
    /// <param name="response">The reference type argument to validate as empty.</param>
    public static void ThrowIfNull(
        [NotNull] string message,
        [NotNull] HttpResponseMessage response
    )
    {
        if (response is not null)
            return;

        Throw(message);
    }

    /// <summary>Throws an <see cref="MaritalkException"/> if <paramref name="statusCode"/> has to many requests.</summary>
    /// <param name="statusCode">The reference type argument to validate amount of requests.</param>
    public static void ThrowIfMaxAttemptedIsReached(
        [NotNull] string message,
        [NotNull] HttpResponseMessage response
    )
    {
        if (response.StatusCode != HttpStatusCode.TooManyRequests)
            return;

        Throw(message);
    }
}
