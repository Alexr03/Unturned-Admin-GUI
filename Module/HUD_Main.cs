using SDG.Unturned;
using System;
using UnityEngine;

namespace Module
{
    public class HUD_Main : MonoBehaviour
    {
        public Rect Menu = new Rect(10f, 10f, 300f, 300f);

        public bool MenuOn;

        public void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading && this.MenuOn)
            {
                this.Menu = GUILayout.Window(1, this.Menu, new GUI.WindowFunction(this.windowContent), "Admin Menu");
                PlayerUI.window.showCursor = true;
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                this.MenuOn = !this.MenuOn;
            }
        }

        public void windowContent(int id)
        {
            GUILayout.Label("Welcome: " + ControlConnector.getLocalPlayer().name);

            GUILayout.Label("Current Players: " + Provider.clients.Count.ToString() + "/" + Provider.maxPlayers);

            GUILayout.Label("Key bindings:");
            GUILayout.Label("F1 = This menu.");
            GUILayout.Label("F2 = Player Menu");
            GUILayout.Label("F3 = Server Settings Menu");
            GUILayout.Label("F4 = Core Admin Menu (SuperAdmin and above)");

            GUI.DragWindow();
        }
    }
}