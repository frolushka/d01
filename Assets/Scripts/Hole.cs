using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<CameraController>().IsFollowingPlayer = false;
            FindObjectOfType<LevelManager>().GameOver();
        }
    }
}
