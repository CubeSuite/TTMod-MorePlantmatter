using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace MorePlantmatter
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class MorePlantmatterPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.equinox.MorePlantmatter";
        private const string PluginName = "MorePlantmatter";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake() {
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();

            // ToDo: Apply Patches

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
            Log = Logger;
        }

        private void Update() {
            // ToDo: Delete If Not Needed
        }
    }
}
