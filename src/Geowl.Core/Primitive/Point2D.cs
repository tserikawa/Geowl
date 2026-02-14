using System.Diagnostics.CodeAnalysis;

namespace Geowl.Core.Primitive;

/// <summary>
/// 2次元の点を表すクラスです。
/// </summary>
public readonly struct Point2D : IEquatable<Point2D>
{
    /// <summary>
    /// 座標値から<see cref="Point2D"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="x">X座標の値</param>
    /// <param name="y">y座標の値</param>
    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// 未定義の節点を生成します。
    /// </summary>
    public static Point2D Unset => new Point2D(double.MinValue, double.MinValue);

    /// <summary>
    /// X座標を取得します。
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Y座標を取得します。
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// 2つのPoint2Dインスタンスが等しいかどうかを判定します。
    /// </summary>
    /// <param name="left">比較する1つ目のPoint2D</param>
    /// <param name="right">比較する2つ目のPoint2D</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>のX座標とY座標がそれぞれ等しい場合はtrue。それ以外の場合はfalse。
    /// </returns>
    public static bool operator ==(Point2D left, Point2D right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 2つのPoint2Dインスタンスが等しくないかどうかを判定します。
    /// </summary>
    /// <param name="left">比較する1つ目のPoint2D</param>
    /// <param name="right">比較する2つ目のPoint2D</param>
    /// <returns>
    /// <paramref name="left"/>と<paramref name="right"/>のX座標またはY座標が異なる場合はtrue。それ以外の場合はfalse。
    /// </returns>
    public static bool operator !=(Point2D left, Point2D right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 別の点<paramref name="other"/>との距離を計算します。
    /// </summary>
    /// <param name="other">距離を計算したい点</param>
    /// <returns>距離</returns>
    public readonly double DistanceTo(Point2D other)
    {
        var dx = Math.Abs(X - other.X);
        var dy = Math.Abs(Y - other.Y);
        return Math.Sqrt((dx * dx) + (dy * dy));
    }

    /// <inheritdoc/>
    public bool Equals(Point2D other)
    {
        return X == other.X && Y == other.Y;
    }

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != typeof(Point2D))
        {
            return false;
        }

        return Equals((Point2D)obj);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
