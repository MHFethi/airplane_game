using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;

    private void Awake()
    {
       // Scene currentScene = SceneManager.GetActiveScene();
      //  Debug.Log(currentScene.name);

        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
