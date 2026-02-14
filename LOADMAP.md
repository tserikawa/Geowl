学習ロードマップに学習環境情報を追記しました。

---

# 幾何アルゴリズム実装 学習ロードマップ

## 学習環境

### 開発環境
- **OS**: macOS
- **エディタ**: Visual Studio Code
- **フレームワーク**: .NET 10
- **UIフレームワーク**: Avalonia UI 11.x
- **プロジェクト名**: Geowl

### 推奨VS Code拡張機能
- **C# Dev Kit** (Microsoft) - 必須
- **Avalonia for VSCode** - 推奨
- **GitLens** - Git履歴管理
- **Todo Tree** - TODOコメント管理
- **.NET Core Test Explorer** - テスト実行

### プロジェクト構成
```
Geowl/
├── Geowl.sln                      # ソリューションファイル
├── src/
│   ├── Geowl.Core/                # 幾何ライブラリ本体
│   │   ├── Primitives/            # 基本図形クラス
│   │   ├── Algorithms/            # アルゴリズム実装
│   │   └── DataStructures/        # データ構造
│   ├── Geowl.Visualizer/          # Avalonia UIアプリ
│   │   ├── Views/                 # 画面
│   │   ├── ViewModels/            # ビューモデル
│   │   └── Demos/                 # デモ画面
├── tests/
│   └── Geowl.Core.Tests/          # 単体テスト
├── docs/
│   ├── learning-log.md            # 学習記録
│   └── notes/                     # 各アルゴリズムのノート
└── README.md
```

---

## 全体目標
**CGのための幾何学・アルゴリズム（近代科学社）の主要アルゴリズムをC#で実装し、オブジェクト指向設計とアルゴリズム力を強化する**

---

## フェーズ0: 準備（Week 0）
### 目標
開発環境の構築とプロジェクトの基盤作り

### 環境構築手順

#### 1. .NET 10 SDKのインストール
```bash
# Homebrewでインストール
brew install --cask dotnet-sdk

# バージョン確認
dotnet --version
# 出力: 10.0.xxx
```

#### 2. VS Code拡張機能のインストール
VS Codeを開いて以下をインストール：
1. `C# Dev Kit` を検索してインストール
2. `Avalonia for VSCode` を検索してインストール

#### 3. Avaloniaテンプレートのインストール
```bash
dotnet new install Avalonia.Templates
```

#### 4. プロジェクト作成
```bash
# プロジェクトフォルダ作成
mkdir Geowl
cd Geowl

# ソリューション作成
dotnet new sln -n Geowl

# コアライブラリプロジェクト作成
mkdir -p src/Geowl.Core
dotnet new classlib -n Geowl.Core -o src/Geowl.Core -f net10.0

# Avaloniaビジュアライザープロジェクト作成
mkdir -p src/Geowl.Visualizer
dotnet new avalonia.app -n Geowl.Visualizer -o src/Geowl.Visualizer

# テストプロジェクト作成
mkdir -p tests/Geowl.Core.Tests
dotnet new xunit -n Geowl.Core.Tests -o tests/Geowl.Core.Tests -f net10.0

# ソリューションにプロジェクトを追加
dotnet sln add src/Geowl.Core/Geowl.Core.csproj
dotnet sln add src/Geowl.Visualizer/Geowl.Visualizer.csproj
dotnet sln add tests/Geowl.Core.Tests/Geowl.Core.Tests.csproj

# プロジェクト間の参照を設定
dotnet add src/Geowl.Visualizer/Geowl.Visualizer.csproj reference src/Geowl.Core/Geowl.Core.csproj
dotnet add tests/Geowl.Core.Tests/Geowl.Core.Tests.csproj reference src/Geowl.Core/Geowl.Core.csproj
```

#### 5. ビルドと実行確認
```bash
# ソリューション全体をビルド
dotnet build

# ビジュアライザーを起動
dotnet run --project src/Geowl.Visualizer/Geowl.Visualizer.csproj

# テストを実行
dotnet test
```

#### 6. VS Codeでプロジェクトを開く
```bash
code .
```

#### 7. Git初期化（オプション）
```bash
git init
cat > .gitignore << EOF
bin/
obj/
.vs/
.vscode/
*.user
*.suo
.DS_Store
EOF

git add .
git commit -m "Initial commit: Geowl project setup"
```

### タスク
- [x] .NET 10 SDKインストール確認
- [x] VS Code拡張機能インストール
- [x] プロジェクト構造作成
- [x] Geowl.Visualizerが起動することを確認
- [x] テストが実行できることを確認
- [x] `docs/learning-log.md` 作成
- [x] `README.md` 作成

### 成果物
- 動作するAvaloniaアプリ（Geowl.Visualizer）
- テストが実行可能な環境
- 学習記録用のドキュメント

### 学べること
- .NET 10の新機能
- ソリューション構成
- Avalonia UIの基礎

