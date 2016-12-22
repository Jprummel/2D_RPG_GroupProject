using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        //This function loads a scene with the name of the scene to be loaded as a parameter
        SceneManager.LoadScene(sceneName);
    }
}
