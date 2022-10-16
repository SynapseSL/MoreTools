using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Config;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "UnJail",
    Aliases = new string[] { },
    Description = "A Command for unjailing Players",
    Permission = "moretools.jail",
    Platforms = new [] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players" }
)]
public class UnJail : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
        {
            result.Response = "Missing Parameter! Usage: Unjail players";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found!";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        foreach (var player in players)
        {
            if (!player.Data.ContainsKey("jail")) continue;
            if (player.Data["jail"] is not SerializedPlayerState state) continue;
            player.State = state;
            player.Data.Remove("jail");
        }

        result.Response = "Players were unjailed";
    }
}
