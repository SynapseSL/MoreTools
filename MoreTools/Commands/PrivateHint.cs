using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "PrivateHint",
    Aliases = new[] { "phd", "privatehintdisplay" },
    Description = "A Command which sends a hint to specific players",
    Permission = "moretools.phd",
    Platforms = new [] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "Time", "Message" }
)]
public class PrivateHint : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 3)
        {
            result.Response = "Missing Parameters! Usage: phd players time message";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        if (!float.TryParse(context.Arguments[1], out var time))
        {
            result.Response = "Invalid time amount";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        var msg = string.Join(" ", context.Arguments.Segment(2));

        foreach (var player in players)
            player.SendHint(msg, time);

        result.Response = "Private Hint was send";
    }
};
