using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scriptable;

public class ScoreBoard : MonoBehaviour
{
   [SerializeField] private IntegerVariable _mainScore;
   [SerializeField] private GameManager _gameManager;

   private TextMeshProUGUI _scoreText;

   private void Start() 
   {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _mainScore.Listeners += UpdateTextField;
   }

    private void UpdateTextField(int value)
    {
        _scoreText.text = value.ToString();
    }

    private void OnDestroy()
    {
        _mainScore.Listeners -= UpdateTextField;
    }
}
