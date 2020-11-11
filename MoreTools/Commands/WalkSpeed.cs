using Synapse.Api;
using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "WalkSpeed",
        Aliases = new string[] { "ws" },
        Description = "A Command to change the WalkSpeed of all Players",
        Permission = "moretools.walkspeed",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Walkspeed (speed)"
        )]
    public class WalkSpeed : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.walkspeed"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.walkspeed)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if(context.Arguments.Count < 1)
            {
                result.Message = "Missing Parameter. Usage: Walkspeed speed";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!float.TryParse(context.Arguments.First(), out var speed))
            {
                result.Message = "Invalid Speed";
                result.State = CommandResultState.Error;
                return result;
            }

            Map.Get.WalkSpeed = speed;

            result.Message = "WalkSpeed was changed!";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
