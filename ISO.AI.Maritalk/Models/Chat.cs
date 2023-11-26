// -----------------------------------------------------------------------
// <copyright file="Chat.cs" company="Îakaré Software'Oka">
//     Copyright (c) Îakaré Software'Oka.
//     All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace ISO.AI.Maritalk.Models;

using Newtonsoft.Json;

public class Chat
{
    [JsonProperty("top_p")]
    /// <summary>
    /// Se menor que 1, mantém apenas os tokens superiores com probabilidade cumulativa >= top_p (filtragem do núcleo).
    /// Por exemplo, 0.95 significa que apenas os tokens que compõem os 95% superiores da massa de probabilidade são considerados quando prevendo o próximo token.
    /// A filtragem do núcleo é descrita em Holtzman et al. (http://arxiv.org/abs/1904.09751).
    /// </summary>
    public double TopP { get; set; } = 1.0d;

    [JsonProperty("max_tokens")]
    /// <summary>
    /// Número máximo de tokens que serão gerados pelo modelo.
    /// </summary>
    public int MaxTokens { get; set; } = 100;

    [JsonProperty("chat_mode")]
    /// <summary>
    /// Se True, o modelo será executado no modo chat, onde messages é uma string contendo a mensagem do usuário ou uma lista de mensagens contendo as iterações da conversa entre usuário e assistente.
    /// Se False, messages deve ser uma string contendo o prompt desejado.
    /// </summary>
    public bool ChatMode { get; set; } = true;

    [JsonProperty("do_sample")]
    /// <summary>
    /// Se True, a geração do modelo será amostrada via top-k sampling.
    /// Caso contrário, a geração sempre selecionará o token com maior probabilidade.
    /// Usar do_sample=False leva a um resultado deterministico, porém com menos diversidade.
    /// </summary>
    public bool DoSample { get; set; } = true;

    [JsonProperty("model")]
    /// <summary>
    /// Nome do modelo que será utilizado para inferência. Atualmente, apenas o modelo "maritalk" está disponível.
    /// </summary>
    public string Model { get; set; } = "maritalk";

    [JsonProperty("temperature")]
    /// <summary>
    /// Temperatura de amostragem (maior ou igual à zero).
    /// Valores mais altos levam a uma maior diversidade de geração, mas também a uma maior probabilidade de gerar textos sem sentido.
    /// Valores mais próximos de zero levam a textos mais plausíveis, porém aumentam as chances de gerar textos repetidos.
    /// </summary>
    public double Temperature { get; set; } = 1.0d;

    [JsonProperty("repetition_penalty")]
    /// <summary>
    /// Penalidade de repetição.
    /// Valores positivos incentivam o modelo a não repetir tokens gerados anteriormente.
    /// </summary>
    public double RepetitionPenalty { get; set; } = 1.0d;

    [JsonProperty("messages")]
    /// <summary>
    /// Mensagens que serão enviadas ao modelo.
    /// Se chat_mode=True, é esperada uma string ou uma lista, onde cada item deve ser um dicionário contendo as chaves role e content.
    /// Por exemplo: messages = [ {"role": "user", "content": "bom dia, esta é a mensagem do usuario"},
    /// {"role": "assistant", "content": "bom dia, esta é a resposta do assistente"},
    /// {"role": "user", "content": "Você pode me falar quanto é 25 + 27?"}, ]
    /// Se chat_mode = False, é esperado que messages seja uma string contendo o prompt desejado.
    /// </summary>
    public IEnumerable<Message> Messages { get; set; } = new List<Message>();

    [JsonProperty("stopping_tokens")]
    /// <summary>
    /// Lista de tokens que, quando gerados, indicam que o modelo deve parar de gerar tokens.
    /// </summary>
    public IEnumerable<string> StoppingTokens { get; set; } = new List<string>();
}
