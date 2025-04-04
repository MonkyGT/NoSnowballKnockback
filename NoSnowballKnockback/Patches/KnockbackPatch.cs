using HarmonyLib;
using UnityEngine;

namespace NoSnowballKnockback.Patches
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer), "ApplyKnockback")]
    public class KnockbackPatch
    {
        public static bool enabled = true;

        public static bool Prefix(Vector3 direction, float speed)
        { 
            if (enabled)
            {
                direction = Vector3.zero;
                speed = 0f;
                return false;
            }
            return true;
        }
    }
}