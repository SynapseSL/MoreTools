using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Synapse3.SynapseModule.Command;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Nick",
    Aliases = new[] { "NickName" },
    Description = "A Command to change your Nickname",
    Permission = "moretools.nick",
    Platforms = new[] { CommandPlatform.PlayerConsole, CommandPlatform.RemoteAdmin },
    Parameters = new[] { "Nickname" }
)]
public class Nick : SynapseCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        var nick = string.Join(" ", context.Arguments);
        context.Player.DisplayName = nick;
        result.Response = context.Arguments.Length > 0 ? $"Your Nickname is now {nick}" : "Your Nickname has been removed!";
    }
}
