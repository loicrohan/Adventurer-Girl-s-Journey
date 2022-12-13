using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text currentScore;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        currentScore.text = "Score : " + ScoreNum;
    }

    /*public void UpdateScore(float score)
    {
        currentScore.text = "Score : " + score.ToString();
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            ScoreNum += 10;
            Destroy(other.gameObject);
            currentScore.text = "Score : " + ScoreNum;
        }
    }
}