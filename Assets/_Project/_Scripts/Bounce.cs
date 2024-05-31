using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private int _score = 0;
    private bool _isScore = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _power);

            if(_isScore)
            {
                UIManager.Instance.SetScore(_score);
                _isScore = false;
            }
        }
    }
}
