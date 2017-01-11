using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    [SerializeField]
    string _sfxName;

    SoundController soundController;
    [SerializeField]
    GameObject soundControllerObject;

    void Start()
    {
        soundController = soundControllerObject.GetComponent<SoundController>();
        soundController = SoundController.instance;
        if (soundController == null)
        {
            Debug.LogError("There aint no SoundController here man");
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    { 

        if (coll.gameObject.tag == Tags.AUDIOTRIGGER)
        {
            Debug.Log("Well oke this works with sfx Name: "+ _sfxName + " " + soundController);
            soundController.PlaySound(_sfxName); 
        }
    }
}
