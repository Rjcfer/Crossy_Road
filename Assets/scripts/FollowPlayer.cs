using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;
    [SerializeField] private GameOverManager gameOverManager;

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothness);
        }
        else
        {
            gameOverManager.Setup(player);
        }

    }
}
