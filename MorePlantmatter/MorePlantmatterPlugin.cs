using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using MorePlantmatter.Patches;
using UnityEngine;

namespace MorePlantmatter
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class MorePlantmatterPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.equinox.MorePlantmatter";
        private const string PluginName = "MorePlantmatter";
        private const string VersionString = "1.0.0";

        private const string multiplierKey = "Multiplier";
        public static ConfigEntry<int> multiplier;

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake() {
            multiplier = Config.Bind("General", multiplierKey, 2, new ConfigDescription("Multiplier for amount of plantmatter gained when harvesting plants", new AcceptableValueRange<int>(1, 10)));
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();

            Harmony.CreateAndPatchAll(typeof(HitDestructibleActionPatch));

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
            Log = Logger;
        }

        private void Update() {
            // ToDo: Delete If Not Needed
        }
    }
}
