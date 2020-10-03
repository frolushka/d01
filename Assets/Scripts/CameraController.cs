using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private PlayerManager playerManager;

    public bool IsFollowingPlayer { get; set; } = true;
    
    private void LateUpdate()
    {
        if (!IsFollowingPlayer)
            return;
        
        transform.position = playerManager.ActivePlayer.transform.position + offset;
    }
}
