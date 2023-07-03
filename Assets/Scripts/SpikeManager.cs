using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spikePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            Vector2 pos = new Vector2(Random.Range(-10.15f, 10.15f), transform.position.y);
            Instantiate(spikePrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}