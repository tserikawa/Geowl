using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Geowl.Core.Primitive;

namespace Geowl.Visualizer.Commands;


public class DrawLineCommand : ICommand
{
    private readonly Canvas _canvas;
    private readonly Line2D _line;
    private readonly double _width;

    public DrawLineCommand(Canvas canvas, Line2D line, double width = 3)
    {
        _canvas = canvas;
        _line = line;
        _width = width;
    }

    public void Execute()
    {
        var line = new Line
        {
            StartPoint = new Point(_line.Start.X, _line.Start.Y),
            EndPoint = new Point(_line.End.X, _line.End.Y),
            Stroke = Brushes.Black,
            StrokeThickness = _width,
        };

        _canvas.Children.Add(line);
    }
}