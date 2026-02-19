# Geowl プロジェクト進行状況

最終更新: 2025-02-19

---

## プロジェクト概要

**目的**: C#のオブジェクト指向設計を学ぶための幾何計算ライブラリ  
**参考書籍**: CGのための幾何学・アルゴリズム（近代科学社）  
**技術スタック**: .NET 10, Avalonia UI 11.x, xUnit

---

## 完了したフェーズ

### ✅ フェーズ0: 環境構築（Week 0）
- [x] .NET 10 SDKインストール
- [x] VS Code拡張機能インストール
- [x] プロジェクト構造作成（Geowl.Core, Geowl.Visualizer, Geowl.Core.Tests）
- [x] Avaloniaアプリ起動確認
- [x] .editorconfig設定（Microsoftコーディングスタイル）

### ✅ フェーズ1（一部）: 基礎クラス設計
- [x] `Point2D.cs` 作成
- [x] `Line2D.cs` 作成
- [x] Visualizer: Canvas上でのクリック検出
- [ ] `Vector2D.cs` 作成（未実施）
- [ ] テストコード作成（未実施）

### ✅ コマンドパターン実装
- [x] `ICommand` インターフェース作成
- [x] `DrawPointCommand` 実装
- [x] `DrawLineCommand` 実装
- [x] `CommandInvoker` 実装
- [x] MainWindowでコマンド使用
- [x] コマンドがGeowlDocumentに登録

### ✅ Toolパターン実装（OOP学習）
- [x] `ITool` インターフェース設計
- [x] `PointTool` 実装（点追加ツール）
- [x] `LineTool` 実装（線分追加ツール）
- [x] MainWindowでツール切り替え機能
- [x] Canvas_PointerPressedをツールに委譲

### ✅ GeometryDocument統合
- [x] `GeowlDocument`クラス作成
- [x] ツールにDocumentを渡す
- [x] コマンドがDocumentに登録
- [x] 削除ボタンをDocument経由に変更
- [x] 全消去ボタン動作確認
- [x] 線分消去ボタン動作確認

### ✅ コードの整理
- [x] コンストラクタの初期表示コード削除
- [x] DrawPoint/DrawLineメソッド削除
- [x] 不要な`_lines`フィールド削除

---

## 現在の状態

### 動作する機能
✅ Canvas上クリックで点描画（PointTool）  
✅ 「線分追加」ボタン → 2点クリックで線分描画（LineTool）  
✅ コマンドパターンによる描画処理  
✅ ツールパターンによるモード切り替え  
✅ GeowlDocumentによるオブジェクト管理  
✅ 全消去ボタン（点・線分すべて削除）  
✅ 線分消去ボタン（線分のみ削除）

### 現在のアーキテクチャ
```
MainWindow
  ├─ GeowlDocument（データ管理）
  ├─ CommandInvoker（コマンド実行）
  └─ Tools（ユーザー操作）
      ├─ PointTool
      └─ LineTool
          └─ Commands（描画処理）
              ├─ DrawPointCommand
              └─ DrawLineCommand
                  └─ GeowlDocument に登録
```

### 未実装・課題
❌ Vector2D実装  
❌ テストコード  
❌ モード表示UI  
❌ ESCキーでキャンセル  
❌ 1点目と2点目の色分け

---

## 次のステップ

### 優先度1: 機能改善（UI/UX）
- [ ] モード表示UI（「線分追加モード中」など）
- [ ] ESCキーでモードキャンセル
- [ ] 1点目と2点目の色分け
- [ ] ツール切り替えボタンの追加（点追加モードに戻る）

### 優先度2: フェーズ1完成
- [ ] `Vector2D`クラス実装
- [ ] テストコード作成（Point2D, Line2D, Vector2D）
- [ ] テストカバレッジ確認

### 優先度3: 新しいツール追加
- [ ] `SelectTool`（選択ツール）
- [ ] `PolygonTool`（多角形ツール）

---

## 学習した内容

