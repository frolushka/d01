using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerAssociatedPosition
    {
        public Player player;
        public Transform target;
    }

    [SerializeField] private float playerPositionThreshold = 0.2f;
    [SerializeField] private string nextLevelName;
    [SerializeField] private PlayerAssociatedPosition[] playerTargetPositions;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        CheckWin();   
    }

    private void CheckWin()
    {
        for (var i = 0; i < playerTargetPositions.Length; i++)
        {
            if (Vector3.Distance(playerTargetPositions[i].player.transform.position, playerTargetPositions[i].target.position) > playerPositionThreshold)
                return;
        }

        SceneManager.LoadScene(nextLevelName);
    }

    public void GameOver()
    {
        
    }
}
