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
using Geowl.Visualizer.Tools;

namespace Geowl.Visualizer;

public partial class MainWindow : Window
{
    private GeowlDocument _document = new();
    private List<Line> _lines = new List<Line>();

    // ツール関連
    private readonly CommandInvoker _commandInvoker = new();
    private ITool _currentTool;
    private readonly PointTool _pointTool;
    private readonly LineTool _lineTool;

    public MainWindow()
    {
        InitializeComponent();

        // ツールを初期化
        _pointTool = new PointTool(MainCanvas, _commandInvoker);
        _lineTool = new LineTool(MainCanvas, _commandInvoker);

        // デフォルトはPointToolを有効化
        _currentTool = _pointTool;
        _currentTool.Activate();

        // 初期表示用のサンプル（後で削除予定）
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
        var command = new DrawPointCommand(MainCanvas, point, radius);
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

        // 現在のツールに処理を委譲
        _currentTool.OnPointerPressed(point);
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
        // 現在のツールを無効化
        _currentTool.Deactivate();

        // LineToolに切り替え
        _currentTool = _lineTool;
        _currentTool.Activate();
    }
}