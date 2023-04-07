using TMPro;
using Firebase.Auth;
using Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationFirebase : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFieldName, _inputFieldEmail, _inputFieldPassword;
    [SerializeField] private ErrorManager _errorManager;
    // [SerializeField] private UIManager _uIManager;

    private void Start() 
    {
        // _inputFieldName = GetComponent<TextMeshProUGUI>();  
        // _inputFieldEmail = GetComponent<TextMeshProUGUI>(); 
        // _inputFieldPassord = GetComponent<TextMeshProUGUI>(); 
    }

    public void RegisterButton()
    {
        StartCoroutine(RegisterPlayer(_inputFieldName.text, _inputFieldEmail.text, _inputFieldPassword.text));
    }

    private IEnumerator RegisterPlayer(string name, string email, string password)
    {
        var registerTask = ConnectionFirebase.authorizationPlayer.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

        if(registerTask.Exception != null)
        {
            _errorManager.WhatErrorOut(registerTask.Exception.GetBaseException() as FirebaseException);
        }
        else
        {
            ConnectionFirebase.User = registerTask.Result;

            if (ConnectionFirebase.User != null)
            {
                UserProfile profile = new UserProfile { DisplayName = name};

                var profileTask = ConnectionFirebase.User.UpdateUserProfileAsync(profile);
                yield return new WaitUntil(predicate: () => profileTask.IsCompleted);

                if (profileTask.Exception != null)
                {
                    _errorManager.UpdateTextError("Ошибка создания профиля!");
                }
                else
                {
                    PlayerPrefs.SetString("email", email);
                    PlayerPrefs.SetString("password", password);
                    // _uIManager.ChangeWindows((int)WindowsApp.Menu);
                    _errorManager.UpdateTextError("");
                    
                    Debug.Log("Вы зарегистрировались: " + email);
                }
            }
        }
    }
}