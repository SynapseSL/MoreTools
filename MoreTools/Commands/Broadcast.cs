using Synapse.Api;
using Synapse.Command;
using System.Linq;

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
            if (context.Arguments.Count < 2)
                return new CommandResult
                {
                    Message = "Missing Parameter! Usage: bc time message",
                    State = CommandResultState.Error
                };

            if (!ushort.TryParse(context.Arguments.First(), out var time))
                return new CommandResult
                {
                    Message = "Invalid parameter for time",
                    State = CommandResultState.Error
                };

            var msg = string.Join(" ", context.Arguments.Segment(1));
            Map.Get.SendBroadcast(time, msg);
            return new CommandResult
            {
                Message = "Broadcast was send",
                State = CommandResultState.Ok
            };
        }
    }
}
