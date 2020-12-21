using Synapse.Api;
using Synapse.Command;
using System.Linq;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "SprintSpeed",
        Aliases = new string[] { "ss" },
        Description = "A Command to change the SprintSpeed of all Players",
        Permission = "moretools.sprintspeed",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Walkspeed (speed)"
        )]
    public class SprintSpeed : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Missing Parameter. Usage: Sprintspeed speed",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.First(), out var speed))
                return new CommandResult
                {
                    Message = "Invalid Speed",
                    State = CommandResultState.Error
                };

            Map.Get.SprintSpeed = speed;

            return new CommandResult
            {
                Message = "SprintSpeed was changed!",
                State = CommandResultState.Ok
            };
        }
    }
}
