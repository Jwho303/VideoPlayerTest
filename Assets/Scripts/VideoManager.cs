using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public enum PathLocation
    {
        StreamingAssets,
        URL
    }
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public PathLocation pathLocation = VideoManager.PathLocation.URL;
    public string URL;
    public string FileName;
    // Start is called before the first frame update
    void Start()
    {
        if (pathLocation == PathLocation.StreamingAssets)
        {
            URL = Path.Combine(Application.streamingAssetsPath, FileName);
        }

        videoPlayer.url = URL;
        videoPlayer.Prepare();

         StartCoroutine(TryPlayVideo());
    }

    private IEnumerator TryPlayVideo()
    {
        Debug.Log("Trying to play video");
        while (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Video is playing: " + videoPlayer.isPlaying);
    }
}
