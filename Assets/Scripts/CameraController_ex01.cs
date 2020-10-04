using UnityEngine;

public class CameraController_ex01 : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    public bool IsFollowingPlayer { get; set; } = true;
    
    private void LateUpdate()
    {
        if (!IsFollowingPlayer)
            return;
        
        transform.position = playerScript_ex01.ActivePlayer.transform.position + offset;
    }
}