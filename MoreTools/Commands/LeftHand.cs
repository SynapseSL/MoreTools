using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "LeftHand",
        Aliases = new string[] { "lh" },
        Description = "A Command which changes the side of your hand",
        Permission = "moretools.lefthand",
        Platforms = new Platform[] { Platform.ClientConsole },
        Usage = ".lefthand"
        )]
    public class LeftHand : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.lefthand"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.size)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            var size = context.Player.Scale;
            size.x = size.x * -1;
            context.Player.Scale = size;

            if (context.Player.Scale.x >= 0)
                result.Message = "You are now using your right hand!";
            else
                result.Message = "You are now using your left hand!";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
