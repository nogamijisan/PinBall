using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    private int score;
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.GetComponent<Text>().text = this.score.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        //private string otag = other.gameObject.tag;


        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 5;
        }
        else if(other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 15;
        }
            
    }
}
