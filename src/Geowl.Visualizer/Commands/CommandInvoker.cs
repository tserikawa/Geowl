namespace Geowl.Visualizer.Commands;

/// <summary>
/// コマンドの実行を管理するクラス
/// </summary>
public class CommandInvoker
{
    /// <summary>
    /// コマンドを実行します
    /// </summary>
    /// <param name="command">実行するコマンド</param>
    public void Execute(ICommand command)
    {
        command.Execute();
    }
}