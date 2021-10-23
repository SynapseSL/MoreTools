using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "position",
        Aliases = new string[] { "pos" },
        Description = "brings players to a specific position",
        Permission = "moretools.pos",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "pos players x y z",
        Arguments = new[] { "Players", "X Position", "Y Position", "Z Position" }
        )]
    public class Position : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 4)
                return new CommandResult
                {
                    Message = "Missing Parameters! Usage: pos players x y z",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.FirstElement(), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            if (!float.TryParse(context.Arguments.At(1), out var x)) return new CommandResult
            {
                Message = "Invalid Float X",
                State = CommandResultState.Error
            };

            if (!float.TryParse(context.Arguments.At(2), out var y)) return new CommandResult
            {
                Message = "Invalid Float Y",
                State = CommandResultState.Error
            };

            if (!float.TryParse(context.Arguments.At(3), out var z)) return new CommandResult
            {
                Message = "Invalid Float Z",
                State = CommandResultState.Error
            };

            foreach (var ply in players)
                ply.Position = new UnityEngine.Vector3(x, y, z);

            return new CommandResult
            {
                Message = "All players have been tp't to the position",
                State = CommandResultState.Ok
            };
        }
    }
}
