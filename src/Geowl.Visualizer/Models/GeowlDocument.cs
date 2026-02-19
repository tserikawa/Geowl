using System.Collections.Generic;

namespace Geowl.Visualizer.Models;

using Avalonia.Controls.Shapes;

/// <summary>
/// 描画されたすべてのジオメトリを管理するクラス
/// </summary>
public sealed class GeowlDocument
{
    /// <summary>
    /// 描画されている点のリスト
    /// </summary>
    private readonly List<Ellipse> _points = new();

    /// <summary>
    /// 描画されている線分のリスト
    /// </summary>
    private readonly List<Line> _lines = new();

    /// <summary>
    /// 点を追加します
    /// </summary>
    public void AddPoint(Ellipse point)
    {
        _points.Add(point);
    }

    /// <summary>
    /// 線分を追加します
    /// </summary>
    public void AddLine(Line line)
    {
        _lines.Add(line);
    }

    /// <summary>
    /// すべての点を取得します
    /// </summary>
    public IReadOnlyList<Ellipse> Points => _points.AsReadOnly();

    /// <summary>
    /// すべての線分を取得します
    /// </summary>
    public IReadOnlyList<Line> Lines => _lines.AsReadOnly();

    /// <summary>
    /// すべての点をクリアします
    /// </summary>
    public void ClearPoints()
    {
        _points.Clear();
    }

    /// <summary>
    /// すべての線分をクリアします
    /// </summary>
    public void ClearLines()
    {
        _lines.Clear();
    }

    /// <summary>
    /// すべてのジオメトリをクリアします
    /// </summary>
    public void Clear()
    {
        _points.Clear();
        _lines.Clear();
    }
}
