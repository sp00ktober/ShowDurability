using HarmonyLib;
using UltimateSurvival.GUISystem;
using UnityEngine;

namespace ShowDurability.Patches.Dynamic
{
    [HarmonyPatch(typeof(Slot))]
    class Slot_Patch
    {
        static float MAX_HEALTH_WOOD = 300f;
        static float MAX_HEALTH_IRON = 600f;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Slot), "Refresh")]
        public static void Refresh_Postfix(Slot __instance)
        {
            if (__instance?.CurrentItem?.Name == "PICKAXE" || __instance?.CurrentItem?.Name == "RAW AXE")
            {
                DurabilityBar bar = (DurabilityBar)AccessTools.Field(typeof(Slot), "m_DurabilityBar").GetValue(__instance);
                bar.SetActive(true);

                bar.SetFillAmount(__instance.CurrentItem.GetPropertyValue("Durability").Float.Current / MAX_HEALTH_WOOD);

                __instance.Refreshed.Send(__instance);
            }
            else if (__instance?.CurrentItem?.Name == "METAL PICKAXE" || __instance?.CurrentItem?.Name == "METAL AX")
            {
                DurabilityBar bar = (DurabilityBar)AccessTools.Field(typeof(Slot), "m_DurabilityBar").GetValue(__instance);
                bar.SetActive(true);

                bar.SetFillAmount(__instance.CurrentItem.GetPropertyValue("Durability").Float.Current / MAX_HEALTH_IRON);

                __instance.Refreshed.Send(__instance);
            }
        }
    }
}
