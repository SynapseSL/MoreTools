using Synapse.Command;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Ragdoll",
        Aliases = new string[] { },
        Description = "Spawns Ragdolls",
        Permission = "moretools.ragdoll",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Ragdoll player Role Amount"
        )]
    public class RagDoll : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Missing parameters",
                    State = CommandResultState.Error
                };

            if (!Extensions.TryGetPlayers(context.Arguments.At(0), context.Player, out var players)) return new CommandResult
            {
                Message = "No Player was found",
                State = CommandResultState.Error
            };

            var role = 0;
            var amount = 1;
            if (context.Arguments.Count > 1)
                if (!int.TryParse(context.Arguments.At(1), out role)) return new CommandResult
                {
                    Message = "Invalid RoleID",
                    State = CommandResultState.Error
                };


            if (context.Arguments.Count > 2)
                if (!int.TryParse(context.Arguments.At(2), out amount)) return new CommandResult
                {
                    Message = "Invalid Amount",
                    State = CommandResultState.Error
                };

            foreach (var ply in players)
                for (int i = 0; i < amount; i++)
                {
                    var pos = ply.Position;
                    pos.y += 2;
                    new Synapse.Api.Ragdoll((RoleType)role, pos, ply.transform.rotation, UnityEngine.Vector3.zero, new PlayerStats.HitInfo(), false, ply);
                }

            return new CommandResult
            {
                Message = "All Ragdolls are spawned",
                State = CommandResultState.Ok
            };
        }
    }
}
