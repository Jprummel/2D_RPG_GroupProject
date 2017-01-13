using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SpriteCollision2D : MonoBehaviour
{
    [SerializeField]private float _damage = 20;

	void OnCollisionEnter2D(Collision2D coll)
    {
        ExecuteEvents.Execute<IResourceChangeable>(coll.gameObject, null, (x, y) => x. DecreaseResource(_damage));
    }
}
