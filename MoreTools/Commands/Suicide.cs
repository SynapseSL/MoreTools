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
            context.Player.Kill();
            return new CommandResult
            {
                Message = "You have killed yourself",
                State = CommandResultState.Ok
            };
        }
    }
}
