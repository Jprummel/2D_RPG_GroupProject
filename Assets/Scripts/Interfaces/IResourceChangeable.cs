using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public interface IResourceChangeable : IEventSystemHandler
{
    void ChangeResource(float healthDecreaseAmount);
}
