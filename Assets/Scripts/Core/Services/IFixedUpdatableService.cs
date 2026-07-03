namespace LifeVerse.Core.Services
{
    /// <summary>
    /// Services that require FixedUpdate().
    /// </summary>
    public interface IFixedUpdatableService
    {
        void FixedUpdate(float fixedDeltaTime);
    }
}