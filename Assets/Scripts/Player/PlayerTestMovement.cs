using UnityEngine;
using System.Collections;

public class PlayerTestMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 5;
	
	// Update is called once per frame
    void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(x, y);
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
