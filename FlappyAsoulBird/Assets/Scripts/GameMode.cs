using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static GameMode instance;

    [Header("MusicPlayer")]
    public GameObject audioBox;
    public static bool isHave = false;//Judge Reloading Music
    private GameObject cloneAudioBox;

    [Header("UI")]
    public GameObject gameOverUI;
    public GameObject GameStartUI;
    public bool gameOver = false;
    public bool gameStart = false;

    [Header("Speed")]
    public float scrollSpeed = -1.5f;

    [Header("Score")]
    public Text scoreText;
    float score = 0;

    [Header("PlayerScale")]
    public float scale = 1;
    
    void Awake()
    {
        instance = this;
        Time.timeScale = 0;
        
        if (!isHave)
        {
            cloneAudioBox = GameObject.Instantiate(audioBox, transform.position, transform.rotation);
            isHave = true;
            DontDestroyOnLoad(cloneAudioBox);
        }
        
    }
    
    void Update()
    {
        if (!gameStart && Input.GetMouseButtonDown(0))
        {
            GameStart();
        }

        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ScoreUp()
    {
        if (gameOver) return;

        score = score + scale;
        
        scoreText.text = "SCORE:" + score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void GameStart()
    {
        GameStartUI.SetActive(false);
        Time.timeScale = 1;
        AudioManager.PlayRandomAudio(new string[] { AudioName.GameStart1, AudioName.GameStart2,
            AudioName.GameStart3, AudioName.GameStart4, AudioName.GameStart5 });
        gameStart = true;
    }

    public void ChangeScale(float sc)
    {
        scale = scale * sc;
    }
}
