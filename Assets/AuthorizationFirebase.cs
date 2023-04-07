using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using TMPro;
using Firebase.Database;
using Firebase.Auth;

public class AuthorizationFirebase : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldEmail, inputFieldPassword;
    [SerializeField] private ErrorManager errorManager;
    // [SerializeField] private UIManager uiManager;

        public static FirebaseAuth authorizationPlayer;
    public static DatabaseReference reference;
    public static FirebaseUser User;



    private void Start()
    {
        // inputFieldEmail = GetComponent<TextMeshProUGUI>(); 
        // inputFieldPassword = GetComponent<TextMeshProUGUI>(); 

        if(PlayerPrefs.HasKey("email") && PlayerPrefs.HasKey("password"))
        {
            inputFieldEmail.text = PlayerPrefs.GetString("email");
            inputFieldPassword.text = PlayerPrefs.GetString("password");
            Invoke("LoginButton",1f);
        }
    
    }

    public void LoginButton()
    {
        StartCoroutine(SignIn(inputFieldEmail.text, inputFieldPassword.text));
    }
   private IEnumerator SignIn(string email, string password)
    {
        var loginTask = ConnectionFirebase.authorizationPlayer.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            errorManager.WhatErrorOut(loginTask.Exception.GetBaseException() as FirebaseException);
        }
        else
        {
            PlayerPrefs.SetString("email", email);
            PlayerPrefs.SetString("password", password);
            ConnectionFirebase.User = loginTask.Result;
            // uiManager.ChangeWindows((int)WindowsApp.Menu);
            errorManager.UpdateTextError("");          
            

            Debug.Log("Вы вошли: " + ConnectionFirebase.User.UserId);
        }
    }
}
