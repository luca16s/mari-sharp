// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Utils;

using ISO.AI.Maritalk.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Text;
using System.Threading.Tasks;

internal static class Extensions
{
    public static StringContent GetContent(
        this Chat request
    )
    {
        return new StringContent(
            JsonConvert.SerializeObject(request, Formatting.Indented),
            Encoding.UTF8,
            "application/json"
        );
    }

    public static async Task<ChatResponse?> DeserializeAsync(
        this HttpResponseMessage response
    )
    {
        string json = await response.Content.ReadAsStringAsync();

        return string.IsNullOrWhiteSpace(json)
            ? default
            : JsonConvert.DeserializeObject<ChatResponse>(
            json,
            new IsoDateTimeConverter
            {
                DateTimeFormat = "dd/MM/yyyy"
            }
        );
    }
}
