using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcyTraction : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("iceArea"))
        {
            player.GetComponent<PrometeoCarController>().isOnIce = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("iceArea"))
        {
            player.GetComponent<PrometeoCarController>().isOnIce = false;
        }
    }
}
