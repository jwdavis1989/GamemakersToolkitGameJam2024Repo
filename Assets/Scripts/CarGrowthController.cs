using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGrowthController : MonoBehaviour
{
    [Header("Sizes")]
    public float[] sizeArray = { 0.5f, 1f, 2f };

    [Header("Unity Set-up")]
    //Time, in seconds, for size changes to take place
    public float sizeChangeTimeInSeconds = 0.5f;
    private int currentScaleIndex = 1;
    Rigidbody carRigidBody;
    public float jumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        InitializeScale();
        carRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        //Shrink
        if (Input.GetKeyDown("q") && currentScaleIndex > 0)
        {
            currentScaleIndex--;
            Bounce();
            UpdateScale(sizeArray[currentScaleIndex]);
        }

        //Grow
        if (Input.GetKeyDown("e") && currentScaleIndex < 2)
        {
            currentScaleIndex++;
            Bounce();
            UpdateScale(sizeArray[currentScaleIndex]);
        }

    }

    void InitializeScale()
    {
        transform.localScale = new Vector3(sizeArray[currentScaleIndex], sizeArray[currentScaleIndex], sizeArray[currentScaleIndex]);
    }

    void UpdateScale(float size)
    {
        transform.localScale = new Vector3(size, size, size);
    }

    void UpdateScaleOverTime(float size)
    {
        Vector3 newScale = new Vector3(size, size, size);

    }

    void Bounce() {
        carRigidBody.AddForce(transform.up * jumpForce * 1000 * (sizeArray[0]/sizeArray[2]), ForceMode.Impulse);
        carRigidBody.mass = sizeArray[currentScaleIndex] * 950;
        //Vector3 newVector3 = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        //carRigidBody.MovePosition(newVector3);
    }
}
