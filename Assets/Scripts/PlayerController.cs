using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _gravityScale = 1f;
    private Rigidbody2D _rb;
    private bool _isGroundBot;

    private void Start()
    {
        _isGroundBot = true;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {        
        if(Input.GetMouseButtonDown(0) && _isGroundBot == true)
        {
            // _rbv_grabityScale = Vector2.up *_gravityScale;
            _rb.gravityScale = -_gravityScale;
            _isGroundBot = false;
        }
        else if(Input.GetMouseButtonDown(0) && _isGroundBot == false)
        {
            _rb.gravityScale =_gravityScale;
            _isGroundBot = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Spike") 
        {
            Debug.Log("Game Over");
            _gameManager.GameOver();
        }  
    }
}
