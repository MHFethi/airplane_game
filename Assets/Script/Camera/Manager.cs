using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   public static Manager Instance { set; get; }

      public Material playerMaterial;
        // public Color[] playerColor = new Color[10];
     // public GameObject[] playerTrials = new GameObject[10];
    private Dictionary<int, Vector2> activeTouches = new Dictionary<int, Vector2>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public Vector3 GetPlayerInput()
    {
        // Are we using the accelerometer .
      /*  if (SaveManager.Instance.state.usingAccelerometer)
        {
            // if we can use it, replace the Y param by Z, we don't need that Y
            Vector3 a = Input.acceleration;
            a.y = a.z;
            return a;
        }*/

        // Read all touches from user
        Vector3 r = Vector3.zero;

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)// if we just starting pressing oon the screen
            {
                Debug.Log("TOUCH");
                activeTouches.Add(touch.fingerId, touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)// if we remove our finger off the screen
            {
            if(activeTouches.ContainsKey(touch.fingerId))
                activeTouches.Remove(touch.fingerId);
            }
            else // Our finger is either moving or stationary, in booth cases, let's use the delta
            {
                float mag = 0;
                r = (touch.position - activeTouches[touch.fingerId]);
                mag = r.magnitude / 300;
                r = r.normalized * mag;
            }
        }
        return r;
    }


}
