using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CambioDeteccion2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        // Suscribirse al evento de finalización del video
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Cambiar a la siguiente escena cuando el video termine
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}

