using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class DownloadImage : MonoBehaviour
{
    public RawImage rawImage;
    private const string url = "https://picsum.photos/200";

    private IEnumerator Awake()
    {
        yield return Step(url);
    }

    private IEnumerator Step(string url)
    {
        using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        
        rawImage.texture = DownloadHandlerTexture.GetContent(uwr);
        yield return uwr.SendWebRequest();
    }
}
