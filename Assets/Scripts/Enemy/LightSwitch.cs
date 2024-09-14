using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering.Universal;
public class LightSwitch : MonoBehaviour
{
    VisionCheck visionCheck;
    // Start is called before the first frame update
    void Start()
    {
        visionCheck = transform.parent.GetComponentInChildren<VisionCheck>();
    }
 

    public void LightToggle()
    {
        visionCheck.enabled = !visionCheck.enabled;
    }
}
