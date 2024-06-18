using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{

    public GameObject _objPanlPageLogin;
    public GameObject _objPanlPageRegister;
    public GameObject _objPanlResetPass;


    public void OpenPageLogin()
    {
        _objPanlPageLogin.SetActive(true);
        _objPanlPageRegister.SetActive(false);
        _objPanlResetPass.SetActive(false);
    }
    public void OpenPageRegister()
    {
        _objPanlPageLogin.SetActive(false);
        _objPanlPageRegister.SetActive(true);
        _objPanlResetPass.SetActive(false);

    }
    public void OpenPageResetPass()
    {
        _objPanlPageLogin.SetActive(false);
        _objPanlPageRegister.SetActive(false);
        _objPanlResetPass.SetActive(true);

    }

}
