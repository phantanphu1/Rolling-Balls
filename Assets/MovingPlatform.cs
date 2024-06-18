using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector3 targetPos;
    private void Start()
    {
        targetPos = posB.position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.CompareTag("Player"))
    //     {
    //         col.transform.parent = this.transform;
    //     }

    // }
    // private void OnCollisionExit2D(Collider2D col)
    // {
    //     if (col.CompareTag("Player"))
    //     {
    //         col.transform.parent = null;
    //     }
    // }
}
