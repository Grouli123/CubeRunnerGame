using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject _gameOverCanvas;
   [SerializeField] private GameObject _boardScore;
   public bool isGameOver;

    private void Start()
    {
        isGameOver = false;
        _gameOverCanvas.SetActive(false);
        _boardScore.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        _boardScore.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    } 
}