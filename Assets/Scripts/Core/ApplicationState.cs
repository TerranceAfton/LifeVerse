namespace LifeVerse.Core
{
    /// <summary>
    /// Represents the current state of the LifeVerse application.
    /// </summary>
    public enum ApplicationState
    {
        Unknown,

        Boot,
        Splash,
        MainMenu,

        Loading,
        Gameplay,

        BuildMode,
        BuyMode,

        CreateAVerse,

        PhotoMode,

        Paused,

        Saving,
        LoadingSave,

        Exiting
    }
}