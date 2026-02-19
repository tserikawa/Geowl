using Avalonia.Controls;
using Geowl.Core.Primitive;
using Geowl.Visualizer.Commands;
using Geowl.Visualizer.Models;

namespace Geowl.Visualizer.Tools;

/// <summary>
/// 点追加ツール
/// </summary>
public class PointTool : ITool
{
    private readonly GeowlDocument _document;
    private readonly Canvas _canvas;
    private readonly CommandInvoker _commandInvoker;

    public PointTool(Canvas canvas, CommandInvoker commandInvoker, GeowlDocument document)
    {
        _document = document;
        _canvas = canvas;
        _commandInvoker = commandInvoker;
    }

    public void Activate()
    {
        // このツールは状態を持たないので、特にやることはない
    }

    public void Deactivate()
    {
        // このツールは状態を持たないので、特にやることはない
    }

    public void OnPointerPressed(Point2D position)
    {
        // クリックされた位置に点を描画
        var command = new DrawPointCommand(_canvas, _document, position);
        _commandInvoker.Execute(command);
    }
}
