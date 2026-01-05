using System;
using UnityEngine;

public class OnDestroyCallback : MonoBehaviour
{
    public Action onDestroy;

    void OnDestroy()
    {
        onDestroy?.Invoke();
    }
}
