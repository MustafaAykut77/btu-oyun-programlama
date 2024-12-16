using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{
    GameManager_sc gameManager_sc;

    [SerializeField]
    TextMeshProUGUI scoreTMP;

    [SerializeField]
    TextMeshProUGUI gameOverTMP;

    [SerializeField]
    TextMeshProUGUI restartTMP;

    [SerializeField]
    Image livesImg;

    [SerializeField]
    Sprite[] livesSprites;

    // Start is called before the first frame update
    void Start()
    {
        gameManager_sc = GameObject.Find("Game_Manager").GetComponent<GameManager_sc>();
        if(gameManager_sc == null){
            Debug.LogError("gameManager_sc bulunamadı");
        }
        scoreTMP.text = "Score: " + 0;
        livesImg.sprite = livesSprites[3];
        gameOverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }

    public void UpdateScoreTMP(int score){
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLivesImg(int lives){
        livesImg.sprite = livesSprites[lives];

        if(lives == 0){
            GameOverSequence();
        }
    }

    void GameOverSequence(){
            if(gameManager_sc != null){
                gameManager_sc.gameOver();
            }
            gameOverTMP.gameObject.SetActive(true);
            restartTMP.gameObject.SetActive(true);
            StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine(){
        while(true){
            gameOverTMP.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverTMP.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
