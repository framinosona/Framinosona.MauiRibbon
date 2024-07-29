namespace Framinosona.MauiRibbon;

public sealed class RibbonOverlay(
    IWindow window,
    string text,
    Color? fontColor = null,
    Color? ribbonColor = null)
    : WindowOverlay(window)
{
    private RibbonElement Ribbon { get; } = new(text, fontColor, ribbonColor);

    public override bool Initialize()
    {
        var result = base.Initialize();
        AddWindowElement(Ribbon);
        return result;
    }

    public override bool Deinitialize()
    {
        RemoveWindowElement(Ribbon);
        return base.Deinitialize();
    }
}