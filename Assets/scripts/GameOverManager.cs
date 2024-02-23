using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    [SerializeField] private Text restartText;
    [SerializeField] private Text pointsText;
    [SerializeField] private AudioSource gameOver;
    private bool isGameOver = false;
    public void Setup(Player player)
    {

        int scoreTemp = player.getScore();
        if (player != null)
        {
            Destroy(player.gameObject);
            gameOver.Play();
        }
        gameObject.SetActive(true);

        pointsText.text = "Score: " + scoreTemp.ToString();
        isGameOver = true;


    }


    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
            isGameOver = false;
        }


    }
}