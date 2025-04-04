using BepInEx;
using HarmonyLib;

namespace NoSnowballKnockback
{
    [BepInPlugin("monky.nosnowballknockback", "NoSnowballKnockback", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        void Start()
        { 
            Harmony.CreateAndPatchAll(GetType().Assembly, "monky.nosnowballknockback");
        }

        void Update()
        {
            if (NetworkSystem.Instance.GameModeString.Contains("MODDED"))
            {
                Patches.KnockbackPatch.enabled = true;
            }
            else
            {
                Patches.KnockbackPatch.enabled = false;
            }
        }
    }
}