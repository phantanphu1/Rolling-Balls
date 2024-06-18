using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plays : MonoBehaviour
{
    public FinishPoint gameManager;
    public float Movespeed = 7f;
    Rigidbody2D rb;
    private SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sceneController = new SceneController();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply movement force based on mouse position
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * Movespeed);
            }
            else
            {
                rb.AddForce(Vector2.right * Movespeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.tag == "finish")
    //     {
    //         // SceneController.instance.NextLevel();
    //         Debug.Log("vào");
    //         gameManager.UnlockPointLevel();
    //         SceneController.instance.NextLevel();
    //     }
    // }

}