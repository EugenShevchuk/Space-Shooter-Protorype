using System;
using UnityEngine;

public static class LoadingScreen
{
    private const string PATH = "[LOADING SCREEN]";

    private static LoadingScreenVisual visual;

    private static void CreateLoadingScreen()
    {
        var prefab = Resources.Load<LoadingScreenVisual>(PATH);
        var loadingScreen = UnityEngine.Object.Instantiate(prefab);
        Resources.UnloadUnusedAssets();

        visual = loadingScreen;
    }

    public static void Show()
    {
        if (visual == null)
            CreateLoadingScreen();

        visual.Show();
    }

    public static void Hide()
    {
        if (visual == null)
            throw new Exception("You cant hide loading screen before creating");

        visual.Hide();
    }
}
