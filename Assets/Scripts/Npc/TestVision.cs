using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVision : MonoBehaviour, IVisible
{
    [SerializeField] float bustedCounter;
    [SerializeField] float bustedTime;
    [SerializeField] float bustedTimeReq;
    public static bool panic;
    private void Start()
    {
        panic = false;
    }
    private void Update()
    {
        Debug.Log(panic);
        bustedCounter -= Time.deltaTime;
        if (bustedCounter > 0.8)
        {
            bustedTime += Time.deltaTime;
        }
        else
            bustedTime = 0f;
        if (bustedTime > bustedTimeReq)
        {
            panic = true;
            Debug.Log("Busted");
        }
    }
    public void GetSeen()
    {
        bustedCounter = 1f;
    }
}
