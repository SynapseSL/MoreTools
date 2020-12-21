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
            if (context.Arguments.Count < 3)
                return new CommandResult
                {
                    Message = "Missing Parameters! Usage: phd players time message",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.At(1), out var time))
                return new CommandResult
                {
                    Message = "Invalid time amount",
                    State = CommandResultState.Error
                };

            var msg = string.Join(" ", context.Arguments.Segment(2));

            foreach (var player in players)
                player.GiveTextHint(msg, time);

            return new CommandResult
            {
                Message = "private hint was send",
                State = CommandResultState.Ok
            };
        }
    }
}
