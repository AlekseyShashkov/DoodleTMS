using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _moveInput = 0f;
    private float _speed = 10f;
    private bool _isStarted = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.gravityScale = 0f;
        _rigidbody.velocity = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isStarted == false)
        {
            _isStarted = true;
            UIManager.Instance.StartText(false);
            _rigidbody.gravityScale = 5f;
        }

        if(_isStarted)
        {
            _moveInput = Input.GetAxis("Horizontal");

            if(_moveInput < 0f)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(_isStarted)
        {
            _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);
        }
    }
}
