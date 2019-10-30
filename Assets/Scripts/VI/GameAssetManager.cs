using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetManager : MonoBehaviour
{
    private static GameAssetManager _i;
    public static GameAssetManager i {
        get {
            if (_i == null) {
                _i = FindObjectOfType<GameAssetManager>();
            }
            return _i;
        }
    }

    public List<SoundClip> soundClipArray = new List<SoundClip>();
    public List<UI_SoundClip> UI_SoundClipArray = new List<UI_SoundClip>();


    [System.Serializable]
    public class SoundClip {
        public AudioClip audioClip;
        public SoundManager.SoundEffects sound;
    }

    [System.Serializable]
    public class UI_SoundClip
    {
        public AudioClip audioClip;
        public SoundManager.UI_SoundEffects UI_sound;
    }

    public PlayerMovementScript pms_Dog;

}
