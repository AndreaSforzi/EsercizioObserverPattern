using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EXP : MonoBehaviour
{
    [SerializeField] int EXPValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player.Instance.EXP += EXPValue;
            Destroy(gameObject);
        }
    }
}
