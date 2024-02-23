using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    [SerializeField] private Text restartText;
    [SerializeField] private Text pointsText;
    private bool isGameOver = false;

    public void Setup(Player player)
    {
        int scoreTemp = player.getScore();
        for (var i = player.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(player.transform.GetChild(i).gameObject);
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
        }


    }
}