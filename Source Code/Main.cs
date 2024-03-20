using CommandSystem.Commands.RemoteAdmin.ServerEvent;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Interfaces;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerRoles;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features.Roles;
using Exiled.Permissions.Extensions;
using MEC;
using RemoteAdmin;
using Exiled.CustomRoles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Interactables.Interobjects.DoorUtils;
using PlayerRoles;
using PluginAPI.Events;
using Respawning;
using UnityEngine;
using Item = PluginAPI.Core.Items.Item;
using Random = System.Random;

namespace Scp507
{
    public class Plugin:Plugin<Config>
    {
        public override string Author { get; } = "Friza";

        public override string Name { get; } = "SCP-507";

        public override string Prefix { get; } = "SCP-507";

        public override Version Version { get; } = new Version(1, 0, 0);

        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 0);
        
        public Random random = new Random();
        public Plugin plugin;
        public string SCP507ID = "";
        public override void OnEnabled()
        {
            plugin = this;
            Exiled.Events.Handlers.Server.RoundStarted += this.RoundStarted;
            Exiled.Events.Handlers.Player.Escaping += this.OnEscaping;
            Exiled.Events.Handlers.Player.TogglingNoClip += this.NoClip;
            Log.Info("");
            base.OnEnabled();
        }
        public void RoundStarted()
        {
              int rand = random.Next(1, 100);

              if (rand < Config.spawnChance)
              {
                  Timing.CallDelayed(2f, () =>
                  {
                      SCP507ID = Player.Get(PlayerRoles.RoleTypeId.ClassD).ToList().RandomItem().UserId;
                  });
                  Timing.CallDelayed(2f, () => {
                      var player = Player.Get(SCP507ID);
                      player.CustomInfo = "Не любитель ходить между мирами.";
                      player.RankColor = "pink";
                      player.RankName = "Scp-507";
                      player.MaxHealth = 120;
                      player.Health = 120;
                      player.ShowHint(Config.Hint1, 5f);
                      Cassie.Message("<split>Внимание! <size=0> pitch_0.97 . . . Attention </size><split>Условия содержания SCP-507 нарушены... <size=0> . SCP 5 0 7 has been contained is error made by F R I Z A</size>");
                      Cassie.MessageTranslated(String.Empty,"<split>Внимание! <size=0> pitch_0.97 . . . Attention </size><split>Условия содержания SСP-507 нарушены... <size=0> . SCP 5 0 7 has been contained is error made by F R I Z A</size>");
                  });
              }
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            if (ev.Player.CustomInfo == "Не любитель ходить между мирами.")
            {
                ev.Player.CustomInfo = null;
            }
        }
        

        public void NoClip(TogglingNoClipEventArgs ev)
        {
            Vector3 targetPosition = new Vector3(94, 998, 20);
            if (ev.Player.CustomInfo == "Не любитель ходить между мирами.")
            {   
                int rand = random.Next(1, 100);

                if (rand <= 50)
                {
                    ev.Player.AddItem(ItemType.Medkit);
                }
                if (rand >= 50)
                {
                    ev.Player.AddItem(ItemType.GunCOM15);
                    ev.Player.AddItem(ItemType.Ammo9x19, 7);
                }
                
                Timing.CallDelayed(15f, () =>
                {
                    ev.Player.RandomTeleport(typeof(Room));
                    if (rand < 50)
                    {
                        ev.Player.EnableEffect(EffectType.MovementBoost, 3, 60);
                    }
                    if (rand > 50)
                    {
                        ev.Player.EnableEffect(EffectType.Scp1853, 1, 60);
                    }
                });
                
                // Штучки для телепортации и изменения и се такое
                ev.Player.Teleport(targetPosition);
                ev.Player.Broadcast(3, "У вас откат 60 секунд! Вы будете куда-то обратно через 15сек.");
                ev.Player.CustomInfo = "Не любитель ходить между мирами. Перезарядка.";
                
                // Случайное перемещение после телепортации 15 сек
                
                // Перезарядка по времени 60 секунд
                Timing.CallDelayed(60f, () =>
                {
                    ev.Player.CustomInfo = "Не любитель ходить между мирами.";
                    
                    
                });
            }
            
            // Если стоит Кастом Инфо перезарядки
            if (ev.Player.CustomInfo == "Не любитель ходить между мирами. Перезарядка.")
            {   
                ev.Player.Broadcast(2, "Способность не готова!");
                
            }
        }
    }
}
