using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "PrivateBroadcast",
        Aliases = new string[] { "pbc","pbroadcast" },
        Description = "A Command which sends a Broadcast to specific players",
        Permission = "moretools.pbc",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "pbc players time message",
        Arguments = new[] { "Players", "Time", "Message" }
        )]
    public class PrivateBroadcast : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 3)
                return new CommandResult
                {
                    Message = "Missing Parameters! Usage: pbc players time message",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            if (!ushort.TryParse(context.Arguments.At(1), out var time))
                return new CommandResult
                {
                    Message = "Invalid time amount",
                    State = CommandResultState.Error
                };

            var msg = string.Join(" ", context.Arguments.Segment(2));

            foreach (var player in players)
            {
                player.SendBroadcast(time, msg);
                player.GiveTextHint($"Private broadcast was send by {context.Player}");
            }

            return new CommandResult
            {
                Message = "private broadcast was send",
                State = CommandResultState.Ok
            };
        }
    }
}
