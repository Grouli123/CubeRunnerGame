using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scriptable;

public class Score : MonoBehaviour
{
    [SerializeField] private IntegerVariable _scoreCounter;
    [SerializeField] private GameManager _gameManager;
    private TextMeshProUGUI _score;
    [SerializeField] private float _time;
    public int scoreInt;

    public float _scorePlus; // добавить проверку, если меньше 0, то не работает
    public float _scoreStepIncrease;
    public float _maxScoreIncrease;


    private void Start() 
    {
        _score = GetComponent<TextMeshProUGUI>();
        _time = 0;
        _scoreCounter.Listeners += UpdateTextField; 
        UpdateTextField(_scoreCounter.GetValue());        
        StartCoroutine(ScoreIncrease());
    }

    private void Update() 
    {
        if(_gameManager.isGameOver == false)
        { 
            _time += Time.deltaTime * _scorePlus;
            _score.text = _time.ToString();
            scoreInt = ((int)_time);
            _score.text = Mathf.Round(_time).ToString();      
            _scoreCounter.SetValue(scoreInt);            
        }
    }

    private void OnDestroy()
    {
        _scoreCounter.Listeners -= UpdateTextField;
    }

     private void UpdateTextField(int value)
    {
        _score.text = value.ToString();
    }

    private IEnumerator ScoreIncrease()
    {
        yield return new WaitForSeconds(4);

        if(_scorePlus < _maxScoreIncrease)
        {
            _scorePlus += _scoreStepIncrease;        
            Debug.Log(_time);
            StartCoroutine(ScoreIncrease());
        }
    }
}