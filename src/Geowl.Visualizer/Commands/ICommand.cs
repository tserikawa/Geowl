namespace Geowl.Visualizer.Commands;

/// <summary>
/// コマンドの基本インターフェース
/// </summary>
public interface ICommand
{
    /// <summary>
    /// コマンドを実行します
    /// </summary>
    void Execute();
}