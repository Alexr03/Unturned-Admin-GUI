using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Module
{
    public class HUD2 : PlayerCaller
    {
        bool visible = false;

        private void Start()
        {
            //base.channel.build();
            //askToggleHud(true);
        }

        public void askToggleHud(bool visible)
        {
            base.channel.send("tellToggleHud", ESteamCall.OWNER, ESteamPacket.UPDATE_RELIABLE_BUFFER, true);
        }

        public void tellToggleHud(CSteamID steamID, bool visible)
        {
            if (base.channel.checkServer(steamID))
            {
                Debug.LogError("CALLED HUD");
                this.visible = visible;
            }
        }

        private void OnGUI()
        {
            if (Dedicator.isDedicated) return;
            GUI.Box(new Rect(20, 110, 200, 20), "ALEX & LINHY IS THE BEST");
            if (visible)
                GUI.Box(new Rect(20, 210, 130, 20), "ALEX IS THE BEST");

        }
    }
}
