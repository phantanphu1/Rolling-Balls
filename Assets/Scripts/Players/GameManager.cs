using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    bool gameStarted = false;
    public TextMeshProUGUI scoreText;
    private List<GameObject> lsPoolBlocks = new List<GameObject>();
    private List<GameObject> lsPoolBullets = new List<GameObject>();
    public AudioManager audioManager;
    // private int score = 0;
    public int score = 0;

    Dictionary<string, List<GameObject>> dicPoool = new Dictionary<string, List<GameObject>>();

    // Update is called once per frame
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    protected void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
        }
    }
    private void StartSpawning()
    {
        InvokeRepeating("GetPoolBlock", 0.5f, spawnRate);
    }
    private GameObject SpawnBlock()
    {

        var blockClone = Instantiate(block, SetSpawPosition(), Quaternion.identity);

        blockClone.transform.Rotate(0f, 0f, 180f, Space.Self);
        lsPoolBlocks.Add(blockClone);
        return blockClone;
    }
    private Vector3 SetSpawPosition()
    {
        Vector3 spawnPost = spawnPoint.position;
        spawnPost.x = Random.Range(-maxX, maxX);
        return spawnPost;
    }
    private void AddSCore()
    {
        score++;
        scoreText.text = score.ToString();
        audioManager.PlaySFX(audioManager.scorClip);
    }
    public void ResetGamePlay()
    {
        Debug.Log("Resetting Gameplay...");
        ResetScore();
        // Deactivate all active blocks
        foreach (GameObject block in lsPoolBlocks)
        {
            block.SetActive(false);
        }
        lsPoolBlocks.Clear();

        // Stop spawning new blocks
        // CancelInvoke("GetPoolBlock");
    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    private GameObject GetPoolBlock()
    {
        AddSCore();
        //         if(dicPoool.ContainsKey("block")){
        //             var lsblock = dicPoool["block"];
        //             lsblock.Add(new GameObject());
        // dicPoool["block" ] = lsblock;
        //         }else{

        //             dicPoool.Add("bullet",new List<GameObject>());
        //         }
        //         var lspoll = dicPoool[""]
        for (int i = 0; i < lsPoolBlocks.Count; i++)
        {
            if (!lsPoolBlocks[i].activeInHierarchy)
            {
                lsPoolBlocks[i].transform.position = SetSpawPosition();
                lsPoolBlocks[i].SetActive(true);
                return lsPoolBlocks[i];
            }
        }
        return SpawnBlock();

    }
}
