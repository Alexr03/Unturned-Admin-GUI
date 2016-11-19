using Rocket.API.Extensions;
using SDG.Framework.Modules;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Module
{
    class Module : IModuleNexus
    {
        public static GameObject mainObj;
        public static HUD_Main hudMain;
        public static HUD_Players hudPlayers;
        public static HUD_ServerSettings hudServerSettings;
        public static HUD_CoreAdmin hudCoreAdmin;

        public void initialize()
        {
            Module.mainObj = new GameObject();
            Module.hudMain = Module.mainObj.AddComponent<HUD_Main>();
            Module.hudPlayers = Module.mainObj.AddComponent<HUD_Players>();
            Module.hudServerSettings = Module.mainObj.AddComponent<HUD_ServerSettings>();
            Module.hudCoreAdmin = Module.mainObj.AddComponent<HUD_CoreAdmin>();
            UnityEngine.Object.DontDestroyOnLoad(Module.hudMain);
            UnityEngine.Object.DontDestroyOnLoad(Module.hudPlayers);
            UnityEngine.Object.DontDestroyOnLoad(Module.hudServerSettings);
            UnityEngine.Object.DontDestroyOnLoad(Module.hudCoreAdmin);

        }

        public void shutdown()
        {
<<<<<<< HEAD
            UnityEngine.Object.DestroyObject(Module.hudMain);
            UnityEngine.Object.DestroyObject(Module.hudPlayers);
            UnityEngine.Object.DestroyObject(Module.hudServerSettings);
            UnityEngine.Object.DestroyObject(Module.hudCoreAdmin);
=======
>>>>>>> origin/master
        }
    }
}
