using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Size",
    Aliases = new[] { "Scale" },
    Description = "A Command to change the size of Players",
    Permission = "moretools.size",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "X Size", "Y Size", "Z Size" }
)]
public class Size : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 4)
        {
            result.Response = "Missing Parameters! size players x y z";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        if (!float.TryParse(context.Arguments[1], out var x))
        {
            result.Response = "Invalid parameter for x";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!float.TryParse(context.Arguments[2], out var y))
        {
            result.Response = "Invalid parameter for y";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!float.TryParse(context.Arguments[3], out var z))
        {
            result.Response = "Invalid parameter for z";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        foreach (var player in players)
            player.Scale = new UnityEngine.Vector3(x, y, z);

        result.Response = "The Size of all Players were changed";
    }
}
