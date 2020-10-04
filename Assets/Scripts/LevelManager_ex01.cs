using UnityEngine;

public class LevelManager_ex01 : MonoBehaviour
{
    [System.Serializable]
    public class PlayerAssociatedPosition
    {
        public playerScript_ex01 player;
        public Transform target;
    }

    [SerializeField] private float playerPositionThreshold = 0.2f;
    [SerializeField] private PlayerAssociatedPosition[] playerTargetPositions;

    private bool _isActive = true;
    
    private void Update()
    {
        if (_isActive)
        {
            CheckWin();
        }   
    }

    private void CheckWin()
    {
        for (var i = 0; i < playerTargetPositions.Length; i++)
        {
            if (Vector3.Distance(playerTargetPositions[i].player.transform.position, playerTargetPositions[i].target.position) > playerPositionThreshold)
                return;
        }

        Debug.Log("Win!");
        _isActive = false;
    }
}