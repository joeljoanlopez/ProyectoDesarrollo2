using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    private GameObject _player;
    private HidingController _hidingController;

    private void Start() {
        _player = GameObject.FindWithTag("Player");
        _hidingController = _player.GetComponent<HidingController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == _player.tag) {
            _hidingController._canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == _player.tag) {
            _hidingController._canHide = false;
        }
    }
}