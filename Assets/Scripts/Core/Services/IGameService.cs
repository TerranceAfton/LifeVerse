namespace LifeVerse.Core.Services
{
    /// <summary>
    /// Base interface for all engine services.
    /// </summary>
    public interface IGameService
    {
        void Initialize();

        void Shutdown();
    }
}