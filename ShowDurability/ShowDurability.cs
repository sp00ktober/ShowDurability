using BepInEx;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace ShowDurability
{
    [BepInPlugin("com.sp00ktober.ShowDurability", "ShowDurability", "0.0.4")]
    public class ShowDurability : BaseUnityPlugin
    {
        private void Awake()
        {
            InitPatches();
        }

        private static void InitPatches()
        {
            Debug.Log("Patching Starsand...");

            try
            {
                Debug.Log("Applying patches from ShowDurability 0.0.4");

                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.sp00ktober.de");

                Debug.Log("Patching completed successfully");
            }
            catch (Exception ex)
            {
                Debug.Log("Unhandled exception occurred while patching the game: " + ex);
            }
        }
    }
}
