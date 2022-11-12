namespace Poem7.Services;

public interface ITodayPoemService
{
    Task<TodayPoem> GetTodayPoemAsync();
}
public static class TodayPoemSources
{
    public const string Jinrishici = nameof(Jinrishici);
    public const string Local = nameof(Local);
}