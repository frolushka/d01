using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerAssociatedKey
    {
        public KeyCode key;
        public Player player;
    }

    [SerializeField] private int defaultPlayerIndex;
    [SerializeField] private PlayerAssociatedKey[] players;
    
    public Player ActivePlayer { get; private set; }

    private void Start()
    {
        ActivePlayer = players[defaultPlayerIndex].player;
    }

    private void Update()
    {
        for (var i = 0; i < players.Length; i++)
        {
            if (Input.GetKeyDown(players[i].key))
            {
                ActivePlayer = players[i].player;
            }
        }

        var moveDirection = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1;
        }

        if (!Mathf.Approximately(moveDirection, 0))
        {
            ActivePlayer.Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivePlayer.Jump();
        }
    }
}
