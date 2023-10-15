namespace StoryMaster.Shared.Utilities;

public interface IRandomNumberProvider
{
    int GetRandomNumber(int minimum, int maximum);
}

public class RandomNumberProvider : IRandomNumberProvider
{
    public int GetRandomNumber(int minimum, int maximum) => Random.Shared.Next(minimum, maximum + 1);
}
