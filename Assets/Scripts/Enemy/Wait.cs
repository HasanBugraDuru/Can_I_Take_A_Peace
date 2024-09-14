using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour,IActionable
{
    public PatrolBehave patrol;
    public GameObject npc;
    float waitTimeCounter;
    [SerializeField]float  _waitTime;
    public bool startTimer;

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
            npc.GetComponentInChildren<Animator>().SetBool("rest", false);
            startTimer = false;
            patrol.readyToMove = true;
        }
        else if(startTimer)
        {
            patrol.readyToMove = false;
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
       patrol= collision.gameObject.GetComponent<PatrolBehave>();
        npc = collision.gameObject;
    }

    public void action()
    {
        startTimer = true;
        npc.GetComponentInChildren<Animator>().SetBool("rest", true);
        Debug.Log("TEST ACTÝON");
    }
}
