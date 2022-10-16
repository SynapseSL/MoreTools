using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Map;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "WalkSpeed",
    Aliases = new[] { "ws" },
    Description = "A Command to change the WalkSpeed of all Players",
    Permission = "moretools.walkspeed",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Speed" }
)]
public class WalkSpeed : SynapseCommand
{
    private readonly MapService _map;

    public WalkSpeed(MapService map)
    {
        _map = map;
    }

    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
        {
            result.Response = "Missing Parameter. Usage: Walkspeed speed";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!float.TryParse(context.Arguments[0], out var speed))
        {
            result.Response = "Invalid Speed";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        _map.HumanSprintSpeed = speed;

        result.Response = "Walkspeed was changed!";
    }
}
