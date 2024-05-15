using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public PlayerTeleportController _targetDoor;

    public void Unlock()
    {
        _targetDoor._isClosed = false;
    }
}