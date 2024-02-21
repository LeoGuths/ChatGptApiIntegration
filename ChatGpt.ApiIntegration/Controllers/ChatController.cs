using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace ChatGpt.ApiIntegration.Controllers;

[Route("bot/[controller]")]
public class ChatController(IOpenAIAPI chatGpt) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Chat([FromQuery(Name = "prompt")] string prompt)
    {
        var response = string.Empty;

        var completion = new CompletionRequest(prompt: prompt, model: Model.ChatGPTTurbo, max_tokens: 200);
        // var completion = new CompletionRequest(prompt: prompt, model: Model.Davinci, max_tokens: 200);
        var result = await chatGpt.Completions.CreateCompletionAsync(completion);
        result.Completions.ForEach(r => response = r.Text);
        
        return Ok(response);
    }
}