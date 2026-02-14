## dotnet new テンプレート完全ガイド

### 基本コマンド

```bash
# 利用可能なテンプレート一覧
dotnet new list

# ヘルプ表示
dotnet new --help
dotnet new <テンプレート名> --help
```

---

## 1. プロジェクトテンプレート

### アプリケーション
```bash
# コンソールアプリ
dotnet new console -n MyApp

# ASP.NET Core Web API
dotnet new webapi -n MyApi

# ASP.NET Core MVC
dotnet new mvc -n MyWeb

# クラスライブラリ
dotnet new classlib -n MyLibrary

# WPFアプリ（Windows）
dotnet new wpf -n MyWpfApp

# Windows Formsアプリ
dotnet new winforms -n MyFormsApp

# Blazor Server
dotnet new blazorserver -n MyBlazorApp

# Blazor WebAssembly
dotnet new blazorwasm -n MyBlazorApp
```

### テスト
```bash
# xUnit
dotnet new xunit -n MyApp.Tests

# NUnit
dotnet new nunit -n MyApp.Tests

# MSTest
dotnet new mstest -n MyApp.Tests
```

### ソリューション
```bash
# ソリューションファイル
dotnet new sln -n MySolution

# プロジェクトをソリューションに追加
dotnet sln add ./MyApp/MyApp.csproj
```

---

## 2. ファイルテンプレート（.NET 7+）

```bash
# クラス
dotnet new class -n Point2D

# インターフェース
dotnet new interface -n IDrawable

# 列挙型
dotnet new enum -n ShapeType

# レコード（.NET 10）
dotnet new record -n Point2D

# 構造体（.NET 9+）
dotnet new struct -n Vector2D
```

---

## 3. 主要オプション

```bash
# 名前指定
-n, --name <名前>

# 出力ディレクトリ
-o, --output <パス>

# フレームワーク指定
-f, --framework <TFM>
# 例: net8.0, net10.0, netstandard2.1

# 言語指定
-lang, --language <C#|F#|VB>

# 強制上書き
--force
```

---

## 4. 実用例

### プロジェクト構成例
```bash
# ソリューション作成
dotnet new sln -n GeometryVisualizer

# コンソールアプリ
dotnet new console -n GeometryVisualizer -o src/GeometryVisualizer

# クラスライブラリ
dotnet new classlib -n GeometryVisualizer.Core -o src/GeometryVisualizer.Core

# テストプロジェクト
dotnet new xunit -n GeometryVisualizer.Tests -o tests/GeometryVisualizer.Tests

# ソリューションに追加
dotnet sln add src/GeometryVisualizer/GeometryVisualizer.csproj
dotnet sln add src/GeometryVisualizer.Core/GeometryVisualizer.Core.csproj
dotnet sln add tests/GeometryVisualizer.Tests/GeometryVisualizer.Tests.csproj
```

### ファイル追加例
```bash
# 幾何クラス群を作成
dotnet new class -n Point2D -o Geometry
dotnet new class -n Line2D -o Geometry
dotnet new class -n Circle -o Geometry
dotnet new interface -n IShape -o Geometry
```

---

## 5. 便利なTips

### テンプレートの省略形
```bash
dotnet new console    # = dotnet new console
dotnet new classlib   # = dotnet new classlib
dotnet new sln        # = dotnet new sln
```

### gitignore自動生成
```bash
dotnet new gitignore
```

### EditorConfig生成
```bash
dotnet new editorconfig
```

### グローバルJSON（SDKバージョン固定）
```bash
dotnet new globaljson --sdk-version 10.0.100
```

---

## 6. カスタムテンプレート

```bash
# テンプレートのインストール
dotnet new install <パッケージ名>

# インストール済みテンプレート確認
dotnet new list

# テンプレートのアンインストール
dotnet new uninstall <パッケージ名>
```

---

## 補足: ファイル追加は必須ではない

**.csproj に明示的な追加は不要**です：
- エディタで `Point2D.cs` を直接作成してもOK
- dotnet CLI は自動的に全 `.cs` ファイルを認識
- `dotnet new class` は初期コード（namespace等）が欲しい時に便利

このメモを保存しておけば、いつでも参照できます！