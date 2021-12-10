using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject shopWindow;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI highScoreText;//
    public GameObject flyingEyeWindow;
    private int playerScore;
    private int lastRunScore;//

    void Start(){
        playerScore = PlayerPrefs.GetInt("PlayerScore");
        pointText.text = "Points: " + playerScore.ToString();
        lastRunScore = PlayerPrefs.GetInt("LastScore", 0);//
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        if (lastRunScore > PlayerPrefs.GetInt("HighScore", 0))//start
        {
            PlayerPrefs.SetInt("HighScore", lastRunScore);
            highScoreText.text = lastRunScore.ToString();
        }//end
        Debug.Log(playerScore);
    }

    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }
    public void OpenShop(){
        gameObject.SetActive(false);
        shopWindow.SetActive(true);
    }
    public void GoBack(){
        gameObject.SetActive(true);
        shopWindow.SetActive(false);
    }
    public void Reset(){
        PlayerPrefs.SetInt("PlayerScore", 10);
        PlayerPrefs.SetString("PlayerIcon", "");
        PlayerPrefs.SetInt("HighScore", 0);//
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        Debug.Log("Reset");
    }

    public void buyFlyingEye(){
        if(playerScore >= 10){
            playerScore -= 10;
            PlayerPrefs.SetInt("PlayerScore", playerScore);
            pointText.text = "Points: " + playerScore.ToString();
            flyingEyeWindow.SetActive(false);
            PlayerPrefs.SetString("PlayerIcon", "FlyingEye");
            Debug.Log("Bought");
        }
    }
}
