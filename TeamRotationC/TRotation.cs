using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace TeamRotationC
{
    public class TRotation : BaseScript
    {
        public TRotation()
        {
            PlayerConnected += new Action<Entity>(entity =>
            {
                entity.OnNotify("joined_team", ent =>
                {
                    entity.CloseInGameMenu();
                    entity.Notify("menuresponse", "changeclass", "axis_recipe1");
                });
            });
        }
        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            if (attacker.IsAlive && !player.IsAlive)
            {
                teamSwitch(attacker);
            }
        }
        public void teamSwitch(Entity player)
        {
            if (player.SessionTeam == "allies")
            {
                AfterDelay(300, () => player.SessionTeam = "axis");
            }
            if (player.SessionTeam == "axis")
            {
                AfterDelay(300, () => player.SessionTeam = "allies");
            }
        }
    }
}
