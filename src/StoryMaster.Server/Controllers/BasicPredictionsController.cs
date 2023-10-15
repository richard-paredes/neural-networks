using Microsoft.AspNetCore.Mvc;
using StoryMaster.Shared.BasicPredictions.Models;
using StoryMaster.Shared.Utilities;

namespace StoryMaster.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BasicPredictionsController(
    ILogger<BasicPredictionsController> logger,
    ICsvParser<SteamUserBehavior> csvParser)
        : ControllerBase
{
    private readonly ILogger<BasicPredictionsController> _logger = logger;
    private readonly ICsvParser<SteamUserBehavior> _csvParser = csvParser;

    [HttpGet("data")]
    public async Task<ActionResult<List<SteamUserBehavior>>> Get(string fileName, int? recordsToPull, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request to retrieve data for SteamUserBehavior");
        if (string.IsNullOrWhiteSpace(fileName)) return BadRequest("Error!");

        var options = new CsvParserOptions(fileName, recordsToPull);
        return await _csvParser.ReadFromFileAsync(options, cancellationToken);
    }
}