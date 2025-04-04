using BepInEx;
using HarmonyLib;

namespace NoSnowballKnockback
{
    [BepInPlugin("monky.nosnowballknockback", "NoSnowballKnockback", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        
        bool enabled;

        void Start()
        { 
            Harmony.CreateAndPatchAll(GetType().Assembly, "monky.nosnowballknockback");
        }

        void OnDisable()
        {
            enabled = false;
        }

        void OnEnable()
        {
            enabled = true;
        }

        void Update()
        {
            if (NetworkSystem.Instance.GameModeString.Contains("MODDED") && enabled)
            {
                Patches.BigBallKnockbackPatch.enable = true;
            }
            else
            {
                Patches.BigBallKnockbackPatch.enable = false;
            }
        }
    }
}