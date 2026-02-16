using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Geowl.Core.Primitive;
using Geowl.Visualizer.Models;

namespace Geowl.Visualizer.Commands;

public class DrawPointCommand : ICommand
{
    private readonly GeowlDocument _document;
    private readonly Canvas _canvas;
    private readonly Point2D _point;
    private readonly double _radius;

    public DrawPointCommand(GeowlDocument document, Canvas canvas, Point2D point, double radius = 5)
    {
        _document = document;
        _canvas = canvas;
        _point = point;
        _radius = radius;
    }

    public void Execute()
    {
        var ellipse = new Ellipse
        {
            Width = _radius * 2,
            Height = _radius * 2,
            Fill = Brushes.Red,
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };

        Canvas.SetLeft(ellipse, _point.X - _radius);
        Canvas.SetTop(ellipse, _point.Y - _radius);

        _canvas.Children.Add(ellipse);
        _document.AddPoint(ellipse);
    }
}