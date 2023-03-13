using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _gravityScale = 1f;
    private SpriteRenderer _playerImage;
    private Rigidbody2D _rb;
    private bool _isGroundBot;
    private bool _isGround;

    private void Start()
    {
        _isGroundBot = true;
        _rb = GetComponent<Rigidbody2D>();
        _playerImage = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {  
        if(_gameManager.isGameOver == false)
        {      
            if (_isGround == true)
            {
                if (Input.GetMouseButtonDown(0) && _isGroundBot == true)
                {
                    _rb.gravityScale = -_gravityScale;
                    _playerImage.flipY = true;
                    _isGroundBot = false;
                }
                else if (Input.GetMouseButtonDown(0) && _isGroundBot == false)
                {
                    _rb.gravityScale = _gravityScale;
                    _playerImage.flipY = false;
                    _isGroundBot = true;
                }
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Spike") 
        {
            Debug.Log("Game Over");
            _gameManager.GameOver();
            _gameManager.isGameOver = true;
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
    }
}
