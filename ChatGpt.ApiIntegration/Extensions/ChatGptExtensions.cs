using OpenAI_API;

namespace ChatGpt.ApiIntegration.Extensions;

public static class ChatGptExtensions
{
    public static void AddChatGpt(this WebApplicationBuilder builder)
    {
        var key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        var chat = new OpenAIAPI(key);
        builder.Services.AddSingleton(chat);
    }
}