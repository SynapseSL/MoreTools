using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Nick",
        Aliases = new string[] { "NickName" },
        Description = "A Command to change your Nickname",
        Permission = "moretools.nick",
        Platforms = new Platform[] { Platform.ClientConsole },
        Usage = ".nick nickname"
        )]
    public class Nick : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.nick"))
            {
                result.Message = "You don't have permission to change your nickname!";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            var nick = string.Join(" ", context.Arguments);
            context.Player.DisplayName = nick;
            if (context.Arguments.Count > 0)
                result.Message = $"Your Nickname is now {nick}";
            else
                result.Message = "Your Nickname has been removed!";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
