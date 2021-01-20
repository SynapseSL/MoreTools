using Synapse;

namespace MoreTools.Handlers
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerItemUseEvent += onItemUseEvent;
        }

        public void onItemUseEvent(Synapse.Api.Events.SynapseEventArguments.PlayerItemInteractEventArgs ev)
        {
            if (PluginClass.Config.allowExplosive207)
            {
                if (ev.State == Synapse.Api.Events.SynapseEventArguments.ItemInteractState.Finalizing && ev.CurrentItem.ItemType == ItemType.SCP207)
                {
                    if (Extensions.getSCP207(ev.Player) != PluginClass.Config.scp207ExplosionAmount - 1)
                        Extensions.addSCP207(ev.Player);
                    else
                    {
                        Extensions.SpawnGrenadeOnPlayer(ev.Player);
                        Extensions.resetSCP207(ev.Player);
                    }
                }
            }
        }
    }
}
