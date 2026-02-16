using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Controls;
using Avalonia.Media;
using Geowl.Core.Primitive;
using Geowl.Visualizer.Commands;
using Avalonia.Input;
using System;
using Avalonia.Interactivity;
using System.Linq;
using System.Collections.Generic;
using Geowl.Visualizer.Models;

namespace Geowl.Visualizer;

public partial class MainWindow : Window
{
    private GeowlDocument _document = new();

    private List<Line> _lines = new List<Line>();

    /// <summary>
    /// 線分追加モードか
    /// </summary>
    private bool _isLineAddMode = false;

    /// <summary>
    /// 最初の点が選択されたか
    /// </summary>
    private bool _isFirstPointClicked = false;

    /// <summary>
    /// 最初の点
    /// </summary>
    private Point2D _firstPoint = Point2D.Unset;

    private readonly CommandInvoker _commandInvoker = new();

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
        var command = new DrawPointCommand(_document, MainCanvas, point, radius);
        _commandInvoker.Execute(command);
    }

    private void DrawLine(Line2D line2d, double width = 3)
    {
        var command = new DrawLineCommand(MainCanvas, line2d, width);
        _commandInvoker.Execute(command);
    }

    private void Canvas_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var position = e.GetPosition(MainCanvas);
        var point = new Point2D(position.X, position.Y);

        if (!_isLineAddMode)
        {
            DrawPoint(point);
        }
        else
        {
            if (!_isFirstPointClicked)
            {
                _firstPoint = point;
                _isFirstPointClicked = true;
                DrawPoint(point);
            }
            else
            {
                DrawPoint(point);
                var line = new Line2D(_firstPoint, point);
                DrawLine(line);

                _firstPoint = Point2D.Unset;
                _isFirstPointClicked = false;
                _isLineAddMode = false;
            }
        }
    }

    public void DeleteAllClickHandler(object? sender, RoutedEventArgs e)
    {
        foreach (var point in _document.Points)
        {
            _ = MainCanvas.Children.Remove(point);
        }
    }

    public void DeleteLineClickHandler(object? sender, RoutedEventArgs e)
    {
        foreach (var line in _lines)
        {
            _ = MainCanvas.Children.Remove(line);
        }
    }

    public void AddLineClickHandler(object? sender, RoutedEventArgs e)
    {
        _isLineAddMode = true;
        _isFirstPointClicked = false;
        _firstPoint = Point2D.Unset;
    }
}