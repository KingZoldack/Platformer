using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _movementSpeed, _gravity, _jumpHeight;
    
    [SerializeField]
    float _yVelocity;

    bool _hasJumped = false;

    CharacterController _controller;
    UIManager uiManager;

    [SerializeField]
    int coins, _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        uiManager.DisplayLives(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftAndRight();
    }

    void MoveLeftAndRight()
    {
        var _horizontalAxis = Input.GetAxis("Horizontal");
        var _horizontalMovement = new Vector3(_horizontalAxis, 0, 0);
        var velocity = _horizontalMovement * _movementSpeed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _hasJumped = true;
            }
        }

        else
        {
            if (_hasJumped)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _yVelocity += _jumpHeight;
                    _hasJumped = false;
                }
                
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            AddCoins();
        }
    }

    public void AddCoins()
    {
        coins++;
        uiManager.DisplayCoins(coins);
    }

    public void LoseLife()
    {
        _lives--;
        uiManager.DisplayLives(_lives);
        if (_lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
