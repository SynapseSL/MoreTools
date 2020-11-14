using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "PrivateHint",
        Aliases = new string[] { "phd","privatehintdisplay" },
        Description = "A Command which sends a hint to specific players",
        Permission = "moretools.phd",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "phd players time message"
        )]
    public class PrivateHint : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.phd"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.phd)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if (context.Arguments.Count < 3)
            {
                result.Message = "Missing Parameters! Usage: phd players time message";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
            {
                result.Message = "No Player was found";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!float.TryParse(context.Arguments.At(1), out var time))
            {
                result.Message = "Invalid time amount";
                result.State = CommandResultState.Error;
                return result;
            }

            var msg = string.Join(" ", context.Arguments.Segment(2));

            foreach (var player in players)
                player.GiveTextHint(msg, time);

            result.Message = "private hint was send";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
