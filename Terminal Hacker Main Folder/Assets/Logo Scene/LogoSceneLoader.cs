using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LogoSceneLoader : MonoBehaviour
{
    // A reference to the VideoPlayer component
    public VideoPlayer VideoPlayer;

    // This function is called when the game starts
    void Start()
    {
        // Subscribes the LoadScene function to the loopPointReached event of the VideoPlayer component
        VideoPlayer.loopPointReached += LoadScene;
    }

    // This function is called when the loop point of the video is reached
    // It loads Main Menu Scene using the SceneManager
    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }


}
