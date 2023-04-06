using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [HideInInspector] public bool isGameOver;
   [SerializeField] private GameObject _boardScore;
   [SerializeField] private GameObject _startButton;
   [SerializeField] private GameObject _spawner;
   [SerializeField] private SpikeSpawner _spikeSpawner;

   [SerializeField] private GameObject _openBoardStats;
   [SerializeField] private GameObject _statsButton;
   
   [SerializeField] private GameObject _openUserDataBoard;
   [SerializeField] private GameObject _userDataButton;
   
   [SerializeField] private GameObject _openSignUpBoard;
   [SerializeField] private GameObject _signUpButton;

   public Animator _animatorHit;

    private void Start()
    {        
        _statsButton.SetActive(true);
        _openSignUpBoard.SetActive(false);
        _openBoardStats.SetActive(false);
        _openUserDataBoard.SetActive(false);
        _userDataButton.SetActive(true);
        _animatorHit.GetComponent<Animator>();
        _spawner.SetActive(false);
        Time.timeScale = 0;
        _boardScore.SetActive(false);
        _startButton.SetActive(true);
        Debug.Log("startGame");
    }

    public void GameOver()
    {
        _boardScore.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    } 

    public void StartGame()
    {  
        _statsButton.SetActive(false);
        _animatorHit.SetBool("IsDinoRun", true);
        _spikeSpawner.isTest = true; 
        _spawner.SetActive(true);     
        isGameOver = false;        
        Time.timeScale = 1;
        _startButton.SetActive(false);  
    }

    public void OpenStatsBoard()
    {
        _openBoardStats.SetActive(true);
        _statsButton.SetActive(false);
        _userDataButton.SetActive(true);
        _openUserDataBoard.SetActive(false);
        _openSignUpBoard.SetActive(false);
    }

    public void CloseStatsBoard()
    {
        _openBoardStats.SetActive(false);
        _statsButton.SetActive(true);
    }

    public void OpenUserDataBoard()
    {
        _statsButton.SetActive(true);
        _openBoardStats.SetActive(false);
        _userDataButton.SetActive(false);
        _openUserDataBoard.SetActive(true);
    }

    public void CloseUserDataBoard()
    {
        _userDataButton.SetActive(true);
        _openSignUpBoard.SetActive(false);
        _openUserDataBoard.SetActive(false);
        _statsButton.SetActive(true);
    }

    public void OpenSignUpBoard()
    {
        _openSignUpBoard.SetActive(true);
        _openUserDataBoard.SetActive(false);
    }

    public void OpenSignInBoard()
    {
        _openSignUpBoard.SetActive(false);
        _openUserDataBoard.SetActive(true);
    }
}