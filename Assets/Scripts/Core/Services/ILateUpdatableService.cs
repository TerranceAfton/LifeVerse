namespace LifeVerse.Core.Services
{
    /// <summary>
    /// Services that require LateUpdate().
    /// </summary>
    public interface ILateUpdatableService
    {
        void LateUpdate(float deltaTime);
    }
}