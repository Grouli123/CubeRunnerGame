using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject _boardScore;

   [SerializeField] private GameObject _startButton;

   [SerializeField] private GameObject _spawner;

   [SerializeField] private SpikeSpawner _spikeSpawner;

   [HideInInspector] public bool isGameOver;
   public Animator _animatorHit;

    private void Start()
    {        
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
        _animatorHit.SetBool("IsDinoRun", true);
        _spikeSpawner.isTest = true; 
        _spawner.SetActive(true);     
        isGameOver = false;        
        Time.timeScale = 1;
        _startButton.SetActive(false);  
    }
}