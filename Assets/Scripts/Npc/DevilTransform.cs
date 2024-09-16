using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTransform : MonoBehaviour, ITransformable
{
    public void ChangColor()
    {
        Destroy(gameObject);
    }
}
