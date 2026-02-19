using Geowl.Core.Primitive;

namespace Geowl.Visualizer.Tools;

/// <summary>
/// 描画ツールの基本インターフェース
/// </summary>
public interface ITool
{
    /// <summary>
    /// 表示名
    /// </summary>
    string Name { get; }

    /// <summary>
    /// ツールが有効化されたときに呼ばれます
    /// </summary>
    void Activate();

    /// <summary>
    /// ツールが無効化されたときに呼ばれます
    /// </summary>
    void Deactivate();

    /// <summary>
    /// Canvas上でポインターが押されたときに呼ばれます
    /// </summary>
    /// <param name="position">クリック位置</param>
    void OnPointerPressed(Point2D position);
}
