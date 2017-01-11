using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour, IDamageable {

    public delegate void SendResourceAction(string barID, float resource, float maxResource);
    public static event SendResourceAction OnSendResource;

    [SerializeField]private float _resource = 200;
    [SerializeField]private float _maxResource;
    private float _minResource = 0;

	// Use this for initialization
	void Start ()
    {
        _maxResource = _resource;
	}

    /*void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            if (OnSendHealth != null)
            {
                _health -= 5;
                SendHealthChange();
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            _health += 5;
            SendHealthChange();
        }

        

        else if(_health > 200)
        {
            _health = _maxHealth;
        }
#endif
    }*/

    public void DecreaseResource(float resourceDecreaseAmount)
    {
        _resource -= resourceDecreaseAmount;
        SendResourceChange();

        if (_resource < 0)
        {
            _resource = _minResource;
        }
    }

    public void IncreaseResource(float resourceIncreaseAmount)
    {
        _resource += resourceIncreaseAmount;
        SendResourceChange();

        if (_resource > 200)
        {
            _resource = _maxResource;
        }
    }

    void SendResourceChange()
    {
        OnSendResource(gameObject.tag, _resource, _maxResource);
    }
}
