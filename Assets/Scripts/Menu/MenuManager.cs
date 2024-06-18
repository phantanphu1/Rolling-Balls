using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public Text idText;

    public GameObject _objMenu;
    public GameObject _objSetting;
    // public Login loginScript;

    public void ButtonPlayGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void ButtonExit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
    public void ButtonSetting()
    {
        _objMenu.SetActive(false);
        _objSetting.SetActive(true);

    }
    public void ButtonBack()
    {
        _objMenu.SetActive(true);
        _objSetting.SetActive(false);
    }
}
