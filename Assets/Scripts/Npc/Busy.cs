using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busy : MonoBehaviour, IActionable
{
    public PatrolBehave patrol;
    public GameObject npc;
    float waitTimeCounter;
    [SerializeField] float _waitTime;
    public bool startTimer;
    [SerializeField] VisionCheck visionCheck;

    private void Awake()
    {

        waitTimeCounter = 0f;
    }


    void Update()
    {
        if (startTimer)
        {
            waitTimeCounter += Time.deltaTime;
        }
        else
            waitTimeCounter = 0f;

        if (waitTimeCounter > _waitTime)
        {
            npc.GetComponentInChildren<Animator>().SetBool("busy", false);
            visionCheck.enabled = true;
            startTimer = false;
            patrol.readyToMove = true;
        }
        else if (startTimer)
        {
            patrol.readyToMove = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        patrol = collision.gameObject.GetComponent<PatrolBehave>();
        npc = collision.gameObject;
        visionCheck = collision.gameObject.GetComponentInChildren<VisionCheck>();
    }

    public void action()
    {
        startTimer = true;
        npc.GetComponentInChildren<Animator>().SetBool("busy", true);
        visionCheck.enabled = false;
        Debug.Log("TEST ACTÝON");
    }
}

