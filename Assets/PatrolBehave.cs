using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehave : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] points;
    [SerializeField] Transform nextPoint;
    [SerializeField] int currentPoint;
    [SerializeField] float speed;
    [SerializeField] float moveSpeed;
    public bool readyToMove;

    Rigidbody2D _rb;
    Animator animator;
    void Start()
    {
        currentPoint = 0;
        nextPoint = points[currentPoint].transform;
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        readyToMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        speed = _rb.velocity.x;
        if (Vector2.Distance(transform.position, nextPoint.position) > 1f&&readyToMove)
        {
            if (transform.position.x < nextPoint.position.x)
            {
                _rb.AddForce(Vector2.right * moveSpeed);
            }
            else
                _rb.AddForce(Vector2.left * moveSpeed);

            Debug.Log("MOVE");
        }
        else if(currentPoint+1<=points.Length-1)
        {
            nextPoint = points[currentPoint + 1].transform;
            currentPoint += 1;
            Debug.Log("Arrived");
            
        }
        else
        {
            
            currentPoint = 0;
            nextPoint = points[currentPoint].transform;
            Debug.Log("Resetindex");
        }
        animator.SetFloat("speed", Mathf.Abs(speed));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IActionable>() != null&&collision.gameObject==nextPoint.gameObject&&Vector2.Distance(transform.position,nextPoint.position)<2f)
        {
            collision.gameObject.GetComponent<IActionable>().action();
            Debug.Log("ACT�ON");
        }
    }
}
