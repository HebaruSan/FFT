﻿using BepInEx;
using HarmonyLib;
using KSP.Game;
using KSP.Messages;
using SpaceWarp;
using SpaceWarp.API.Mods;
using UnityEngine;

namespace FTT
{

    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
    public class FTTPlugin : BaseSpaceWarpPlugin
    {
        public const string ModGuid = MyPluginInfo.PLUGIN_GUID;
        public const string ModName = MyPluginInfo.PLUGIN_NAME;
        public const string ModVer = MyPluginInfo.PLUGIN_VERSION;
        public static FTTPlugin Instance { get; set; }
        public static string Path { get; private set; }

        public override void OnPreInitialized()
        {
            FTTPlugin.Path = this.PluginFolderPath;
        }
        public override void OnInitialized()
        {
            base.OnInitialized();


            ColorsPatch.DeclareParts("FTT", (IEnumerable<string>)new List<string>()
            {
                "CV_101",
            });
            FTT.FTTPlugin.Instance = this;
            Harmony.CreateAndPatchAll(typeof(FTTPlugin).Assembly, (string)null);
        }
        public override void OnPostInitialized() => base.OnPostInitialized();

    }
}