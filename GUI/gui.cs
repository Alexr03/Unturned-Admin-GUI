using Rocket.API;
using Rocket.API.Extensions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GUI
{
    class CommandGUI : PlayerCaller, IRocketCommand
    {

        public string Help
        {
            get { return ""; }
        }

        public string Name
        {
            get { return "gui"; }
        }

        public string Syntax
        {
            get { return "syntax"; }
        }

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Player; }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>() { "gui" };
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer plr = (UnturnedPlayer)caller;

            plr.Player.transform.gameObject.TryAddComponent<Module.HUD2>();
        }
    }

}
