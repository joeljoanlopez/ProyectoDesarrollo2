using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _itemDrop;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetDrop()
    {
        return _itemDrop;
    }
    public void DropSomething(GameObject drop)
    {
        if (drop != null)
        {
            var _item = Instantiate(drop, transform.position, transform.rotation);
        }
    }
}
