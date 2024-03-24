using HarmonyLib;
using PropStreaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MorePlantmatter.Patches
{
    internal class HitDestructibleActionPatch
    {
        [HarmonyPatch(typeof(HitDestructibleAction), "GetPlayerInventoryChanges")]
        [HarmonyPrefix]
        static void AddMorePlantmatter(HitDestructibleAction __instance) {
            foreach (InstanceLookup lookup in __instance.info.propLookups) {
                DestructibleData data;
                if(PropManager.instance.GetDestructibleData(lookup, out data) && data.WouldBeDestroyed(lookup, __instance.info.hitStrength)) {
                    foreach (DestructibleReward reward in data.rewards) {
                        if (reward != null && reward.resource.displayName == "Plantmatter") {
                            Debug.Log($"Multiplying plantmatter reward by {MorePlantmatterPlugin.multiplier.Value}");
                            reward.quantity *= MorePlantmatterPlugin.multiplier.Value;
                        }
                    }
                }
            }
        }
    }
}
