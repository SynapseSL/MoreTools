using System.Linq;
using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Map;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Broadcast",
    Aliases = new[] { "bc", "alert", "alertmono", "broadcastmono", "bcmono" },
    Description = "A Command to send a Broadcast to all Players",
    Permission = "moretools.bc",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Time", "Message" }
)]
public class Broadcast : SynapseCommand
{
    private readonly CassieService _cassie;

    public Broadcast(CassieService cassie)
    {
        _cassie = cassie;
    }

    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 2)
        {
            result.Response = "Missing Parameter! Usage: bc time message";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!ushort.TryParse(context.Arguments.First(), out var time))
        {
            result.Response = "Invalid parameter for time";
            result.StatusCode = CommandStatusCode.BadSyntax;
        }

        var msg = string.Join(" ", context.Arguments.Segment(1));
        _cassie.Broadcast(time, msg);
        result.Response = "Broadcast was send";
    }
}
