// -----------------------------------------------------------------------
// <copyright file="MariTalkClient.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Services;

using ISO.AI.Maritalk.Exceptions;
using ISO.AI.Maritalk.Interfaces;
using ISO.AI.Maritalk.Models;
using ISO.AI.Maritalk.Utils;

using System.Net.Http.Headers;
using System.Threading.Tasks;

public class MariTalkClient : IMariTalkClient
{
    private const string Auth_Header = "Key";
    private readonly HttpClient client = new();
    private const string MediaType = "application/json";
    private const string endpoint = $"https://chat.maritaca.ai/api/chat/";

    public MariTalkClient(
        ISettings settings
    )
    {
        client.BaseAddress = new Uri(endpoint);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Auth_Header, settings.Key);
    }

    public async Task<ChatResponse?> ChatAsync(
        Chat? request
    )
    {
        ArgumentNullException.ThrowIfNull(request);

        EmptyMessageException.ThrowIfEmpty(
            "Não é possível realizar a consulta sem mensagens.",
            request.Messages
        );

        using HttpResponseMessage response = await client.PostAsync(
        "inference",
                  request.GetContent()
        );

        MaritalkException.ThrowIfNull(
            "Não foi possível realizar a conexão com a API do Maritalk.",
            response
        );

        MaritalkException.ThrowIfMaxAttemptedIsReached(
            "Total máximo de tentativas é limitado a 5, tente novamente em breve.",
            response
        );

        return await response.DeserializeAsync();
    }
}
