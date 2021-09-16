using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   public static Manager Instance { set; get; }
   private Dictionary<int, Vector2> activeTouches = new Dictionary<int, Vector2>();

    #region Singleton
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    #endregion

    public Vector3 GetPlayerInput()
    {
        // Read all touches from user
        Vector3 r = Vector3.zero;
        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {                      // if we just starting pressing on the screen
                activeTouches.Add(touch.fingerId, touch.position);
            } else if (touch.phase == TouchPhase.Ended) {               // if we remove our finger off the screen
                if (activeTouches.ContainsKey(touch.fingerId))
                    activeTouches.Remove(touch.fingerId);
            }  else {                                                  // Else, our finger is either moving or stationary, in both cases, let's use the delta
                float mag = 0;
                r = (touch.position - activeTouches[touch.fingerId]);
                mag = r.magnitude / 300;
                r = r.normalized * mag;
            }
        }
        return r;
    }


}
