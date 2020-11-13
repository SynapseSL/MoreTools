using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Suicide",
        Aliases = new string[] { "si" },
        Description = "A Command to kill yourself",
        Permission = "moretools.suicide",
        Platforms = new Platform[] { Platform.ClientConsole },
        Usage = ".suicide ... thats it"
        )]
    public class Suicide : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.suicide"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.suicide)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            context.Player.Kill();
            result.Message = "You have killed yourself";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
