// -----------------------------------------------------------------------
// <copyright file="ChatResponse.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Models;
public class ChatResponse
{
    /// <summary>
    /// Resposta do modelo para pergunta.
    /// </summary>
    public string Answer { get; set; } = string.Empty;
}
