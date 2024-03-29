using UnityEngine;
using UnityEngine.UI;
using Vuplex.WebView;

public class CrashTest : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(LoadWebview);
    }

    private async void LoadWebview()
    {
        Debug.Log("Load WebView");

        var canvas = GameObject.Find("Canvas");

        var mainWebViewPrefab = CanvasWebViewPrefab.Instantiate();
        mainWebViewPrefab.Resolution = 1f;
        mainWebViewPrefab.PixelDensity = 1;
        mainWebViewPrefab.Native2DModeEnabled = false;
        mainWebViewPrefab.transform.SetParent(canvas.transform, false);

        var rectTransform = mainWebViewPrefab.transform as RectTransform;
        rectTransform.anchoredPosition3D = Vector3.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        mainWebViewPrefab.transform.localScale = Vector3.one;

        await mainWebViewPrefab.WaitUntilInitialized();

        mainWebViewPrefab.WebView.LoadUrl("https://www.google.com");
    }
}