### 開発コマンド一覧
```bash
# ビルド
dotnet build

# 実行（ビジュアライザー）
dotnet run --project src/Geowl.Visualizer/Geowl.Visualizer.csproj

# テスト実行
dotnet test

# 特定のテストクラスのみ実行
dotnet test --filter ClassName=Point2DTests

# ウォッチモード（コード変更時に自動ビルド）
dotnet watch --project src/Geowl.Visualizer/Geowl.Visualizer.csproj

# クリーンビルド
dotnet clean && dotnet build
```

---

## フェーズ1: 基礎クラス設計（Week 1-2）
### 目標
再利用可能な基礎クラスライブラリの構築

### タスク
**Week 1:**
- [ ] `src/Geowl.Core/Primitives/Point2D.cs` 作成
- [ ] `src/Geowl.Core/Primitives/Vector2D.cs` 作成
- [ ] `tests/Geowl.Core.Tests/Primitives/Point2DTests.cs` 作成
- [ ] `tests/Geowl.Core.Tests/Primitives/Vector2DTests.cs` 作成
- [ ] Visualizer: 点をクリックで配置する機能

**Week 2:**
- [ ] `src/Geowl.Core/Primitives/Line.cs` 作成
- [ ] `src/Geowl.Core/Primitives/LineSegment.cs` 作成
- [ ] 内積・外積の実装
- [ ] Visualizer: 線分を描画する機能
- [ ] テストカバレッジ確認

### ファイル構成例
```
src/Geowl.Core/
├── Primitives/
│   ├── Point2D.cs
│   ├── Vector2D.cs
│   ├── Line.cs
│   └── LineSegment.cs
tests/Geowl.Core.Tests/
├── Primitives/
│   ├── Point2DTests.cs
│   ├── Vector2DTests.cs
│   ├── LineTests.cs
│   └── LineSegmentTests.cs
src/Geowl.Visualizer/
├── Views/
│   └── PointPlacementView.axaml
├── ViewModels/
│   └── PointPlacementViewModel.cs
```

### 学べること
- .NET 10の新機能（record struct等）
- クラス設計の基礎
- xUnitによる単体テスト
- Avalonia UIでのMVVMパターン

### 開発Tips（macOS）
```bash
# VS Codeでテストをデバッグ実行
# 1. テストメソッドにブレークポイント設定
# 2. 左サイドバーの「実行とデバッグ」から実行

# コード整形
dotnet format

# NuGetパッケージ追加例
dotnet add src/Geowl.Core package System.Numerics.Vectors
```

### チェックポイント
✅ Point2D同士の距離が正しく計算できる  
✅ Vector2Dの外積で符号判定ができる  
✅ すべてのテストがパスする（`dotnet test`）  
✅ Visualizerで点・線分が表示できる

**📌 ここまでで中断OK → 業務で使える基礎ライブラリが完成**

---

## フェーズ2: 線分アルゴリズム（Week 3-4）
### 目標
線分を使った基本的な幾何計算の実装

### タスク
**Week 3:**
- [ ] `src/Geowl.Core/Algorithms/GeometricPredicates.cs` 作成
  - 点と直線の位置関係
  - 点と直線の距離
  - 点の射影
- [ ] テスト作成
- [ ] Visualizer: マウス位置と線分の関係を表示

**Week 4:**
- [ ] `src/Geowl.Core/Algorithms/LineIntersection.cs` 作成
- [ ] 交差判定・交点計算
- [ ] エッジケース処理
- [ ] Visualizer: 交差線分の色分け表示

### ファイル構成
```
src/Geowl.Core/
├── Algorithms/
│   ├── GeometricPredicates.cs
│   └── LineIntersection.cs
tests/Geowl.Core.Tests/
├── Algorithms/
│   ├── GeometricPredicatesTests.cs
│   └── LineIntersectionTests.cs
src/Geowl.Visualizer/
├── Views/
│   └── LineIntersectionDemoView.axaml
```

### 学べること
- 外積を使った幾何判定
- エッジケースの処理
- UIとロジックの分離（MVVM）

### チェックポイント
✅ 任意の2線分の交差を正しく判定  
✅ 平行線を正しく処理  
✅ Visualizerで動作確認できる

**📌 ここまでで中断OK → Grasshopperの Line|Line 相当の機能が完成**

---

## フェーズ3: 多角形の基礎（Week 5-6）
### 目標
多角形データ構造と基本操作の実装

### タスク
**Week 5:**
- [ ] `src/Geowl.Core/Primitives/Polygon.cs` 作成
- [ ] `src/Geowl.Core/Algorithms/PolygonOperations.cs` 作成
  - 面積計算
  - 点の内外判定
- [ ] Visualizer: クリックで多角形作成

**Week 6:**
- [ ] 凸多角形判定
- [ ] 重心計算
- [ ] リファクタリング週間
- [ ] コードレビュー・整理

