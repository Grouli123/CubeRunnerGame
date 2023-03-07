using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scriptable;

public class Score : MonoBehaviour
{
    // [SerializeField] private IntegerVariable _scoreCounter;
    private TextMeshProUGUI _score;
    [SerializeField] private float _time;


    private void Start() 
    {
        _score = GetComponent<TextMeshProUGUI>();
        // _scoreCounter.Listeners += UpdateTextField;         
        // UpdateTextField(_scoreCounter.GetValue());
    }

    private void Update() 
    {
        _time += Time.deltaTime;
        _score.text = _time.ToString();
        _score.text = Mathf.Round(_time).ToString();
    }

    // private void OnDestroy()
    // {
    //     _scoreCounter.Listeners -= UpdateTextField;
    // }

    //  private void UpdateTextField(int value)
    // {
    //     _score.text = value.ToString();
    // }
}