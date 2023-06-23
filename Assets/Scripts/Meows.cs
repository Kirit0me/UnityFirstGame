using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meows : MonoBehaviour
{
    public static Meows instance;

    public int score = 0;
    public int highscore = 0;

    public Text score_board;
    public Text highscore_board;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score_board.text = score.ToString() + " MEOWS";
        highscore_board.text = "Most MEOWS : " + highscore.ToString();
        
    }

    public void AddMeow()
    {
        score++;
        score_board.text = score.ToString() + " MEOWS";
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highschore", score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
