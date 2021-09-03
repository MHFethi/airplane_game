using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));

        // Are we using the accelerometer and can we use it ?
        if(state.usingAccelerometer && !SystemInfo.supportsAccelerometer)
        {
            // IF we can't make sure we're not trying next time
            state.usingAccelerometer = false;
            Save();
        }

    }

    // Save the whole state of this saveState script to the player prefs
    public void Save()
    {
         PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    /*Load the previous saved state from the player prefs*/
    public void Load()
    {
        // Do we already have a save ?
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file found, creating a new one!");
            }
    }


}
