using UnityEngine;
using System.Collections;

public class ChoosePlayerGender : MonoBehaviour {

    private bool _isMale;
    //getter and setter
    public bool IsMale
    {
        get { return _isMale; }
        set { _isMale = value; }
    }

    public void ChooseMale()
    {
        _isMale = true;
        Debug.Log(_isMale);
    }
    
    public void ChooseFemale(){
        _isMale = false;
        Debug.Log(_isMale);
    }
}
