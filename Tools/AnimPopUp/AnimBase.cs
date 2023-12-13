using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimBase : MonoBehaviour
{
    public abstract void Open(Transform content, float duration);
    public abstract void Close(Transform content, float duration);
}
