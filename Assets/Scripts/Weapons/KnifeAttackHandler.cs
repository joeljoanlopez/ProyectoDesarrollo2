using System.Collections;
using UnityEngine;

public class KnifeAttackHandler : MonoBehaviour
{
    public void Attack()
    {
        StartCoroutine(Slice());
    }

    private IEnumerator Slice()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}