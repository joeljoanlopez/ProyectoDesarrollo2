using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public int _maxQuant = 4;
    public int _minQuant = 1;

    private int _quant;
    public int Quantity { get { return _quant; } }

    public void Start (){
        Random.InitState(System.DateTime.Now.Millisecond);
        _quant = Random.Range(_minQuant, _maxQuant);
    }
}
