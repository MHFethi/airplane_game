using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public AudioSource AudioSource;

   private bool IsMute;
   private int IsItMuteOrNot;
   
   private void Start()
   {
       AudioSource.Play();
       IsItMuteOrNot = PlayerPrefs.GetInt("mute");
       if (IsItMuteOrNot == 1)
           AudioSource.mute = true;
       else if (IsItMuteOrNot == 0)
           AudioSource.mute = false;
   }

   private void Update()
   {
       AudioSource.mute = IsMute;
       var mutePrefs = IsMute ? 1 : 0;
       PlayerPrefs.SetInt("mute", mutePrefs);
   }

   public void MuteUpdater(bool muteParam)
   {
       IsMute = muteParam;
   }
}
