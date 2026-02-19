using Avalonia.Controls;
using Geowl.Core.Primitive;
using Geowl.Visualizer.Commands;
using Geowl.Visualizer.Models;

namespace Geowl.Visualizer.Tools;

/// <summary>
/// 線分追加ツール
/// </summary>
public class LineTool : ITool
{
    private readonly GeowlDocument _document;
    private readonly Canvas _canvas;
    private readonly CommandInvoker _commandInvoker;

    // ツールの内部状態
    private bool _hasFirstPoint;
    private Point2D _firstPoint;

    public LineTool(Canvas canvas, CommandInvoker commandInvoker, GeowlDocument document)
    {
        _document = document;
        _canvas = canvas;
        _commandInvoker = commandInvoker;
    }

    /// <inheritdoc/>
    public string Name => "線分追加モード";

    /// <inheritdoc/>
    public void Activate()
    {
        _hasFirstPoint = false;
        _firstPoint = Point2D.Unset;
    }

    /// <inheritdoc/>
    public void Deactivate()
    {
        _hasFirstPoint = false;
        _firstPoint = Point2D.Unset;
    }

    /// <inheritdoc/>
    public void OnPointerPressed(Point2D position)
    {
        if (!_hasFirstPoint)
        {
            // 1点目の処理
            _firstPoint = position;
            _hasFirstPoint = true;

            // 視覚的フィードバック：1点目を描画
            var pointCommand = new DrawPointCommand(_canvas, _document, position);
            _commandInvoker.Execute(pointCommand);
        }
        else
        {
            // 2点目の処理
            // 2点目も描画
            var pointCommand = new DrawPointCommand(_canvas, _document, position);
            _commandInvoker.Execute(pointCommand);

            // 線分を描画
            var line = new Line2D(_firstPoint, position);
            var lineCommand = new DrawLineCommand(_canvas, _document, line);
            _commandInvoker.Execute(lineCommand);

            // 状態をリセット（次の線分のため）
            _hasFirstPoint = false;
            _firstPoint = Point2D.Unset;
        }
    }
}
