using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    [SerializeField]
    CharacterController _controller;

    [SerializeField]
    float _movementSpeed = 10f, _gravity = 20f, _jumpHeight = 10f;

    float yVelocity;
    Vector3 velocity;

    bool hasJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 _horizontalMovement = new Vector3(_horizontalInput, 0f, 0f);
        velocity = _horizontalMovement * _movementSpeed;


        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = _jumpHeight;
                hasJumped = true;
            }
        }

        else
        {
            yVelocity -= _gravity;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hasJumped)
                {
                    yVelocity += _jumpHeight;
                    hasJumped = false;
                }
            }
        }

        velocity.y = yVelocity;
        _controller.Move(velocity * Time.deltaTime);

    }
}
