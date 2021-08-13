using HarmonyLib;
using UnityEngine;

namespace KemonoFriendsCMC.Mods.KabanMode.Patches
{
    [HarmonyPatch(typeof(CharacterManager), "SetNewPlayer")]
    public static class CharacterManagerSetNewPlayerPatch
    {
        public static bool Prefix(
            int newPlayerIndex,
            CharacterManager __instance,
            ref PlayerController ___pConInternal
            )
        {
            if (!ConfigValues.Enabled.Value)
            {
                return true;
            }
            else if (newPlayerIndex != 0)
            {
                return true;
            }

            Vector3 position = Vector3.zero;
            Quaternion rotation = Quaternion.identity;
            if (__instance.playerTrans)
            {
                position = __instance.playerTrans.position;
                rotation = __instance.playerTrans.rotation;
            }
            if (__instance.playerObj)
            {
                Object.Destroy(__instance.playerObj);
            }
            __instance.playerIndex = newPlayerIndex;
            __instance.playerObj = KabanObjectFactory.InstantiateKabanObj(__instance, position, rotation);
            ___pConInternal = __instance.playerObj.GetComponent<PlayerController>();
            __instance.playerTrans = __instance.playerObj.transform;
            __instance.playerLookAt = ___pConInternal.lookAtTarget;
            __instance.playerSearchTarget = ___pConInternal.searchTarget[0].transform;
            __instance.playerAudioListener = ___pConInternal.audioListener;
            __instance.lastLandingPosition = __instance.playerTrans.position;
            if (SingletonMonoBehaviour<CameraManager>.Instance)
            {
                SingletonMonoBehaviour<CameraManager>.Instance.SetHorizontalDamping(SingletonMonoBehaviour<GameManager>.Instance.save.cameraSpeed);
            }
            if (SingletonMonoBehaviour<PauseController>.Instance)
            {
                SingletonMonoBehaviour<PauseController>.Instance.ResetPlayerController();
            }
            if (__instance.pIconsMother)
            {
                if (__instance.playerIndex == 2)
                {
                    __instance.pIconsMother.SetSpriteType(1);
                }
                else
                {
                    __instance.pIconsMother.SetSpriteType(0);
                }
            }
            if (SingletonMonoBehaviour<StageManager>.Instance)
            {
                SingletonMonoBehaviour<StageManager>.Instance.ResetHomeFloorNumber(SingletonMonoBehaviour<GameManager>.Instance.save.playerType == 1);
            }

            return false;
        }
    }
}
