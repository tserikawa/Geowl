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
    // ドキュメント（描画オブジェクト管理）
    private readonly GeowlDocument _document = new();

    // ツール関連
    private readonly CommandInvoker _commandInvoker = new();
    private ITool _currentTool;
    private readonly PointTool _pointTool;
    private readonly LineTool _lineTool;

    public MainWindow()
    {
        InitializeComponent();

        // ツールを初期化（documentも渡す）
        _pointTool = new PointTool(MainCanvas, _commandInvoker, _document);
        _lineTool = new LineTool(MainCanvas, _commandInvoker, _document);

        // デフォルトはPointToolを有効化
        _currentTool = _pointTool;
        _currentTool.Activate();
    }

    private void Canvas_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var position = e.GetPosition(MainCanvas);
        var point = new Point2D(position.X, position.Y);
        _currentTool.OnPointerPressed(point);
    }

    public void DeleteAllClickHandler(object? sender, RoutedEventArgs e)
    {
        MainCanvas.Children.RemoveAll(_document.Points);
        MainCanvas.Children.RemoveAll(_document.Lines);
        _document.ClearPoints();
        _document.ClearLines();
    }

    public void DeleteLineClickHandler(object? sender, RoutedEventArgs e)
    {
        MainCanvas.Children.RemoveAll(_document.Lines);
        _document.ClearLines();
    }
    public void AddLineClickHandler(object? sender, RoutedEventArgs e)
    {
        _currentTool.Deactivate();
        _currentTool = _lineTool;
        _currentTool.Activate();
    }
}
