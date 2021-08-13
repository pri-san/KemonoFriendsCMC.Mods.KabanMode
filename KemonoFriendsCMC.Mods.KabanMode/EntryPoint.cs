using BepInEx;
using HarmonyLib;

namespace KemonoFriendsCMC.Mods.KabanMode
{
    /// <summary>
    /// BepInExのパッチのエントリーポイント
    /// </summary>
    [BepInPlugin("KemonoFriendsCMC.Mods.KabanMode", "KabanMode Plug-In", "1.0.0.0")]
    public class EntryPoint : BaseUnityPlugin
    {
        void Awake()
        {
            ConfigValues.Initialize(Config);

            Harmony harmony = new Harmony("KemonoFriendsCMC.Mods.KabanMode");
            harmony.PatchAll(); // ここでHarmonyによるモンキーパッチが実行される


            UnityEngine.Debug.Log("KemonoFriendsCMC.Mods.KabanMode Patch OK");
        }
    }
}
