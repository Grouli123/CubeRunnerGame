using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scriptable;

public class BestScore : MonoBehaviour
{
    [SerializeField] private IntegerVariable _mainScore;
    [SerializeField] private IntegerVariable _scoreBoardBest;

    [SerializeField] private GameManager _gameManager;

    private TextMeshProUGUI _scoreText;

    private Score _score;

    private int _bestScore;

    private void Start() 
    {
        _bestScore = _mainScore.GetValue();
       _score = GetComponent<Score>();
       _scoreText = GetComponent<TextMeshProUGUI>();
       _scoreBoardBest.Listeners += UpdateTextField;        
       UpdateTextField(_scoreBoardBest.GetValue()); 
    }

    private void Update() 
    {
        if(_gameManager.isGameOver == true)
        {
            if(_mainScore.GetValue() > _scoreBoardBest.GetValue())
            {
                _scoreBoardBest.ApplyChange(_bestScore);
            }
        }
    }

    private void UpdateTextField(int value)
    {
        _scoreText.text = value.ToString();
    }

    private void OnDestroy()
    {
        _scoreBoardBest.Listeners -= UpdateTextField;
    }
}