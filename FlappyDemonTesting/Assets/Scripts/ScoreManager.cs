using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public float speed;
    public float jump;
    public Text scoreText;
    private int overallScore;

    void Start(){
        overallScore = PlayerPrefs.GetInt("PlayerScore");
        Debug.Log(overallScore);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            score++;
            overallScore++;
            transform.position = new Vector2(transform.position.x + jump, transform.position.y);
        }
    }

    private void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("PlayerScore", overallScore);
        PlayerPrefs.SetInt("LastScore", score);//
    }
}
