using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace Scp507
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        public bool Debug { get; set; } = false;
        public string Hint1 { get; set; } = "SCP-507";
        public int spawnChance { get; set; } = 5;
        
        public int xPos { get; set; } = 1;
        
        public int yPos { get; set; } = 1;
        
        public int zPos { get; set; } = 1;
    }
}