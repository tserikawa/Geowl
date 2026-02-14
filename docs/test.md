# .NET テスト作成ガイド（簡潔版）

## テストの5つの観点

### 1. **正常系** - 期待通りに動くか
```csharp
[Fact]
public void Add_TwoNumbers_ReturnsSum()
{
    var calc = new Calculator();
    Assert.Equal(5, calc.Add(2, 3));
}
```

### 2. **異常系** - エラー処理は正しいか
```csharp
[Fact]
public void Divide_ByZero_ThrowsException()
{
    var calc = new Calculator();
    Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
}
```

### 3. **境界値** - 端の値で動くか
```csharp
[Theory]
[InlineData(0, 0)]           // ゼロ
[InlineData(-1, -1)]         // 負の値
[InlineData(double.MaxValue, double.MaxValue)]  // 最大値
public void Constructor_BoundaryValues_Works(double x, double y)
{
    var point = new Point2D(x, y);
    Assert.Equal(x, point.X);
}
```

### 4. **等価性** - 値の比較は正しいか（値オブジェクト必須）
```csharp
[Fact]
public void Equals_SameValues_ReturnsTrue()
{
    var p1 = new Point2D(1, 2);
    var p2 = new Point2D(1, 2);
    Assert.Equal(p1, p2);
}
```

### 5. **null安全性** - nullを正しく扱えるか
```csharp
[Fact]
public void Method_NullArgument_ThrowsException()
{
    Assert.Throws<ArgumentNullException>(() => obj.Method(null));
}
```

---

## 基本パターン（AAA）

```csharp
[Fact]
public void メソッド名_状態_期待結果()
{
    // Arrange - 準備
    var obj = new MyClass();
    
    // Act - 実行
    var result = obj.Method();
    
    // Assert - 検証
    Assert.Equal(expected, result);
}
```

---

## 今回のプロジェクト用テンプレート

### Point2D のテスト

```csharp
public class Point2DTests
{
    // 1. 正常系 - 構築
    [Theory]
    [InlineData(0, 0)]
    [InlineData(3, 4)]
    [InlineData(-1, -2)]
    public void Constructor_ValidValues_SetsProperties(double x, double y)
    {
        var point = new Point2D(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    // 2. 等価性 - 同じ値
    [Fact]
    public void Equals_SameValues_ReturnsTrue()
    {
        var p1 = new Point2D(3, 4);
        var p2 = new Point2D(3, 4);
        Assert.Equal(p1, p2);
    }

    // 3. 等価性 - 異なる値
    [Fact]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        var p1 = new Point2D(3, 4);
        var p2 = new Point2D(5, 6);
        Assert.NotEqual(p1, p2);
    }

    // 4. 等価性 - null
    [Fact]
    public void Equals_Null_ReturnsFalse()
    {
        var point = new Point2D(3, 4);
        Assert.False(point.Equals(null));
    }

    // 5. HashCode - 同じ値は同じハッシュ
    [Fact]
    public void GetHashCode_SameValues_ReturnsSameHash()
    {
        var p1 = new Point2D(3, 4);
        var p2 = new Point2D(3, 4);
        Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
    }

    // 6. 文字列表現
    [Fact]
    public void ToString_ReturnsExpectedFormat()
    {
        var point = new Point2D(3, 4);
        Assert.Equal("(3, 4)", point.ToString());
    }
}
```

### Line2D のテスト（例）

```csharp
public class Line2DTests
{
    [Fact]
    public void Constructor_TwoPoints_CreatesLine()
    {
        var p1 = new Point2D(0, 0);
        var p2 = new Point2D(3, 4);
        var line = new Line2D(p1, p2);
        
        Assert.Equal(p1, line.Start);
        Assert.Equal(p2, line.End);
    }

    [Fact]
    public void Length_RightTriangle_Returns5()
    {
        var line = new Line2D(new Point2D(0, 0), new Point2D(3, 4));
        Assert.Equal(5.0, line.Length, precision: 10);
    }

    [Fact]
    public void Constructor_NullPoint_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => 
            new Line2D(null, new Point2D(1, 1)));
    }
}
```

---

## よく使うアサーション

```csharp
// 値の比較
Assert.Equal(expected, actual);
Assert.NotEqual(expected, actual);

// 真偽値
Assert.True(condition);
Assert.False(condition);

// null
Assert.Null(value);
Assert.NotNull(value);

// 例外
Assert.Throws<ExceptionType>(() => code);

// 浮動小数点（精度指定）
Assert.Equal(expected, actual, precision: 10);
```

---

## データ駆動テスト

```csharp
[Theory]
[InlineData(0, 0, 0)]
[InlineData(3, 4, 5)]
[InlineData(-3, -4, 5)]
public void Distance_VariousPoints_ReturnsCorrectValue(
    double x, double y, double expected)
{
    var origin = new Point2D(0, 0);
    var point = new Point2D(x, y);
    
    var distance = origin.DistanceTo(point);
    
    Assert.Equal(expected, distance, precision: 10);
}
```

---

## テスト実行

```bash
# すべて実行
dotnet test

# 詳細表示
dotnet test -v detailed

# 特定のクラスのみ
dotnet test --filter "FullyQualifiedName~Point2DTests"
```

---

## チェックリスト（最小限）

### 値オブジェクト（Point2D等）
- [ ] コンストラクタ - 値が正しく設定される
- [ ] Equals - 同じ値でtrue
- [ ] Equals - 異なる値でfalse
- [ ] Equals - nullでfalse
- [ ] GetHashCode - 同じ値で同じハッシュ
- [ ] ToString - 期待通りのフォーマット

### 計算メソッド（DistanceTo等）
- [ ] 正常系 - 典型的な値で正しく計算
- [ ] 境界値 - ゼロ、負の値、最大値
- [ ] null - ArgumentNullException

### 図形クラス（Line2D, Circle等）
- [ ] コンストラクタ - 正しく初期化
- [ ] プロパティ計算 - 正しい値を返す
- [ ] null安全性 - nullで例外

---

## 最重要ポイント

1. **1テスト = 1検証**
2. **AAA パターン**（Arrange → Act → Assert）
3. **命名**：`メソッド名_状態_期待結果`
4. **Theory** で複数パターンを簡潔に
5. **値オブジェクトは等価性テスト必須**

この5点を守れば、良いテストが書けます！