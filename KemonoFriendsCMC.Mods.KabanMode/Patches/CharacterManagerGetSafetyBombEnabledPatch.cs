using HarmonyLib;

namespace KemonoFriendsCMC.Mods.KabanMode.Patches
{
    [HarmonyPatch(typeof(CharacterManager), "GetSafetyBombEnabled")]
    public static class CharacterManagerGetSafetyBombEnabledPatch
    {
        public static bool Prefix(
            ref bool? __result,
            CharacterManager __instance
            )
        {
            if (!ConfigValues.Enabled.Value ||
                __instance.playerIndex != 0
                )
            {
                return true;
            }
            // playerIndex == 0の時、爆弾の自爆を回避（かばんちゃん存在時と同じ）
            __result = true;
            return false;
        }
    }
}
