namespace Framinosona.MauiRibbon;

public class RibbonElement : BindableObject, IWindowOverlayElement
{
    private RectF _backgroundRect;
    private readonly Microsoft.Maui.Graphics.Font _font;
    private readonly string _text;
    private readonly Color _fontColor;
    private readonly Color _ribbonColor;
    private readonly PathF _ribbonPath;

    private const float RibbonWidth = 130;
    private const float RibbonHeight = 25;

    public RibbonElement(string text, Color? fontColor = null, Color? ribbonColor = null)
    {
        _text = text;
        _fontColor = fontColor ?? Colors.White;
        _font = new Microsoft.Maui.Graphics.Font("ArialMT", 800);
        _ribbonColor = ribbonColor ?? Colors.Firebrick;
        _backgroundRect = new RectF();
        _ribbonPath = new PathF();
        _ribbonPath.MoveTo(-RibbonWidth / 2, -RibbonHeight / 2);
        _ribbonPath.LineTo(RibbonWidth / 2, -RibbonHeight / 2);
        _ribbonPath.LineTo(RibbonWidth / 2, RibbonHeight / 2);
        _ribbonPath.LineTo(-RibbonWidth / 2, RibbonHeight / 2);
        _ribbonPath.Close();
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Calculate the position of the ribbon in the lower right corner
        var ribbonX = dirtyRect.Right - (RibbonWidth * 0.25f);
        var ribbonY = dirtyRect.Bottom - (RibbonHeight + (RibbonHeight * 0.05f));

        // Set the background rectangle
        _backgroundRect = new RectF(ribbonX, ribbonY, RibbonWidth, RibbonHeight);
        
        // Translate the canvas to the start point of the ribbon
        canvas.Translate(ribbonX, ribbonY);

        // Save the current state of the canvas
        canvas.SaveState();
        // Rotate the canvas 45 degrees
        canvas.Rotate(-45);

        // Draw the ribbon background
        canvas.FillColor = _ribbonColor;

        canvas.FillPath(_ribbonPath);

        // Draw the text
        canvas.FontColor = _fontColor;
        canvas.FontSize = 12;
        canvas.Font = _font;
        canvas.DrawString(_text,
            new RectF(
                (-RibbonWidth / 2),
                (-RibbonHeight / 2) + 2,
                RibbonWidth,
                RibbonHeight),
            HorizontalAlignment.Center, VerticalAlignment.Center);


        // Restore the canvas state
        canvas.RestoreState();
    }

    public bool Contains(Point point)
    {
        return _backgroundRect.Contains(point);
    }
}