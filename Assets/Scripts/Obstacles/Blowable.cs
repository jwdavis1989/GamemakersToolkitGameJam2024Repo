using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowable : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (inWindZone)
        {
            WindBlowArea wind = windZone.GetComponent<WindBlowArea>();
            CarGrowthController car = gameObject.GetComponent<CarGrowthController>();//.currentScaleIndex
            if (car && car.currentScaleIndex == 0)
            {
                rb.AddForce(wind.direction * wind.strength);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("windArea"))
        {
            windZone = other.gameObject;
            inWindZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("windArea"))
        {
            inWindZone = false;
        }
    }
}
