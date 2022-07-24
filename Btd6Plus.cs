using Assets.Main.Scenes;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.Main;
using MelonLoader;
using BTD_Mod_Helper;
using Btd6Plus;
using HarmonyLib;

[assembly: MelonInfo(typeof(Btd6Plus.Btd6Plus), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Btd6Plus;

public class Btd6Plus : BloonsTD6Mod
{
    [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
    internal static class TitleScreen_Start
    {
        [HarmonyPostfix]
        private static void Postfix(TitleScreen __instance)
        {
            __instance.arcadePlus.SetActive(true);
        }
    }
    
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
    internal static class MainMenu_Start
    {
        [HarmonyPostfix]
        private static void Postfix(MainMenu __instance)
        {
            __instance.storeBtn.gameObject.SetActive(false);
        }
    }

    
    [HarmonyPatch(typeof(CommonForegroundScreen), nameof(CommonForegroundScreen.Update))]
    internal static class CommonForegroundScreen_Show
    {
        [HarmonyPostfix]
        private static void Postfix(CommonForegroundScreen __instance)
        {
            __instance.buyMoreMonkeyMoneyButton.gameObject.SetActive(false);
            __instance.buyKnowledgeButton.gameObject.SetActive(false);
        }
    }
}