using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Suicide",
    Aliases = new[] { "si" },
    Description = "A Command to kill yourself",
    Permission = "moretools.suicide",
    Platforms = new[] { CommandPlatform.PlayerConsole }
)]
public class Suicide : SynapseCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        context.Player.Kill();
        result.Response = "You have killed yourself";
    }
};
