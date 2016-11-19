using Rocket.API.Extensions;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Module
{
    public class HUD_CoreAdmin : MonoBehaviour
    {
        public Rect Menu = new Rect(1110f, 10f, 300f, 300f);
        public bool MenuOn;

        private void Start()
        {
            //base.channel.build();
            //askToggleHud(true);
        }

        public void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading && this.MenuOn)
            {
                this.Menu = GUILayout.Window(4, this.Menu, new GUI.WindowFunction(this.windowContent), "Core Admin Menu");
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                this.MenuOn = !this.MenuOn;
            }
        }

        public void windowContent(int ID)
        {
            if (ControlConnector.getLocalPlayer().channel.owner.isAdmin)
            {
                var Shutdown_style = new GUIStyle(GUI.skin.button);
                Shutdown_style.normal.textColor = Color.red;
                Shutdown_style.stretchWidth = true;
                Shutdown_style.fontSize = 20;



                GUILayout.Label("Other Core Admins online right now: ");

                foreach (SteamPlayer p in Provider.clients)
                {
                    if (p.player.channel.owner.isAdmin)
                    {
                        GUILayout.Label("Admin: " + p.player.name);
                    }
                }

                if (GUILayout.Button("Rocket Reload"))
                {
                    ChatManager.sendChat(EChatMode.GROUP, "/rocket reload");
                }
                if (GUILayout.Button("Permissions Reload"))
                {
                    ChatManager.sendChat(EChatMode.GROUP, "/p reload");
                }
                if (GUILayout.Button("Shutdown", Shutdown_style))
                {
                    ChatManager.sendChat(EChatMode.GROUP, "/save");
                    ChatManager.sendChat(EChatMode.GROUP, "/shutdown");
                }
            }
            else
            {
                var NoAdmin_style = new GUIStyle(GUI.skin.label);
                NoAdmin_style.normal.textColor = Color.red;
                NoAdmin_style.fontSize = 25;

                GUILayout.Label("You are not a Core Admin, this feature is for SuperAdmin and above.", NoAdmin_style);
            }

            GUI.DragWindow();
        }
    }
}