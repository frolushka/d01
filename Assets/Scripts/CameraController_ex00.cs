using UnityEngine;

public class CameraController_ex00 : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    public bool IsFollowingPlayer { get; set; } = true;
    
    private void LateUpdate()
    {
        if (!IsFollowingPlayer)
            return;
        
        transform.position = playerScript_ex00.ActivePlayer.transform.position + offset;
    }
}