using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform UIHandleRectTransform;
    private bool muted;
    private bool toggleOn;

    private Toggle toggle;

    private Vector2 handlePosition;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = UIHandleRectTransform.anchoredPosition;
        
        
        toggle.onValueChanged.AddListener(OnSwitch);
        toggle.isOn = muted;
        if (toggle.isOn)
        {
            OnSwitch(muted);

            if (!PlayerPrefs.HasKey("muted"))
            {
                PlayerPrefs.SetInt("muted", 0);
                Load();
            }
            else
            {
                Load();
            }
        }
        
        AudioListener.pause = muted;
    }

    void OnSwitch(bool on)
    {
        UIHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
         
        }

        Save();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
