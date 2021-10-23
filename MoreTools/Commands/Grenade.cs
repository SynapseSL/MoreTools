using Synapse.Command;
using UnityEngine;
using Synapse.Api;

namespace MoreTools.Commands
{
    [CommandInformation(
        Name = "Grenade",
        Aliases = new string[] { "gn" },
        Description = "Spawns grenades at the player location",
        Permission = "moretools.grenade",
        Platforms = new Platform[] { Platform.RemoteAdmin, Platform.ServerConsole },
        Usage = "Grenade players (optional amount)",
        Arguments = new[] { "Players", "(Amount)" }
        )]
    public class Grenade : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            if (context.Arguments.Count < 1)
                return new CommandResult
                {
                    Message = "Usage: Grenade players (optional amount)",
                    State = CommandResultState.Error
                };

            if (context.Arguments.Count < 2)
                context.Arguments = new System.ArraySegment<string>(new[] { context.Arguments.At(0), "1" });

            if (!Extensions.TryGetPlayers(context.Arguments.At(0), context.Player, out var players))
                return new CommandResult
                {
                    Message = "No Player was found",
                    State = CommandResultState.Error
                };

            if (!int.TryParse(context.Arguments.At(1), out var amount))
                return new CommandResult
                {
                    Message = "Invalid Amount of grenades",
                    State = CommandResultState.Error
                };

            foreach (var player in players)
                for (int i = 0; i < amount; i++)
                    Map.Get.SpawnGrenade(player.Position, Vector3.zero,3,Synapse.Api.Enum.GrenadeType.Grenade,context.Player);

            return new CommandResult
            {
                Message = "Grenades are spawned",
                State = CommandResultState.Ok
            };
        }
    }
}