### オブジェクト指向設計原則
- ✅ **カプセル化**: 状態とロジックを1つのクラスに（ツールクラス、Documentクラス）
- ✅ **ポリモーフィズム**: ITool/ICommand経由で異なる実装を統一的に扱う
- ✅ **単一責任原則**: 各クラスが1つの責任のみ
    - MainWindow = ツール管理
    - LineTool = 線分追加
    - GeowlDocument = データ管理
    - DrawPointCommand = 点描画
- ✅ **開放閉鎖原則**: 新ツール/コマンド追加時に既存コード変更不要
- ✅ **依存性逆転原則**: 具体ではなく抽象（インターフェース）に依存

### デザインパターン
- ✅ **Commandパターン**: 操作をオブジェクト化（DrawPointCommand, DrawLineCommand）
- ✅ **Toolパターン**: モードごとの処理を独立したクラスに（PointTool, LineTool）
- ✅ **Document/Modelパターン**: データ管理の責任分離（GeowlDocument）

### 実務的な設計手法
- ✅ **段階的リファクタリング**: bool → Enum → Toolパターンと段階的に改善
- ✅ **責任の分離**: UI層（MainWindow）とデータ層（GeowlDocument）の分離
- ✅ **参照型の活用**: 同じオブジェクトをCanvas/Documentで共有

### C#技術
- ✅ readonly struct（Point2D, Line2D）
- ✅ インターフェース設計（ICommand, ITool）
- ✅ file-scoped namespace
- ✅ コンストラクタパラメータとフィールド初期化
- ✅ IReadOnlyList による読み取り専用公開

### Avalonia UI
- ✅ Canvasでの描画
- ✅ PointerPressedイベント処理
- ✅ ボタンイベントハンドラ
- ✅ UI要素の動的追加・削除

---

## プロジェクト構成
```
Geowl/
├── src/
│   ├── Geowl.Core/
│   │   └── Primitive/
│   │       ├── Point2D.cs
│   │       └── Line2D.cs
│   ├── Geowl.Visualizer/
│   │   ├── Commands/
│   │   │   ├── ICommand.cs
│   │   │   ├── DrawPointCommand.cs
│   │   │   ├── DrawLineCommand.cs
│   │   │   └── CommandInvoker.cs
│   │   ├── Tools/
│   │   │   ├── ITool.cs
│   │   │   ├── PointTool.cs
│   │   │   └── LineTool.cs
│   │   ├── Models/
│   │   │   └── GeowlDocument.cs
│   │   ├── MainWindow.axaml
│   │   └── MainWindow.axaml.cs
├── tests/
│   └── Geowl.Core.Tests/
├── docs/
│   ├── learning-log.md
│   ├── test.md
│   ├── dotnet.md
│   └── coding-style.md
├── LOADMAP.md
├── PROGRESS.md
└── README.md
```

---

## 重要なマイルストーン

### 🎉 達成したマイルストーン

1. **環境構築完了**（2025-XX-XX）
    - .NET 10 + Avalonia UIの開発環境構築

2. **基本図形実装**（2025-XX-XX）
    - Point2D, Line2D クラス完成

3. **Commandパターン導入**（2025-XX-XX）
    - 操作のカプセル化、将来のUndo/Redo基盤

4. **Toolパターン導入**（2025-02-19）
    - OOP設計原則の実践
    - CAD/CG業界標準のアーキテクチャ実装

5. **Document統合完了**（2025-02-19）
    - データ管理の責任分離
    - 実務レベルのアーキテクチャ完成

---

## メモ

### 設計思想
- **段階的成長**: シンプルから始めて、必要に応じて洗練
- **実務指向**: 実際のCAD/CGソフトウェアと同じパターン
- **学習優先**: 過度な設計より、理解を深めることを重視

### 今後の方針
- Toolパターンは10個程度まで拡張可能
- Undo/Redo機能はCommandパターンを活用して実装予定
- テスト駆動開発（TDD）の導入検討

### 参考にした実例
- **Rhinoceros**: RhinoDoc でジオメトリ管理
- **AutoCAD**: Tool/Command パターン
- **Photoshop**: ツールパレット設計
