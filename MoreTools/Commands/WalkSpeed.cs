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
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Missing Parameter. Usage: Walkspeed speed",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.First(), out var speed))
                return new CommandResult
                {
                    Message = "Invalid Speed",
                    State = CommandResultState.Error
                };

            Map.Get.WalkSpeed = speed;

            return new CommandResult
            {
                Message = "WalkSpeed was changed!",
                State = CommandResultState.Ok
            };
        }
    }
}
