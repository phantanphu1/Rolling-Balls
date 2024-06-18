using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class ResetPassword : MonoBehaviour
{
    public InputField emailInput;

    public void SendResetEmail()
    {
        string email = emailInput.text;

        var request = new SendAccountRecoveryEmailRequest()
        {
            Email = email,
            // Optional: Custom email template ID (refer to PlayFab docs)
            // EmailTemplateId = "yourTemplateId"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnEmailSent, OnError);
    }

    private void OnEmailSent(SendAccountRecoveryEmailResult result)
    {
        Debug.Log("Password reset email sent successfully!");
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError("Failed to send password reset email: " + error.ErrorMessage);
    }
}
