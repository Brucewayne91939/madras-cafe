using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShareScreenshot : MonoBehaviour
{
    public Button shareButton;

    private void Start()
    {
        shareButton.onClick.AddListener(TakeAndShareScreenshot);
    }

    void TakeAndShareScreenshot()
    {
        StartCoroutine(CaptureAndShare());
    }

    IEnumerator CaptureAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
        File.WriteAllBytes(filePath, screenImage.EncodeToPNG());

        new NativeShare().AddFile(filePath)
            .SetSubject("Check out my AR menu!")
            .SetText("Just viewed this amazing AR dish ?????? #ARFoodie")
            .Share();
    }
}
