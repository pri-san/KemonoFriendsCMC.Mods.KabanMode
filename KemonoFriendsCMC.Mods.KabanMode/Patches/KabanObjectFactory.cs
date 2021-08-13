﻿using HarmonyLib;
using KemonoFriendsCMC.Mods.KabanMode.UnityObjects;
using KemonoFriendsCMC.Mods.KabanMode.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace KemonoFriendsCMC.Mods.KabanMode.Patches
{
    public static class KabanObjectFactory
    {
        public static GameObject InstantiateKabanObj(
            CharacterManager __instance,
            Vector3? position,
            Quaternion? rotation
            )
        {
            GameObject kabanPrefab = Resources.Load<GameObject>("Prefab/Friends/001_Kaban");
            GameObject result = position.HasValue && rotation.HasValue ?
                Object.Instantiate(kabanPrefab, position.Value, rotation.Value) :
                Object.Instantiate(kabanPrefab);
            result.SetActive(false); // 非アクティブにすることでオブジェクト加工中にStart()等が実行されないようにする

            // NPC用かばんちゃんのオブジェクトから不要なコンポーネントや子オブジェクトを削除
            Object.Destroy(result.GetComponent<AgentLinkMover>());
            Object.Destroy(result.GetComponent<NavMeshAgent>());
            Object.Destroy(result.GetComponent<Friends_Kaban>());
            Object.Destroy(result.transform.Find("SearchArea_Friends").gameObject);

            // サーバルちゃんのプレハブからコンポーネントやオブジェクトを追加
            GameObject playerPrefab = __instance.playerPrefab[0];
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("SearchArea_Player").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("ItemGetter").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("Canvas_Pointer").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("Pointer").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("AudioListener").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("ImpactPivot").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("AntimatterPivot").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("ScrewPivot").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("JudgeFootMaterial").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("ThrowFrom_Spin").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("ThrowFrom_Wave").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("BoltPivot").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("Canvas").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("GrassDisplacer").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("CConCenterPivot").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("LookAt").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("WallBreaker").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("WallBreakerSp").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("EffectPivot_PileEnd").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("PileAttackChecker").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("TouchChecker").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("Obstacle").gameObject);
            UnityObjectUtil.AddCloneChild(result, playerPrefab.transform.Find("Balloon_Alart_World").gameObject);

            // かばんちゃん用PlayerControllerを追加
            Friends_Kaban friendsKaban = kabanPrefab.GetComponent<Friends_Kaban>();
            PlayerController pConOrigin = playerPrefab.GetComponent<PlayerController>();
            PlayerController_Kaban pCon = result.AddComponent<PlayerController_Kaban>();
            UnityObjectUtil.ApplyComponentValue(pCon, pConOrigin);
            pCon.pointer = result.transform.Find("Pointer(Clone)");
            pCon.lookAtTarget = result.transform.Find("LookAt(Clone)");
            pCon.grassDisplacer = result.transform.Find("GrassDisplacer(Clone)").gameObject;
            pCon.cConCenterPivot = result.transform.Find("CConCenterPivot(Clone)");
            pCon.wallBreaker = result.transform.Find("WallBreaker(Clone)").gameObject;
            pCon.wallBreakerSp = result.transform.Find("WallBreakerSp(Clone)").gameObject;
            pCon.judgeFootMaterial = result.transform.Find("JudgeFootMaterial(Clone)").GetComponent<JudgeFootMaterial>();
            pCon.obstacleForGrounded = result.transform.Find("Obstacle(Clone)").GetComponent<NavMeshAgent>();
            pCon.audioListener = result.transform.Find("AudioListener(Clone)");
            pCon.pileAttackChecker = result.transform.Find("PileAttackChecker(Clone)").gameObject;
            pCon.searchArea = new SearchArea[]
            {
                result.transform.Find("SearchArea_Player(Clone)").GetComponent<SearchArea>()
            };
            pCon.searchTarget = new GameObject[]
            {
                result.transform.Find("152.!Root/15.joint_HipMaster/CConCenter/SearchTarget").gameObject,
            };
            pCon.drownHeightPivot = result.transform.Find("DrownHeightPivot");
            pCon.footstepDetectionObj = new GameObject[0]; //TODO 足跡つけるオブジェクトを実装
            pCon.goldenMatSet = new CharacterBase.ChangeMatSet[0]; //TODO 金みんみ所持時の見た目変更を実装（優先度低）
            pCon.photoExclude = new GameObject[]
            {
                 result.transform.Find("SearchArea_Player(Clone)/TargetUI_Canvas").gameObject,
                 result.transform.Find("Pointer(Clone)/PointerBody").gameObject,
            };
            pCon.projectileNoticeObj = result.transform.Find("Balloon_Alart_World(Clone)").gameObject;
            pCon.cloth = null;
            pCon.touchChecker = new CheckTriggerStay[]
            {
                result.transform.Find("TouchChecker(Clone)").GetComponent<CheckTriggerStay>(),
            };
            pCon.weapon = new FriendsBase.Weapon[0];
            pCon.pilePivot = result.transform.Find("152.!Root");
            pCon.antimatterPivot = result.transform.Find("AntimatterPivot(Clone)");
            pCon.breathPivot = result.transform.Find("152.!Root/15.joint_HipMaster/3.joint_Torso/4.joint_Torso2/5.joint_Neck/6.joint_Head/BreathPivot");
            pCon.centerPivot = result.transform.Find("152.!Root/15.joint_HipMaster");
            {
                pCon.effect[5].pivot = pCon.pilePivot; // Eff_PlayerAttackPileEnd
                pCon.effect[7].pivot = pCon.centerPivot; // Eff_PlayerQuick
            }
            pCon.talkName = friendsKaban.talkName;

            // 子オブジェクトの値を加工
            {
                DamageDetectionKnockAssort damageDetectionKnockAssort = result.transform.Find("152.!Root/15.joint_HipMaster/CConCenter/DamageDetection").GetComponent<DamageDetectionKnockAssort>();
                damageDetectionKnockAssort.checkDodge = false; // 自動回避オフ
            }
            {
                Throwing throwing = friendsKaban.GetComponent<Throwing>();
                // fromの値をクローン後のものに変更
                throwing.throwSettings[0].from = result.transform.Find("152.!Root/15.joint_HipMaster/3.joint_Torso/4.joint_Torso2/31.joint_RightShoulder/34.joint_RightArm/39.joint_RightElbow/45.joint_RightWrist/47.!joint_RightWristTip/ThrowFrom").gameObject;
            }
            {
                Traverse traverse = Traverse.Create(result.transform.Find("152.!Root/15.joint_HipMaster/CConCenter/DamageDetection").GetComponent<DamageDetectionKnockAssort>());
                // PlayerControllerをクローン後のものに変更
                traverse.Field<CharacterBase>("parentCBase").Value = pCon;
            };

            // ゲームオブジェクトのプロパティを変更
            result.layer = pConOrigin.gameObject.layer;
            result.tag = pConOrigin.gameObject.tag;

            result.SetActive(true); // 最後にアクティブにする
            return result;
        }
    }
}