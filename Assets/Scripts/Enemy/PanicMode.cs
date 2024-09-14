using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicMode : MonoBehaviour
{
    PatrolBehave patrol;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        patrol = GetComponent<PatrolBehave>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TestVision.panic == true)
        {
            animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
            animator.SetBool("rest", false);
            animator.SetBool("busy", false);
            Debug.Log("Panicking");
            patrol.enabled = false;
            if (player.transform.position.x > transform.position.x)
            {
                rb.AddForce(Vector2.left * moveSpeed);
                FlipLeft();
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
                FlipRight();
            }
        }
    }
    void FlipLeft()
    {
        Vector2 scale = transform.localScale;
        scale.x = -1;
        transform.localScale = scale;
    }
    void FlipRight()
    {
        Vector2 scale = transform.localScale;
        scale.x = 1;
        transform.localScale = scale;
    }
}
