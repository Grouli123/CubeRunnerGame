using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scriptable;

public class Score : MonoBehaviour
{
    [SerializeField] private IntegerVariable _scoreCounter;
    private TextMeshProUGUI _score;
    [SerializeField] private float _time;
    private int _scoreInt;

    public float _scorePlus; // добавить проверку, если меньше 0, то не работает
    public float _scoreStepIncrease;
    public float _maxScoreIncrease;

    private void Start() 
    {
        _score = GetComponent<TextMeshProUGUI>();
        _scoreCounter.Listeners += UpdateTextField;         
        UpdateTextField(_scoreCounter.GetValue());
        StartCoroutine(ScoreIncrease());
    }

    private void Update() 
    {
        _time += Time.deltaTime * _scorePlus;
        _score.text = _time.ToString();
        _scoreInt = ((int)_time);
        _score.text = Mathf.Round(_time).ToString();               
        _scoreCounter.SetValue(_scoreInt);
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