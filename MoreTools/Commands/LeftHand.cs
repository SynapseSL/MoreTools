using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseCommand(
    CommandName = "LeftHand",
    Aliases = new[] { "lh" },
    Description = "A Command which changes the side of your hand",
    Permission = "moretools.lefthand",
    Platforms = new[] { CommandPlatform.PlayerConsole }
)]
public class LeftHand : SynapseCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        var size = context.Player.Scale;
        size.x *= -1;
        context.Player.Scale = size;

        if (context.Player.Scale.x >= 0)
            result.Response = "You are now using your right hand!";
        else
            result.Response = "You are now using your left hand!";
    }
}
