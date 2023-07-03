using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    /*private float Xmin = -10.15f;
    private float Xmax = 10.15f;*/
    [SerializeField]
    private float Speed = 18f;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Ground")
        {
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
        }
        else if (Other.gameObject.tag == "Player")
        {
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
        }
    }
}