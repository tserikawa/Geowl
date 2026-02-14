using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Controls;
using Avalonia.Media;
using Geowl.Core.Primitive;
using Avalonia.Input;
using System;
using Avalonia.Interactivity;
using System.Linq;
using System.Collections.Generic;

namespace Geowl.Visualizer;

public partial class MainWindow : Window
{
    private List<Line> _lines = new List<Line>();

    public MainWindow()
    {
        InitializeComponent();

        // Point2Dオブジェクトを描画
        var point1 = new Point2D(100, 100);
        var point2 = new Point2D(200, 200);
        var point3 = new Point2D(100, 200);
        var point4 = new Point2D(200, 100);

        DrawPoint(point1);
        DrawPoint(point2);
        DrawPoint(point3);
        DrawPoint(point4);

        var line1 = new Line2D(point1, point2);
        DrawLine(line1);
        var line2 = new Line2D(point3, point4);
        DrawLine(line2);

    }

    private void DrawPoint(Point2D point, double radius = 5)
    {
        var ellipse = new Ellipse
        {
            Width = radius * 2,
            Height = radius * 2,
            Fill = Brushes.Red,
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };

        Canvas.SetLeft(ellipse, point.X - radius);
        Canvas.SetTop(ellipse, point.Y - radius);

        MainCanvas.Children.Add(ellipse);
    }

    private void DrawLine(Line2D line2d, double width = 3)
    {
        var line = new Line
        {
            StartPoint = new Point(line2d.Start.X, line2d.Start.Y),
            EndPoint = new Point(line2d.End.X, line2d.End.Y),
            Stroke = Brushes.Black,
            Width = width,
        };
        MainCanvas.Children.Add(line);
        _lines.Add(line);
    }

    private void Canvas_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // クリック位置を取得
        var position = e.GetPosition(MainCanvas);

        // Point2D に変換
        var point = new Point2D(position.X, position.Y);
        // _points.Add(point);

        // 点を描画
        DrawPoint(point);
    }

    public void DeleteAllClickHandler(object? sender, RoutedEventArgs e)
    {
        MainCanvas.Children.Clear();
    }

    public void DeleteLineClickHandler(object? sender, RoutedEventArgs e)
    {
        foreach (var line in _lines)
        {
            _ = MainCanvas.Children.Remove(line);
        }
    }
}