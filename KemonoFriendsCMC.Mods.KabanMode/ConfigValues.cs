using BepInEx.Configuration;

namespace KemonoFriendsCMC.Mods.KabanMode
{
    /// <summary>
    /// BepInExで管理するコンフィグの値を保持するクラス
    /// </summary>
    public static class ConfigValues
    {
        /// <summary>
        /// 本パッチが有効かどうか
        /// </summary>
        public static ConfigEntry<bool> Enabled { get; private set; }

        /// <summary>
        /// 初期化処理
        /// <see cref="EntryPoint"/>以外で呼ばないように
        /// </summary>
        /// <param name="configFile"><see cref="EntryPoint"/>のConfigプロパティ</param>
        public static void Initialize(ConfigFile configFile)
        {
            Enabled = configFile.Bind("General", nameof(Enabled), false); // パッチ導入後、意図的に有効化するまで無効にする為、初期値はfalse
        }
    }
}
