using UnityEngine;

public class FirstPuzzleManager : MonoBehaviour
{
    public GameObject _doorOne;
    public GameObject _doorTwo;

    private PlayerTeleportController _doorOneTeleport;
    private bool _doorOneCanOpen;
    private PlayerTeleportController _doorTwoTeleport;
    private bool _doorTwoCanOpen;

    private void Start()
    {
        _doorOneCanOpen = false;
        _doorTwoCanOpen = false;

        _doorOneTeleport = _doorOne.GetComponent<PlayerTeleportController>();
        _doorOneTeleport.enabled = false;
        _doorTwoTeleport = _doorTwo.GetComponent<PlayerTeleportController>();
        _doorTwoTeleport.enabled = false;
    }

    private void Update() {
        
    }

    
}