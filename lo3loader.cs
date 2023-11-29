using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;

namespace Lo3Loader;
public class Lo3Loader : BasePlugin
{
    public override string ModuleName => "lo3loader for CS2";
    public override string ModuleAuthor => "FlowingSPDG";
    public override string ModuleDescription => "live on restart command(Usage:type lo3 to server console OR say !lo3)";

    public override string ModuleVersion => "0.0.1";

    private bool sayCommandEnable = true; // TODO
    private string configToExecute = "esl5on5.cfg";

    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnMapStart>(mapName => {
            Server.ExecuteCommand("exec lo3loader.cfg");
        });
    }

    private void PrintLive()
    {
        for (int i = 0; i <= 6; i++)
        {
            Server.PrintToChatAll("[lo3loader] -=!Live!=-");
        }
        Server.PrintToChatAll("[lo3loader] Match is now LIVE! \04[G]\01ood \04[L]\01uck \04[H]\01ave \04[F]\01un!");
    }

    private void ShuffleTeams()
    {
        Server.PrintToChatAll("[lo3loader]Scramble teams...");
        Server.ExecuteCommand("mp_scrambleteams");
    }

    private void SwapTeams()
    {
        Server.PrintToChatAll("[lo3loader]Swapping teams...");
        Server.ExecuteCommand("mp_swapteams");
    }

    private async void Restart(int num)
    {
        Server.PrintToChatAll("[lo3loader] Restart" + num.ToString());
        Server.ExecuteCommand("mp_restartgame 1");
    }

    private void ExecLo3()
    {
        Server.PrintToChatAll("[lo3loader] Live ON Restart");
        Server.ExecuteCommand("mp_restartgame 1");
        Task.Run(() => {
            Thread.Sleep(2000);
            PrintLive();
        });
        Server.ExecuteCommand("exec " + configToExecute);
    }

    [GameEventHandler]
    public HookResult OnEventPlayerChat(EventPlayerChat @event, GameEventInfo info)
    {
        if (sayCommandEnable && @event.Text == "!lo3") ExecLo3();
        return HookResult.Continue;
    }

    [ConsoleCommand("lo3", "Live on restart")]
    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
    public void CommandLo3(CCSPlayerController? player, CommandInfo command)
    {
        ExecLo3();
    }

    [ConsoleCommand("ll_enable_saycommand", "If non-zero, enable say hook. everyone can execute lo3 by say !lo3")]
    [CommandHelper(minArgs: 1, usage: "If non-zero, enable say hook. everyone can execute lo3 by say !lo3", whoCanExecute: CommandUsage.SERVER_ONLY)]
    public void CvarEnableSayCommand(CCSPlayerController? caller, CommandInfo command)
    {
        var enable = command.ArgByIndex(1) == "true";
        sayCommandEnable = enable;
    }

    [ConsoleCommand("ll_match_config", "execute configs on live")]
    [CommandHelper(minArgs: 1, usage: "execute configs on live", whoCanExecute: CommandUsage.SERVER_ONLY)]
    public void CvarMatchConfig(CCSPlayerController? caller, CommandInfo command)
    {
        var config = command.ArgByIndex(1);
        configToExecute = config;
    }
}