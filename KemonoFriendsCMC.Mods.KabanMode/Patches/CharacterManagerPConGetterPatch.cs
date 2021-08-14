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
            if (!ConfigValues.Enabled.Value ||
                ___pConInternal
                )
            {
                return;
            }

            PlayerController pConInternal = null;
            GameObject playerObj = null;
            GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < array.Length; i++)
            {
                pConInternal = array[i].GetComponent<PlayerController>();
                if (pConInternal)
                {
                    playerObj = array[i];
                    break;
                }
            }
            if (!playerObj)
            {
                int playerIndex = __instance.playerIndex;
                if (SingletonMonoBehaviour<GameManager>.Instance)
                {
                    playerIndex = __instance.GetOriginallyPlayerIndex;
                }
                // playerIndex == 0の時、かばんちゃんに変更
                if (playerIndex != 0)
                {
                    return;
                }
                __instance.playerIndex = playerIndex;

                __instance.playerObj = KabanObjectFactory.InstantiateKabanObj(__instance, null, null);
                ___pConInternal = __instance.playerObj.GetComponent<PlayerController>();
            }
            else
            {
                __instance.playerObj = playerObj;
                ___pConInternal = pConInternal;
            }

            __instance.playerTrans = __instance.playerObj.transform;
            __instance.playerLookAt = ___pConInternal.lookAtTarget;
            __instance.playerSearchTarget = ___pConInternal.searchTarget[0].transform;
            __instance.playerAudioListener = ___pConInternal.audioListener;
            __instance.lastLandingPosition = __instance.playerTrans.position;
        }
    }
}
