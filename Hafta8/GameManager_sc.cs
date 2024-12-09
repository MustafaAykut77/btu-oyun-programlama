using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_sc : MonoBehaviour
{
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }
    void Update()
    {
        if(isGameOver == true && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(1);
        }
    }

    public void gameOver(){
        isGameOver = true;
    }
}
