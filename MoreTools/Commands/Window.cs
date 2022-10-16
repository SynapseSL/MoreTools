using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Window",
    Aliases = new[] { "reportwindow" },
    Description = "Opens the Report Window with a a Custom Message",
    Permission = "moretools.window",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "Message" }
)]
public class Window : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 2)
        {
            result.Response = "Missing Parameter. Usage: Window players Message";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        var message = string.Join(" ", context.Arguments.Segment(1));

        foreach (var player in players)
            player.SendWindowMessage(message);

        result.Response = "Message was send";
    }
}
