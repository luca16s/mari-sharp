namespace ISO.AI.Maritalk.Tests
{
    using ISO.AI.Maritalk.Exceptions;
    using ISO.AI.Maritalk.Models;
    using ISO.AI.Maritalk.Services;

    using Microsoft.Extensions.Configuration;

    using System.Threading.Tasks;

    public class MariTalkClientTest
    {
        private readonly MariTalkClient Client;
        private IConfiguration Configuration { get; }

        public MariTalkClientTest()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<MariTalkClientTest>();
            Configuration = builder.Build();

            Client = new(new Settings { Key = Configuration["Maritalk:Key"] });
        }

        [Fact]
        public async Task ShouldReturnEmptyExceptionWhenMessageIsEmpty()
        {
            EmptyMessageException result = await Assert.ThrowsAsync<EmptyMessageException>(
                () => Client.ChatAsync(
                    new()
                    {
                        TopP = 0.95,
                        DoSample = true,
                        MaxTokens = 200,
                        Temperature = 0.7,
                        Messages = [],
                    })
            );

            Assert.Equal("Não é possível realizar a consulta sem mensagens.", result.Message);
        }

        [Fact]
        public async Task ShouldReturnExceptionWhenRequestIsNull()
        {
            ArgumentNullException result = await Assert.ThrowsAsync<ArgumentNullException>(
                () => Client.ChatAsync(null)
            );

            Assert.Equal("Value cannot be null. (Parameter 'request')", result.Message);
        }

        [Fact]
        public async Task ShouldReturnRespostaCorreta()
        {
            List<Message> messages =
            [
                new()
                {
                    Role = Role.User.ToString(),
                    Content = "bom dia, esta é a mensagem do usuario"
                },
                new()
                {
                    Role = Role.Assistant.ToString(),
                    Content = "bom dia, esta é a resposta do assistente"
                },
                new()
                {
                    Role = Role.User.ToString(),
                    Content = "Você pode me falar quanto é 25 + 27?"
                }
            ];

            ChatResponse? result = await Client.ChatAsync(
                new()
                {
                    TopP = 0.95,
                    DoSample = true,
                    MaxTokens = 200,
                    Temperature = 0.7,
                    Messages = messages,
                }
            );

            Assert.NotNull(result);
            Assert.NotEmpty(result.Answer);
        }
    }
}