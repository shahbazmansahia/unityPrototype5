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
    public TextMeshProUGUI titleText;
    public Button restartButton;
    public Button startButton;
    public Button exitButton;
    public Button[] difficultyButtons;
    public Button BackButt;
    public GameObject titleScreen;

    private int score;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
        
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

    /** Spawns the game over screen elements and gives us the option to restart the game
     * 
     */
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    /** This method resets and reloads the scene from the beginning; FIX ME: This is for some reason turning off the lights in the scene? or dimming the brightness?
     * 
     */
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /** This function starts the game; activates after the choose difficulty screen
     * param: difficulty - a difficulty tweaker that changes the spawnRate of objects in the game; we get this value from the difficulty buttons
     */
    
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        
    }

    /** Exits the game; Meant to be used at the title and game over screens
     * 
     */
    public void ExitGame()
    {
        //ExitGame();
    }

    /** This method takes us to the choose difficulty screen
     * 
     */
    public void ChooseDifficulty()
    {
        startButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        for (int i = 0; i < difficultyButtons.Length; i++)
        {
            difficultyButtons[i].gameObject.SetActive(true);
        }

        BackButt.gameObject.SetActive(true);
    }

    /** This method makes us go back to the title screen at the start.
     * 
     */
    public void Back2Title()
    {
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        for (int i = 0; i < difficultyButtons.Length; i++)
        {
            difficultyButtons[i].gameObject.SetActive(false);
        }

        BackButt.gameObject.SetActive(false);
    }
}
