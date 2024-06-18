using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Movespeed;
    public GameObject block;

    Rigidbody2D rb;
    public GameObject _objpanl;
    public GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            PlayerDie();
        }
    }
    public void PlayerDie()
    {
        int currentScore = gameManager.score;
        _objpanl.SetActive(true);
        Time.timeScale = 0;
        PlayfabManager.SendLeaderboard(currentScore);
    }
    public void PlayAgain()
    {
        _objpanl.SetActive(false);
        gameManager.ResetGamePlay();
        block.SetActive(true);
        Time.timeScale = 1;
    }
    public void BackSetting()
    {
        SceneManager.LoadScene(1);
    }
}
