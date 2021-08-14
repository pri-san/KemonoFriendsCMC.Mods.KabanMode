using HarmonyLib;

namespace KemonoFriendsCMC.Mods.KabanMode.Patches
{
    [HarmonyPatch(typeof(CharacterManager), "EmitEffect")]
    public static class CharacterManagerEmitEffectPatch
    {
        public static void Prefix(
            int effectNum,
            ref int friendsId
            )
        {
            if (!ConfigValues.Enabled.Value ||
                !SingletonMonoBehaviour<CharacterManager>.Instance || SingletonMonoBehaviour<CharacterManager>.Instance.playerIndex != 0 || 
                effectNum < 64 || effectNum > 75 || friendsId != 1
                )
            {
                return;
            }
            // playerIndex == 0、かつ爆弾の時、爆弾の生成位置をプレイヤーに変更
            friendsId = -1;
        }
    }
}
