using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not used
public class Demolisher : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _platformPower;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if(Random.Range(1f,8f) > 2f)
        {
            Instantiate(_platform, new Vector2(Random.Range(-5.5f, 5.5f), _player.transform.position.y + (15 + Random.Range(0.5f, 1f))), Quaternion.identity);
        }
        else
        {
            Instantiate(_platformPower, new Vector2(Random.Range(-5.5f, 5.5f), _player.transform.position.y + (15 + Random.Range(0.5f, 1f))), Quaternion.identity);
        }
    }
}
