using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using StoryMaster.Shared.BasicPredictions.Models;

namespace StoryMaster.Shared.Utilities;

public record CsvParserOptions(string FileName, int? RecordsToPull = null)
{
    public bool IsFinishedPullingRecords(int recordsPulled) => RecordsToPull.HasValue && RecordsToPull.Value == recordsPulled;
}

public interface ICsvParser<T>
{
    Task<List<T>> ReadFromFileAsync(CsvParserOptions parserOptions, CancellationToken cancellationToken);
}

public class CsvParser<T>(IRandomNumberProvider randomNumberProvider) : ICsvParser<T>
{
    private readonly IRandomNumberProvider _randomNumberProvider = randomNumberProvider;

    public async Task<List<T>> ReadFromFileAsync(CsvParserOptions parserOptions, CancellationToken cancellationToken)
    {
        var csvReaderConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };
        using var streamReader = new StreamReader(parserOptions.FileName);
        using var csv = new CsvReader(streamReader, csvReaderConfig);
        csv.Context.RegisterClassMap<SteamUserBehaviorMap>();
        var records = new List<T>();

        while (await csv.ReadAsync())
        {
            var line = csv.GetRecord<T>();
            if (line is null) continue;
            records.Add(line);
        }

        return records;
    }
}
