using HarmonyLib;
using UnityEngine;

namespace KemonoFriendsCMC.Mods.KabanMode.Patches
{
    [HarmonyPatch(typeof(EnemyBaseBoss), "TakeDamage")]
    public static class EnemyBaseBossTakeDamagePatch
    {
        public static void Prefix(
            EnemyBaseBoss __instance,
            ref CharacterBase attacker
            )
        {
            if (!ConfigValues.Enabled.Value)
            {
                return;
            }
            // 他のフレンズの攻撃でもトドメをさせるよう修正
            if (__instance.GetNowHP() == 1)
            {
                attacker = null;
            }
        }
    }
}
