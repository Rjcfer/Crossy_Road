using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private AudioSource jumpSound;
    private bool isHopping = false;
    private int score = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public int getScore()
    {
        return score;
    }
    private void Update()
    {

        if (transform.position.y < -1)
        {
            gameOverManager.Setup(this);
            return;
        }

        scoreText.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isHopping)
        {
            score++;
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;

            }
            MovePlayer(new Vector3(1, 0, zDifference));

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isHopping)
        {

            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;

            }
            MovePlayer(new Vector3(xDifference, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isHopping)
        {

            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;

            }
            MovePlayer(new Vector3(xDifference, 0, -1));

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isHopping)
        {
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;

            }
            MovePlayer(new Vector3(-1, 0, zDifference));
        }

    }

    private void MovePlayer(Vector3 difference)
    {
        jumpSound.Play();
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<ObjectMovement>() != null)
        {
            if (collision.collider.GetComponent<ObjectMovement>().isLog)
            {
                transform.parent = collision.collider.transform;
            }

        }
        else
        {
            transform.parent = null;
        }
    }
    public void FinishHop()
    {
        isHopping = false;
    }

}
