# Geowl プロジェクト進行状況

最終更新: 2025-XX-XX

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

### ✅ Toolパターン実装（OOP学習）
- [x] `ITool` インターフェース設計
- [x] `PointTool` 実装（点追加ツール）
- [x] `LineTool` 実装（線分追加ツール）
- [x] MainWindowでツール切り替え機能
- [x] Canvas_PointerPressedをツールに委譲

---

## 現在の状態

### 動作する機能
✅ Canvas上クリックで点描画（PointTool）  
✅ 「線分追加」ボタン → 2点クリックで線分描画（LineTool）  
✅ コマンドパターンによる描画処理  
✅ ツールパターンによるモード切り替え

### 未実装・課題
❌ GeometryDocument（描画オブジェクト管理）  
❌ 線分削除機能（`_lines`リスト未更新）  
❌ コンストラクタの初期表示コード整理  
❌ DrawPoint/DrawLineメソッド削除  
❌ テストコード  
❌ Vector2D実装

---

## 次のステップ

### 優先度1: コードの整理
- [ ] コンストラクタの初期表示コード削除
- [ ] `DrawPoint`/`DrawLine`メソッド削除
- [ ] 不要なフィールド・コメント整理

### 優先度2: GeometryDocument統合
- [ ] `GeometryDocument`クラス作成
- [ ] ツールがDocumentに登録するように修正
- [ ] `DrawPointCommand`/`DrawLineCommand`でDocument登録
- [ ] 削除機能をDocument経由に変更

### 優先度3: 機能改善
- [ ] モード表示UI（「線分追加モード中」など）
- [ ] ESCキーでモードキャンセル
- [ ] 1点目と2点目の色分け

### 優先度4: フェーズ1完成
- [ ] `Vector2D`クラス実装
- [ ] テストコード作成（Point2D, Line2D, Vector2D）
- [ ] テストカバレッジ確認

---

## 学習した内容

### オブジェクト指向設計原則
- ✅ **カプセル化**: 状態とロジックを1つのクラスに（ツールクラス）
- ✅ **ポリモーフィズム**: ITool経由で異なるツールを統一的に扱う
- ✅ **単一責任原則**: 各クラスが1つの責任のみ（MainWindow=ツール管理、LineTool=線分追加）
- ✅ **開放閉鎖原則**: 新ツール追加時にMainWindowを変更不要

### デザインパターン
- ✅ **Commandパターン**: 操作をオブジェクト化（DrawPointCommand, DrawLineCommand）
- ✅ **Toolパターン**: モードごとの処理を独立したクラスに

### C#技術
- ✅ readonly struct（Point2D, Line2D）
- ✅ インターフェース設計（ICommand, ITool）
- ✅ file-scoped namespace
- ✅ コンストラクタパラメータとフィールド初期化

### Avalonia UI
- ✅ Canvasでの描画
- ✅ PointerPressedイベント処理
- ✅ ボタンイベントハンドラ

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

## メモ

- GeometryDocumentは、実務的なDocument/Modelパターンを学ぶため後で実装
- Toolパターンは、CAD/CG業界で一般的な設計手法
- 段階的リファクタリングのアプローチを実践中