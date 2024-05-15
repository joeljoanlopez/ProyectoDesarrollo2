using UnityEngine;

public class FirstPuzzleManager : MonoBehaviour
{
    public GameObject _doorOne;
    public GameObject _doorTwo;

    private bool _doorOneCanOpen;
    private bool _doorTwoCanOpen;

    private void Start()
    {
        _doorOneCanOpen = false;
        _doorTwoCanOpen = false;

        
    }
}