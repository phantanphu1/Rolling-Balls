using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
public class Login : MonoBehaviour
{

    public InputField emailInput;
    public InputField passwordInput;
    public static string playerId;
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest()
        {
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnError);
    }

    private void OnLoginSucces(LoginResult result)
    {
        playerId = result.PlayFabId;
        SceneManager.LoadScene(1);
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError("Failed to log in with PlayFab: " + error.ErrorMessage);
    }

}
