using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVision : MonoBehaviour,IVisible
{
    public void GetSeen()
    {
        Debug.Log("Seen");
    }
}
