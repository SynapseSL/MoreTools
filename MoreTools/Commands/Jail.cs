using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Jail",
    Aliases = new string[] { },
    Description = "A Command for jailing Players",
    Permission = "moretools.jail",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players" }
)]
public class Jail : PlayerCommand
{
    private readonly MoreTools _moreTools;
    
    public Jail(MoreTools moreTools)
    {
        _moreTools = moreTools;
    }
    
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
        {
            result.Response = "Missing Parameter! Usage: Jail players";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found!";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        var amount = 1;

        if (context.Arguments.Length > 1 && int.TryParse(context.Arguments[1], out var newAmount))
        {
            if (newAmount <= 0)
                newAmount = 1;

            if (newAmount > _moreTools.Config.JailStates.Count)
            {
                amount = _moreTools.Config.JailStates.Count;
            }
            else
            {
                amount = newAmount;
            }
        }

        foreach (var player in players)
        {
            if (!player.Data.ContainsKey("jail"))
                player.Data["jail"] = player.State;
            player.State = _moreTools.Config.JailStates[amount - 1];
        }

        result.Response = "Players are jailed";
    }
}
