using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Redirect",
    Aliases = new[] { "rd" },
    Description = "Forces the player to join on a other Server on the same machine with a different port",
    Permission = "moretools.redirect",
    Platforms = new [] { CommandPlatform.RemoteAdmin,CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "Port" }
)]
public class Redirect : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 2)
        {
            result.Response = "Missing Parameter. Usage: Redirect players port";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        if (!ushort.TryParse(context.Arguments[1], out var port))
        {
            result.Response = "Invalid Port";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        foreach (var player in players)
            player.SendToServer(port);

        result.Response = "Players were redirected to " + port;
    }
}
