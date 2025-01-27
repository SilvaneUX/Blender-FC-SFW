using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        videoPlayer.loopPointReached += VideoPlayer_LoopPointreached;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VideoPlayer_LoopPointreached(VideoPlayer source)
    {
        SceneManager.LoadScene(1);
    }
}
