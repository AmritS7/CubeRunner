using UnityEngine.UI;
using System;
using UnityEngine;

public class hScore : MonoBehaviour
{
    public Text text;
    public Transform player;
    private int highscore;
    

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        text.text = "HS:" + highscore.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        if (player.position.z > highscore)
        {
            highscore = (int) player.position.z;
            text.text = "HS:" + (int) player.position.z;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
