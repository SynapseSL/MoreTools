using Synapse.Api;
using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "SprintSpeed",
        Aliases = new string[] { "ss" },
        Description = "A Command to change the SprintSpeed of all Players",
        Permission = "moretools.sprint",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Walkspeed (speed)"
        )]
    public class SprintSpeed : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.sprintspeed"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.sprintspeed)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (context.Arguments.Count < 1)
            {
                result.Message = "Missing Parameter. Usage: Sprintspeed speed";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!float.TryParse(context.Arguments.First(), out var speed))
            {
                result.Message = "Invalid Speed";
                result.State = CommandResultState.Error;
                return result;
            }

            Map.Get.SprintSpeed = speed;

            result.Message = "SprintSpeed was changed!";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
