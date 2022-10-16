using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Enums;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "hide",
    Aliases = new string[] { },
    Description = "A Command to make Players Invisible",
    Permission = "moretools.invisible",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players" }
)]
public class Hide : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
        {
            result.Response = "Missing Parameter! Usage: hide players";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        foreach (var player in players)
            player.Invisible = InvisibleMode.Admin;

        result.Response = "The Players are now Invisible";
    }
}
