using UnityEngine;
using System.Collections;

//-Swan Chase-
[System.Serializable]
public class Sound
{
    //Class to set up a sound specific audio source
    public string name;//Name so that it can be called from another script
    public AudioClip clip;//The sound/clip you want to use 

    [Range(0f, 1f)]
    public float volume = 0.7f;//Volume slider
    [Range(-1.5f, 1.5f)]
    public float pitch = 1f;//Pitch slider

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;//Random volume changes if wanted
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;//Random pitch changes if wanted

    public bool isLooping = true;//Option for looping

    private AudioSource source;

    //Makes the AudioSource and inputs the audio clip
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    //Sets the random values and looping and plays the clip
    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.loop = isLooping;
        source.Play();
    }

    //Well it stops the clip... big supprise
    public void Stop()
    {
        source.Stop();
    }

}

public class SoundController : MonoBehaviour
{

    public static SoundController instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        //Checking if there are more than one or none Sound controllers in the scene
        if (instance != null)
        {
            Debug.LogError("Whoops more then one SoundController in scene, beter find it ;) ");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        //Goes through the array of sounds and makes new gameObjects with an audioSource for every Sound 
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound " + i + " " + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    //Plays the sound with the same (String) name
    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        // when there is no sound with _name
        Debug.LogWarning("SoundController: Sound not Found in list :( , " + _name);
    }

    //Stops the sound with the same(String) name
    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
        // when there is no sound with _name
        Debug.LogWarning("SoundController: Sound not Found in list :( , " + _name);
    }

    //Pretty obvious isn't it?
    public void StopAllSound()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
            return;
        }
    }

}
