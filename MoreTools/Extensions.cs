using Grenades;
using Mirror;
using Synapse;
using Synapse.Api;
using System.Collections.Generic;
using UnityEngine;

namespace MoreTools
{
    public static class Extensions
    {
        public static bool TryGetPlayers(string arg, Player sender, out List<Player> playerList)
        {
            var players = new List<Player>();
            var args = arg.Split('.');

            foreach (var parameter in args)
            {
                if (string.IsNullOrEmpty(parameter)) continue;
                if (string.IsNullOrWhiteSpace(parameter)) continue;

                switch (parameter.ToUpper())
                {
                    case "ME":
                        if (!players.Contains(sender))
                            players.Add(sender);
                        continue;

                    case "ADMIN":
                    case "STAFF":
                        foreach (var player in Server.Get.Players)
                            if (player.ServerRoles.RemoteAdmin)
                                if (!players.Contains(player))
                                    players.Add(player);
                        continue;

                    case "*":
                    case "ALL":
                        foreach (var player2 in Server.Get.Players)
                            if (!players.Contains(player2))
                                players.Add(player2);
                        continue;

                    default:
                        var player3 = Server.Get.GetPlayer(parameter);
                        if (player3 == null) continue;
                        if (!players.Contains(player3))
                            players.Add(player3);
                        continue;
                }
            }

            playerList = players;

            return players.Count != 0;
        }

        public static Dictionary<Player, int> scp207Intus = new Dictionary<Player, int>();
        public static void addSCP207(Player p)
        {
            if (scp207Intus.ContainsKey(p))
                scp207Intus[p]++;
            else
                scp207Intus.Add(p, 1);
        }

        public static void resetSCP207(Player p)
        {
            if (scp207Intus.ContainsKey(p))
                scp207Intus.Remove(p);
        }

        public static int getSCP207(Player p)
        {
            if (scp207Intus.ContainsKey(p))
                return scp207Intus[p];
            else
                return 0;
        }

        public static void SpawnGrenadeOnPlayer(Player player)
        {
            GrenadeManager gm = player.gameObject.GetComponent<GrenadeManager>();
            Grenade gnade = UnityEngine.Object.Instantiate(gm.availableGrenades[0].grenadeInstance.GetComponent<Grenade>());
            gnade.fuseDuration = 1f;
            gnade.FullInitData(gm, player.Position, Quaternion.Euler(gnade.throwStartAngle), gnade.throwLinearVelocityOffset, gnade.throwAngularVelocity, player.RealTeam);
            for (int i = 0; i < PluginClass.Config.scp207NadeAmount; i++)
                NetworkServer.Spawn(gnade.gameObject);
        }
    }
}
