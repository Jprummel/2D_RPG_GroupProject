using UnityEngine;
using System.Collections;

public class BGMusicStarter : MonoBehaviour
{

    [SerializeField]
    string backgroundMusicName;

    SoundController soundController;

    void Start()
    {
        soundController = SoundController.instance;
        if (soundController == null)
        {
            Debug.LogError("There aint no SoundController here man");
        }
        soundController.PlaySound(backgroundMusicName);
    }

}
