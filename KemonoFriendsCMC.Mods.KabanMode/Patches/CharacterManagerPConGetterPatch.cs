using HarmonyLib;
using UnityEngine;

namespace KemonoFriendsCMC.Mods.KabanMode.Patches
{
    [HarmonyPatch(typeof(CharacterManager), "pCon", MethodType.Getter)]
    public static class CharacterManagerPConGetterPatch
    {
        public static void Prefix(
            CharacterManager __instance,
            ref PlayerController ___pConInternal
            )
        {
            if (!ConfigValues.Enabled.Value)
            {
                return;
            }
            if (___pConInternal)
            {
                return;
            }

            GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < array.Length; i++)
            {
                ___pConInternal = array[i].GetComponent<PlayerController>();
                if (___pConInternal)
                {
                    __instance.playerObj = array[i];
                    break;
                }
            }
            if (!__instance.playerObj)
            {
                if (SingletonMonoBehaviour<GameManager>.Instance)
                {
                    __instance.playerIndex = __instance.GetOriginallyPlayerIndex;
                }
                // playerIndex == 0の時、かばんちゃんに変更
                if (__instance.playerIndex != 0)
                {
                    return;
                }
                __instance.playerObj = KabanObjectFactory.InstantiateKabanObj(__instance, null, null);
                ___pConInternal = __instance.playerObj.GetComponent<PlayerController>();
            }
            __instance.playerTrans = __instance.playerObj.transform;
            __instance.playerLookAt = ___pConInternal.lookAtTarget;
            __instance.playerSearchTarget = ___pConInternal.searchTarget[0].transform;
            __instance.playerAudioListener = ___pConInternal.audioListener;
            __instance.lastLandingPosition = __instance.playerTrans.position;
        }
    }
}
