using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Broadcast",
        Aliases = new string[] { "bc","alert","alertmono","broadcastmono","bcmono" },
        Description = "A Command to send a Broadcast to all Players",
        Permission = "moretools.bc",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Bc time message"
        )]
    public class Broadcast : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            return result;
        }
    }
}
