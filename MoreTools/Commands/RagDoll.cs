using Neuron.Core.Meta;
using Neuron.Modules.Commands;
using Neuron.Modules.Commands.Command;
using PlayerRoles;
using Synapse3.SynapseModule.Command;
using Synapse3.SynapseModule.Enums;
using Synapse3.SynapseModule.Map.Objects;

namespace MoreTools.Commands;

[Automatic]
[SynapseRaCommand(
    CommandName = "Ragdoll",
    Aliases = new string[] { },
    Description = "Spawns Ragdolls",
    Permission = "moretools.ragdoll",
    Platforms = new[] { CommandPlatform.RemoteAdmin, CommandPlatform.ServerConsole },
    Parameters = new[] { "Players", "Role", "Amount", "Name" }
)]
public class RagDoll : PlayerCommand
{
    public override void Execute(SynapseContext context, ref CommandResult result)
    {
        if (context.Arguments.Length < 1)
        {
            result.Response = "Missing parameters";
            result.StatusCode = CommandStatusCode.BadSyntax;
            return;
        }

        if (!PlayerService.TryGetPlayers(context.Arguments[0], out var players, context.Player))
        {
            result.Response = "No Player was found";
            result.StatusCode = CommandStatusCode.NotFound;
            return;
        }

        var role = 0;
        var amount = 1;
        var name = "RagDoll";
        if (context.Arguments.Length > 1)
        {
            if (!int.TryParse(context.Arguments[1], out role))
            {
                result.Response = "Invalid RoleID";
                result.StatusCode = CommandStatusCode.BadSyntax;
                return;
            }
        }


        if (context.Arguments.Length > 2)
            if (!int.TryParse(context.Arguments[2], out amount))
            {
                result.Response = "Invalid Amount";
                result.StatusCode = CommandStatusCode.BadSyntax;
                return;
            }

        if (context.Arguments.Length > 3)
            name = context.Arguments[3];


        foreach (var ply in players)
        {
            var pos = ply.Position;
            pos.y += 2;
            
            for (int i = 0; i < amount; i++)
            {
                _ = new SynapseRagDoll((RoleTypeId)role, pos, ply.Rotation, ply.Scale, ply, DamageType.Unknown, name);
            }
        }

        result.Response = "All Ragdolls were spawned";
    }
}
