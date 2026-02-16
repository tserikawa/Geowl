using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;

namespace Geowl.Visualizer.Models;

public sealed class GeowlDocument
{
    /// <summary>
    /// 描画されている点のリスト
    /// </summary>
    private List<Ellipse> _points = new();

    /// <summary>
    /// 描画されている線分のリスト
    /// </summary>
    private List<Line> _lines = new();

    public GeowlDocument()
    {
    }

    public List<Ellipse> Points => _points;

    public void AddPoint(Ellipse point)
    {
        _points.Add(point);
    }

    public void DeleteAllPoints()
    {
        _points.Clear();
    }
}