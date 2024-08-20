using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGrowthController : MonoBehaviour
{
    [Header("Sizes")]
    public float[] sizeArray = { 0.5f, 1f, 2f };

    [Header("Unity Set-up")]
    //Time, in seconds, for size changes to take place
    //public float sizeChangeTimeInSeconds = 0.5f;
    public AudioSource growSound;
    public AudioSource shrinkSound;
    public int currentScaleIndex = 1;
    public bool isControlLocked = true;
    Rigidbody carRigidBody;
    public float jumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        carRigidBody = GetComponent<Rigidbody>();
        InitializeScale();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        if (!isControlLocked) {

            //Shrink
            if (Input.GetKeyDown("q") && currentScaleIndex > 0)
            {
                //Bounce();
                shrinkSound.Play();
                currentScaleIndex--;
                UpdateScale(sizeArray[currentScaleIndex]);
            }

            //Grow
            if (Input.GetKeyDown("e") && currentScaleIndex < 2)
            {
                //Bounce();
                growSound.Play();
                currentScaleIndex++;
                UpdateScale(sizeArray[currentScaleIndex]);
            }

            //Bounce
            if(Input.GetKeyDown(KeyCode.Space)){
                Bounce();
            }
        }
    }

    void InitializeScale()
    {
        transform.localScale = new Vector3(sizeArray[currentScaleIndex], sizeArray[currentScaleIndex], sizeArray[currentScaleIndex]);
        carRigidBody.mass = sizeArray[currentScaleIndex] * 950;
    }

    void UpdateScale(float size)
    {
        transform.localScale = new Vector3(size, size, size);
        carRigidBody.mass = sizeArray[currentScaleIndex] * 950;
    }

    void UpdateScaleOverTime(float size)
    {
        Vector3 newScale = new Vector3(size, size, size);

    }

    void Bounce() {
        if (IsGrounded()) {
            carRigidBody.AddForce(transform.up * jumpForce * 1000 * (sizeArray[0]/sizeArray[2]), ForceMode.Impulse);
        }
    }

    bool IsGrounded() {
        Vector3 raycastOffset = new Vector3(transform.position.x, transform.position.y + sizeArray[0]/sizeArray[2], transform.position.z);
        return Physics.Raycast(raycastOffset, transform.TransformDirection(Vector3.down), sizeArray[0]/sizeArray[2]);
    }
}
