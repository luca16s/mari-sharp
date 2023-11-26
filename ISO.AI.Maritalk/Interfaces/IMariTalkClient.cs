// -----------------------------------------------------------------------
// <copyright file="IMariTalkClient.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Interfaces;

using ISO.AI.Maritalk.Models;

/// <summary>
/// Interface para conversação com a API do Maritalk.
/// </summary>
public interface IMariTalkClient
{
    /// <summary>
    /// Método para conversar e conseguir resposta para o Maritalk API.
    /// </summary>
    /// <param name="chat">
    /// Chat a ser passado para o Modelo do Maritalk.
    /// </param>
    /// <returns>
    /// Resposta da API do Maritalk.
    /// </returns>
    Task<ChatResponse?> ChatAsync(Chat? chat);
}
