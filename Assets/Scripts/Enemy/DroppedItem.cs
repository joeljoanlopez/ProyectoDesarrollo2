using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public GameObject _player;
    public int _maxQuant = 4;
    public int _minQuant = 1;

    private int _quant;
    public int Quantity { get { return _quant; } }

    public void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        _quant = Random.Range(_minQuant, _maxQuant);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _player.tag)
            Destroy(gameObject);
    }
}
