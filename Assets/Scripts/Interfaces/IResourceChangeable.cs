using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public interface IResourceChangeable : IEventSystemHandler
{
    void DecreaseResource(float healthDecreaseAmount);
    void IncreaseResource(float healthIncreaseAmount);
}
