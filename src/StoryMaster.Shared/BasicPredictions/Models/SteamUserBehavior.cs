using CsvHelper.Configuration;

namespace StoryMaster.Shared.BasicPredictions.Models;

public record SteamUserBehavior(string UserId, string VideoGameName, string Behavior, int Value);

public sealed class SteamUserBehaviorMap : ClassMap<SteamUserBehavior>
{
    public SteamUserBehaviorMap()
    {
        Map(m => m.UserId).Index(0);
        Map(m => m.VideoGameName).Index(1);
        Map(m => m.Behavior).Index(2);
        Map(m => m.Value).Index(3);
    }
}