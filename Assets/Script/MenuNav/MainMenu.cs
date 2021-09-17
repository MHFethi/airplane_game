using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;
    public SceneFader sceneFader;
    void Awake()
    {
        if (FindObjectOfType<MusicManager>())
            FindObjectOfType<MusicManager>().Stop("battle");
         FindObjectOfType<MusicManager>().Play("intro");
    }

    public void PlayGame()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Bye !");
        Application.Quit();
    }
}
