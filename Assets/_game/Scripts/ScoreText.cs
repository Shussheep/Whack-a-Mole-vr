using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    private TextMeshPro text;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void increaseScore(int Score) 
    {
        score += Score;
        text.text = "Score: " + score;
    }
}
