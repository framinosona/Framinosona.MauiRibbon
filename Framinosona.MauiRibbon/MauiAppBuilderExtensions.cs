namespace Framinosona.MauiRibbon;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseRibbon(this MauiAppBuilder builder,string text, Color? fontColor = null, Color? ribbonColor = null)
    {
        builder.ConfigureMauiHandlers(_ =>
        {
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping("AddDebugOverlay", (handler, _) =>
            {
                var overlay = new RibbonOverlay(handler.VirtualView, text, fontColor, ribbonColor);
                handler.VirtualView.AddOverlay(overlay);
            });
        });


        return builder;
    }
}