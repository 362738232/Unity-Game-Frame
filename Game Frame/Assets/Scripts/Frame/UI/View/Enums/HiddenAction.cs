namespace Lzj.UI.View
{
    [System.Flags]
    public enum HiddenAction
    {
        DisableCanvas = 1 << 1,
        DisableGameObject = 1 << 2,
        DisableGraphicRaycaster = 1 << 3,
        All = DisableCanvas | DisableGameObject | DisableGraphicRaycaster
    }
}


