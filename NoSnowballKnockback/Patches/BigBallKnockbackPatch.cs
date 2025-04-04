using HarmonyLib;
using UnityEngine;

namespace NoSnowballKnockback.Patches
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer), "ApplyKnockback")]
    public class BigBallKnockbackPatch
    {
        public static bool enable = true;

        public static bool Prefix(Vector3 direcy, float speedy)
        { 
            if (enable)
            {
                direcy = Vector3.zero;
                speedy = 0f;
                return false;
            }
            return true;
        }
    }
}