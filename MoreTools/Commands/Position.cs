using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "position",
    Aliases = new[] { "pos" },
    Description = "brings players to a specific position",
    Permission = "moretools.pos",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "X Position", "Y Position", "Z Position" }
)]
public class Position : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 4)
        {
            result.Response = "Missing Parameters! Usage: pos players x y z";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!float.TryParse(context.Arguments[1],out var x))
        {
            result.Response = "Invalid Float X";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!float.TryParse(context.Arguments[2],out var y))
        {
            result.Response = "Invalid Float Y";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }
        if (!float.TryParse(context.Arguments[3],out var z))
        {
            result.Response = "Invalid Float Z";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        foreach (var ply in players)
            ply.Position = new UnityEngine.Vector3(x, y, z);

        result.Response = "All players have been teleported to the position";
    }
}
