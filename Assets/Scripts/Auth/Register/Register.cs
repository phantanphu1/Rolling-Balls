using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
public class Register : MonoBehaviour
{

    // Username : Phantanphu email: phantanphu1505@gmail.com pas: Tanphu15052001@
    // phantanphu@gmail.com


    public InputField usernameInput;
    public InputField emailInput;
    public InputField passwordInput;
    public AuthManager authManager;

    // Start is called before the first frame update
    public void CreateAccount()
    {
        var request = new RegisterPlayFabUserRequest()
        {
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucces, OnError);
    }
    private void OnError(PlayFabError error)
    {
        Debug.LogError("Failed to register in with PlayFab: " + error.ErrorMessage);
    }

    private void OnRegisterSucces(RegisterPlayFabUserResult result)
    {
        authManager.OpenPageLogin();

    }
}
