using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public interface IDamageable : IEventSystemHandler
{
    void DecreaseResource(float healthDecreaseAmount);
    void IncreaseResource(float healthIncreaseAmount);
}
