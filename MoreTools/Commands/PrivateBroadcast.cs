using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "PrivateBroadcast",
        Aliases = new string[] { "pbc","pbroadcast" },
        Description = "A Command which sends a Broadcast to specific players",
        Permission = "moretools.pbc",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "pbc players time message"
        )]
    public class PrivateBroadcast : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!context.Player.HasPermission("moretools.pbc"))
            {
                result.Message = "You dont have Permission to execute this Command (moretools.pbc)";
                result.State = CommandResultState.NoPermission;
                return result;
            }

            if(context.Arguments.Count < 3)
            {
                result.Message = "Missing Parameters! Usage: pbc players time message";
                result.State = CommandResultState.Error;
                return result;
            }

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
            {
                result.Message = "No Player was found";
                result.State = CommandResultState.Error;
                return result;
            }

            if(!ushort.TryParse(context.Arguments.At(1),out var time))
            {
                result.Message = "Invalid time amount";
                result.State = CommandResultState.Error;
                return result;
            }

            var msg = string.Join(" ", context.Arguments.Segment(2));

            foreach (var player in players)
                player.SendBroadcast(time, msg);

            result.Message = "private broadcast was send";
            result.State = CommandResultState.Ok;
            return result;
        }
    }
}
