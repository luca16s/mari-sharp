// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Models;

using Newtonsoft.Json;

public class Message
{
    [JsonProperty("role")]
    /// <summary>
    /// Indica o tipo da mensagem.
    /// <see cref="Role.User">Indica a mensagem do usuário.</see>
    /// <see cref="Role.Assistant">Indica a mensagem do assistente.</see>
    /// </summary>
    public required string Role { get; set; }

    [JsonProperty("content")]
    /// <summary>
    /// Conteúdo da mensagem.
    /// </summary>
    public required string Content { get; set; }
}
