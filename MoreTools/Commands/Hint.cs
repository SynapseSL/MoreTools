using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Hint",
    Aliases = new[] { "HintDisplay", "hd" },
    Description = "A Command to give all Players a Hint Message",
    Permission = "moretools.hint",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Time", "Message" }
)]
public class Hint : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 2)
        {
            result.Response = "Missing Parameter! Usage: hint time message";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!float.TryParse(context.Arguments[0], out var time))
        {
            result.Response = "Invalid parameter for time";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        var msg = string.Join(" ", context.Arguments.Segment(1));
        foreach (var ply in PlayerService.Players)
            ply.SendHint(msg, time);

        result.Response = "Hint was send";
    }
}
