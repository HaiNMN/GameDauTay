using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver ;
    public static GameManager instance;
    private int score = 0;
    private bool isGameOver = false;
    public GameObject GameOverScreen ; // thua hay chua
    public GameObject ScoreObject;// diem so

    public int bestScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            PlayerDead();
        }
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        /*if (score >= 200)
        {
            changeScene("Boss");
        }*/
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }
    public int GetScore()
    {
        return score;
    }

    public void EnemySkillPlayer()
    {
        isGameOver = true; 
    }

    public void PlayerDead()
    {
        GameOverScreen.SetActive(true);
        ScoreObject.SetActive(false);
        
    }

    public bool GameOver()
    {
        return isGameOver;
    }
    public int GetBestScore()
    {
        return bestScore;
    }
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
