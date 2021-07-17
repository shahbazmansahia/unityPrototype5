using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //UpdateScore(5);
        }
    }

    /** This method repeatedly updates the score value and views the string when it is called
     * 
     */
    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
