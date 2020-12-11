using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] GameObject winParticles;
    [SerializeField] float delay ;
    [SerializeField] float slowMo = 0.2f;

    private void Start()
    {
        winParticles.GetComponent<ParticleSystem>();
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = slowMo;
        Instantiate(winParticles, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        StartCoroutine(LoadNextLevel());
    }
}
