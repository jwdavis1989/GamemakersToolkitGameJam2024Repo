using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private Transform tireTransform;
    [Header("Unity Set-up")]
    public Rigidbody carRigidBody;
    public float suspensionRestDist;
    public float springStrength;
    public float springDamper;


    // Start is called before the first frame update
    void Start()
    {
        tireTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Suspension Spring Force
        // if (rayDidHit) {

        //     //World-space direction of the spring force
        //     Vector3 springDir = tireTransform.up;

        //     //world-space velocity of this tire
        //     Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

        //     //calculate offset from the raycast
        //     float offset = suspensionRestDist - tireRay.distance;

        //     //Valculate velocity along the spring direction
        //     //note that springDir is a unit vector, so this returns the magnitude of tireWorldVel
        //     //as project onto springDir
        //     float vel = Vector3.Dot(springDir, tireWorldVel);

        //     //calculate the magnitude of the dampened spring force!
        //     float force = (offset * springStrength) - (vel * springDamper);

        //     //apply the force at the location of this tire, in the direction of the suspension
        //     carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        // }
    }
}
