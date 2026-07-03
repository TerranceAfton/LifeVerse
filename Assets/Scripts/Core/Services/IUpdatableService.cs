namespace LifeVerse.Core.Services
{
    /// <summary>
    /// Services that require Update().
    /// </summary>
    public interface IUpdatableService
    {
        void Update(float deltaTime);
    }
}