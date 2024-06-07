using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private float _moveInput = 0f;
    private float _speed = 10f;
    private bool _isStart = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _rigidbody.gravityScale = 0f;
        _rigidbody.velocity = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isStart == false)
        {
            _isStart = true;
            UIManager.Instance.StartText(false);
            _rigidbody.gravityScale = 5f;
        }

        if(_isStart)
        {
            _moveInput = Input.GetAxis("Horizontal");

            if(_moveInput < 0f)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_moveInput > 0f)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(_isStart)
        {
            _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Collider2D>().name == "DeathZone")
        {
            SceneManager.LoadScene(0);
        }
    }
}
