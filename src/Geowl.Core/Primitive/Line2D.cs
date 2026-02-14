using System.Diagnostics.CodeAnalysis;

namespace Geowl.Core.Primitive;

/// <summary>
/// 2次元の線分クラス
/// </summary>
public readonly struct Line2D : IEquatable<Line2D>
{
    /// <summary>
    /// 視点と終点から<see cref="Line2D"/>のインスタンスを初期化します。
    /// </summary>
    /// <param name="start">始点</param>
    /// <param name="end">終点</param>
    public Line2D(Point2D start, Point2D end)
    {
        Start = start;
        End = end;
    }

    /// <summary>
    /// 線分の始点を取得します。
    /// </summary>
    public Point2D Start { get; } = Point2D.Unset;

    /// <summary>
    /// 線分の終点を取得します。
    /// </summary>
    public Point2D End { get; } = Point2D.Unset;

    public static bool operator ==(Line2D left, Line2D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Line2D left, Line2D right)
    {
        return !(left == right);
    }

    /// <inheritdoc/>
    public bool Equals(Line2D other)
    {
        return Start == other.Start && End == other.End;
    }

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != typeof(Line2D))
        {
            return false;
        }

        return Equals((Line2D)obj);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }
}
