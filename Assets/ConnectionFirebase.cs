using UnityEngine;
using Firebase.Auth;
using Firebase;
using Firebase.Database;

public class ConnectionFirebase : MonoBehaviour
{
    public static FirebaseAuth authorizationPlayer;
    public static DatabaseReference reference;
    public static FirebaseUser User;
    [SerializeField] private ErrorManager _errorManager;

    private void Awake() 
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            DependencyStatus dependencyStatus = task.Result;
            if(dependencyStatus == DependencyStatus.Available)
            {
                authorizationPlayer = FirebaseAuth.DefaultInstance;
            }
            else
            {
                _errorManager.UpdateTextError("Не удалось разрешить все зависимости Firebase: " + dependencyStatus);
            }
        });    
    }
}
