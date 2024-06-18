using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioManager audioManager;
    // Update is called once per frame
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.scorClip);
            UnlockPointLevel();
            SceneController.Instance.NextLevel();
            Debug.Log("vào2");

        }
    }
    // if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
    // {
    //     PlayerPrefs.GetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
    //     PlayerPrefs.GetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
    //     PlayerPrefs.Save();
    // }
    // if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("ReachedIndex"))
    // {
    //     PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
    //     PlayerPrefs.Save();
    // }
    public void UnlockPointLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", currentSceneIndex); // Set default if not found

        // Log the scene index and reached index for reference
        Debug.Log("Current Scene Index: " + currentSceneIndex);
        Debug.Log("Reached Index: " + reachedIndex);

        if (currentSceneIndex > reachedIndex)
        {
            // Level is unlocked! Update ReachedIndex and log it
            PlayerPrefs.SetInt("ReachedIndex", currentSceneIndex + 1);
            PlayerPrefs.Save();
            Debug.Log("Level Unlocked!");

            // Update unlockedLevel for LevelMenu (optional)
            PlayerPrefs.SetInt("UnlockedLevel", currentSceneIndex + 1);
            PlayerPrefs.Save();
        }
        else
        {
            // Level is not unlocked
            Debug.Log("Level Not Unlocked Yet.");
        }
    }
}
