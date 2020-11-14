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
            var result = new CommandResult();
            if (!context.Player.HasPermission("moretools.bc"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.bc)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if(context.Arguments.Count < 2)
            {
                result.Message = "Missing Parameter! Usage: bc time message";
                result.State = CommandResultState.Error;
                return result;
            }

            if(!ushort.TryParse(context.Arguments.First(),out var time))
            {
                result.Message = "Invalid parameter for time";
                result.State = CommandResultState.Error;
                return result;
            }

            var msg = string.Join(" ", context.Arguments.Segment(1));
            Map.Get.SendBroadcast(time, msg);
            result.Message = "Broadcast was send";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
