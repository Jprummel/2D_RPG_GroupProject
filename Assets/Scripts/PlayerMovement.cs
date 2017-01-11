using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float horizontalSpeed = 5.0F;
    private float verticalSpeed = 5.0F;
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite Up;
    [SerializeField] private Sprite Down;
    [SerializeField] private Sprite Left;
    [SerializeField] private Sprite Right;

    void Update()
    {
        Move();
        changeSprite();
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        h *= Time.deltaTime;
        v *= Time.deltaTime;
        transform.Translate(h, v, 0);
    }

    void changeSprite()
    {
        if (Input.GetAxis("Vertical") >= 0.1f )
        {
            spriteRenderer.sprite = Up;
        }
        else if (Input.GetAxis("Vertical") <= -0.1f)
        {
            spriteRenderer.sprite = Down;
        }
        else if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            spriteRenderer.sprite = Right;
        }
        else if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            spriteRenderer.sprite = Left;
        }
    }
}
