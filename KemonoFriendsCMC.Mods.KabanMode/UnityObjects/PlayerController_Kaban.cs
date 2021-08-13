using HarmonyLib;
using UnityEngine;

namespace KemonoFriendsCMC.Mods.KabanMode.UnityObjects
{
    /// <summary>
    /// <see cref="PlayerController"/>をかばんちゃん用にしたクラス
    /// </summary>
    public class PlayerController_Kaban : PlayerController
    {
        protected override void Awake()
        {
            base.Awake();
            moveCost.attack = 90.0f; // Friends_Kabanのスタミナのコスト90に合わせる
        }
        protected override void Start()
        {
            base.Start();
            // CharacterBaseのcBaseフィールドをこのPlayerControllerに変更する
            // （呼ばれる順番によっては上手く動かないかも 動かない場合はLateUpdate等にすべきですが記載量が増えるので様子見）
            Traverse traverse = Traverse.Create(GetComponent<Throwing>());
            traverse.Field<CharacterBase>("cBase").Value = this;
        }

        protected override void Attack()
        {
            SetChatOnAttack();
            AttackPaperPlane();
        }

        /// <summary>
        /// <see cref="FriendsBase"/>のAttack()（キャラのメッセージ表示）と同等の処理を実施
        /// </summary>
        protected virtual void SetChatOnAttack()
        {
            if (!chatKeyInitialized)
            {
                return;
            }
            int num = Random.Range(mesAtkMin, mesAtkMax + 1);
            if (num >= 0 && num < chatKey_Damage.Length)
            {
                SetChat(chatKey_Attack[num], 10, 2f, true);
            }
        }

        /// <summary>
        /// <see cref="Friends_Kaban"/>のAttack()（紙飛行機投げ）と同等の処理を実施
        /// </summary>
        protected virtual void AttackPaperPlane()
        {
            float num = (isSuperman ? 1.3333334f : 1f) * 2f;
            throwing.target = targetTrans;
            // 近づきすぎた場合に離れるような処理は実装しない（プレイヤー操作では邪魔になる）
            AttackBase(
                0,
                1f,
                1f,
                GetCost(CostType.Attack),
                2.7333333f / num,
                5.7333336f / num,
                0f,
                num,
                true,
                -1f
                );
        }
    }
}
