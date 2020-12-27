using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
        }
    }
}
