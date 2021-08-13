using UnityEngine;

namespace KemonoFriendsCMC.Mods.KabanMode.Utils
{
    /// <summary>
    /// <see cref="Object"/>関連のユーティリティクラス
    /// </summary>
    public static class UnityObjectUtil
    {
        /// <summary>
        /// クローンした<see cref="GameObject"/>を子に追加する
        /// </summary>
        /// <param name="target">親となる<see cref="GameObject"/></param>
        /// <param name="child">クローンし、子に追加する<see cref="GameObject"/></param>
        /// <returns>クローンした<see cref="GameObject"/></returns>
        public static GameObject AddCloneChild(GameObject target, GameObject child)
        {
            GameObject result = Object.Instantiate(child);
            result.transform.SetParent(target.transform);
            result.transform.localPosition = child.transform.localPosition;
            result.transform.localRotation = child.transform.localRotation;
            return result;
        }

        /// <summary>
        /// publicフィールドの値のみ同じクローンの<see cref="Component"/>を子に追加する
        /// </summary>
        /// <typeparam name="T">クローンする<see cref="Component"/>の型</typeparam>
        /// <param name="target">追加対象の<see cref="GameObject"/></param>
        /// <param name="component">クローンして追加する<see cref="Component"/></param>
        /// <returns>クローンした<see cref="Component"/></returns>
        public static T AddCloneComponent<T>(GameObject target, T component) where T : Component
        {
            T result = target.AddComponent<T>();
            return ApplyComponentValue(result, component);
        }

        /// <summary>
        /// <see cref="Component"/>上のpublicフィールドの値をコピーする
        /// </summary>
        /// <typeparam name="T">コピーする<see cref="Component"/>の型</typeparam>
        /// <param name="target">publicフィールドの値のコピー先の<see cref="Component"/></param>
        /// <param name="component">publicフィールドの値のコピー元の<see cref="Component"/></param>
        /// <returns>引数targetと同じインスタンス</returns>
        public static T ApplyComponentValue<T>(T target, T component) where T : Component
        {
            foreach (var fieldInfo in typeof(T).GetFields())
            {
                object originalValue = fieldInfo.GetValue(component);
                fieldInfo.SetValue(target, originalValue);
            }
            return target;
        }

    }
}
