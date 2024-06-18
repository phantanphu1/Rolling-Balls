using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    [SerializeField] Animator transitionAnim;

    public void NextLevel()
    {
        Debug.Log("vào");
        StartCoroutine(LoadLevel());

    }
    IEnumerator LoadLevel()
    {
        Debug.Log("Load scene");
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");

    }
}
