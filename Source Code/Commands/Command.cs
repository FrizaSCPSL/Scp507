using System;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Permissions.Extensions;
using MEC;
using Scp507;
using RemoteAdmin;
using Exiled.CustomRoles;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Respawning;
using UnityEngine;

namespace Scp507.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnSCP507 : ICommand
    {
        
       
        public string Command { get; } = "spawnscp507";

        public string[] Aliases { get; } = new string[]
        {
            "scp507",
            "spawn507"
        };

        public string Description { get; } = "Смена класса на Scp-507";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Player player = Player.Get(arguments.At(0));
            if (player == null)
            {
                response = $"Игрок не найден: {arguments.At(0)}";
                return false;
            }

            else
            {
                player.Role.Set(RoleTypeId.ClassD);
                player.CustomInfo = "Не любитель ходить между мирами.";
                player.RankColor = "pink";
                player.RankName = "Scp-507";
                player.MaxHealth = 120;
                player.Health = 120;
                Cassie.Message("<split>Внимание! <size=0> pitch_0.97 . . . Attention </size><split>Условия содержания SCP-507 нарушены... <size=0> . SCP 5 0 7 has been contained is error made by F R I Z A</size>");
                Cassie.MessageTranslated(String.Empty,"<split>Внимание! <size=0> pitch_0.97 . . . Attention </size><split>Условия содержания SСP-507 нарушены... <size=0> . SCP 5 0 7 has been contained is error made by F R I Z A</size>");
                response = "Done";
                return true;
            }
        }
    }
}