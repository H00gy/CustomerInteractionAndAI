using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject gameOverObj;

    private void Awake()
    {
        gameOverObj.SetActive(false);
    }
    public void gameOverEnd()
    {
        Time.timeScale = 0;
        if (gameOverObj != null)
        {
            gameOverObj.SetActive(true);
        }
        gameOverObj.SetActive(true);
        GameObject.FindWithTag("gameManager").GetComponent<InputHandler>().enabled = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume time
        // Load the current scene again to restart the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
