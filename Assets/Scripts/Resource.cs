using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//put script on same object as UIBar and HealthbarVisibility scripts
public class Resource : MonoBehaviour, IResourceChangeable
{

    [SerializeField]private float _resource = 200;
    [SerializeField]private float _maxResource;
    private float _minResource = 0;
    [SerializeField]private string _resourceBarID;

	// Use this for initialization
	void Start ()
    {
        _maxResource = _resource;
	}

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
        ExecuteEvents.Execute<ISendHealth>(this.gameObject, null, (x, y) => x.UpdateBar(_resourceBarID, _resource, _maxResource));
    }
}