### ファイル構成
```
src/Geowl.Core/
├── Primitives/
│   └── Polygon.cs
├── Algorithms/
│   └── PolygonOperations.cs
```

### 学べること
- コレクション操作
- リファクタリング技術
- コード品質の向上

### チェックポイント
✅ 凹多角形で内外判定が正しく動作  
✅ コードが読みやすく整理されている  
✅ テストカバレッジ80%以上

**📌 ここまでで中断OK → Point in Curve 相当が完成**

---

## フェーズ4: 凸包（Week 7-9）★重要マイルストーン
### 目標
初めての本格的なアルゴリズム実装と可視化

### タスク
**Week 7:**
- [ ] `src/Geowl.Core/Algorithms/ConvexHull/GrahamScan.cs`
- [ ] 基本実装

**Week 8:**
- [ ] `src/Geowl.Visualizer/Animations/ConvexHullAnimator.cs`
- [ ] ステップ実行機能

**Week 9:**
- [ ] `src/Geowl.Core/Algorithms/ConvexHull/JarvisMarch.cs`
- [ ] 性能比較ツール

### ファイル構成
```
src/Geowl.Core/
├── Algorithms/
│   └── ConvexHull/
│       ├── IConvexHullAlgorithm.cs
│       ├── GrahamScan.cs
│       └── JarvisMarch.cs
src/Geowl.Visualizer/
├── Animations/
│   └── ConvexHullAnimator.cs
```

### 学べること
- 複雑なアルゴリズム実装
- アニメーション処理
- インターフェース設計

### チェックポイント
✅ ランダム点群で正しく凸包を計算  
✅ アルゴリズムの動作過程を可視化  
✅ 2つの手法を実装し比較

**📌 ここが最初の大きな達成ポイント！**

---

## フェーズ5以降
（以降は前述のロードマップと同じ内容）

---

## 学習の進め方（macOS環境）

### 日常的な開発フロー
```bash
# 1. VS Codeでプロジェクトを開く
cd ~/Projects/Geowl
code .

# 2. ターミナルを開く（VS Code内蔵ターミナル推奨）

# 3. ウォッチモードで開発
# ターミナル1: Visualizer自動再起動
dotnet watch --project src/Geowl.Visualizer/Geowl.Visualizer.csproj

# ターミナル2: テスト自動実行
dotnet watch test --project tests/Geowl.Core.Tests/Geowl.Core.Tests.csproj

# 4. コード編集
# Point2D.cs等を編集すると自動でビルド・再起動

# 5. コミット
git add .
git commit -m "Implement Point2D class"
```

### 週次ルーチン
```
平日（1日30分-1時間）:
  - `dotnet watch` で開発
  - コードレビュー（前日分）
  - `docs/learning-log.md` に記録

週末（2-3時間）:
  - まとまった実装
  - リファクタリング（`dotnet format`）
  - テスト作成
  - 動作確認
```

### トラブルシューティング（macOS特有）

#### Avaloniaアプリが起動しない
```bash
# Rosetta 2がインストールされているか確認（M1/M2 Mac）
softwareupdate --install-rosetta

# キャッシュクリア
dotnet clean
rm -rf bin obj
dotnet build
```

#### VS Code でC#のIntelliSenseが動かない
```bash
# C# Dev Kit を再インストール
# 1. VS Codeの拡張機能で C# Dev Kit をアンインストール
# 2. VS Code再起動
# 3. C# Dev Kit を再インストール
# 4. コマンドパレット (Cmd+Shift+P) → "Reload Window"
```

#### テストが実行されない
```bash
# テストプロジェクトの再ビルド
dotnet build tests/Geowl.Core.Tests/Geowl.Core.Tests.csproj
dotnet test tests/Geowl.Core.Tests/Geowl.Core.Tests.csproj -v detailed
```

---

## 推奨ショートカット（macOS + VS Code）

| 機能 | ショートカット |
|------|--------------|
| ビルド | `Cmd + Shift + B` |
| コマンドパレット | `Cmd + Shift + P` |
| ファイル検索 | `Cmd + P` |
| 定義へジャンプ | `F12` |
| すべての参照検索 | `Shift + F12` |
| 名前変更 | `F2` |
| コード整形 | `Option + Shift + F` |
| ターミナル開く | `Ctrl + ` ` |

---

## リソース

### macOS開発に役立つツール
- **iTerm2**: 高機能ターミナル（オプション）
- **Fork/Sourcetree**: Git GUIクライアント（オプション）
- **Docker Desktop**: 将来的なCI/CD用（オプション）

### 参照ドキュメント
- [Avalonia UI Documentation](https://docs.avaloniaui.net/)
- [.NET 10 Documentation](https://learn.microsoft.com/dotnet/)
- [xUnit Documentation](https://xunit.net/)

---

このロードマップでフェーズ0から始めますか？環境構築で不明点があれば教えてください。