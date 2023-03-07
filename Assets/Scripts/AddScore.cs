using UnityEngine;
using Scriptable;

public class AddScore : MonoBehaviour
{
    [SerializeField] private IntegerVariable _scoreCounter;

    [SerializeField] private float _time;

    // private void Start() 
    // {
    //     _time = 0f;
    // }

    // private void Update() 
    // {
    //     _time += Time.deltaTime;    
    // }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     _scoreCounter.ApplyChange(_time);
    // }
}