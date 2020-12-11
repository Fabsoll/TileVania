using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int deathDelay = 2;
    [SerializeField] int scoreStat = 10;
    [SerializeField] Text score;
    [SerializeField] Text lives;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        lives.text = playerLives.ToString();
        score.text = scoreStat.ToString();
    }

    public void ProcessPlayedDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    private void TakeLife()
    {
        StartCoroutine(DeathDelay());

    }
    public void AddToScore(int pointsToAdd)
    {
        scoreStat += pointsToAdd;
        score.text = scoreStat.ToString();
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        playerLives--;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        lives.text = playerLives.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
