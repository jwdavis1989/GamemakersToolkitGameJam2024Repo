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
    public float jumpCooldownInSeconds = 3f;
    public float transformCooldownInSeconds = 1f;
    private bool canJump = true;
    private bool canTransform = true;

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
            TransformBounce();
            currentScaleIndex--;
            UpdateScale(sizeArray[currentScaleIndex]);
        }

        //Grow
        if (Input.GetKeyDown("e") && currentScaleIndex < 2)
        {
            TransformBounce();
            currentScaleIndex++;
            UpdateScale(sizeArray[currentScaleIndex]);
        }

        //Bounce
        if(Input.GetKeyDown(KeyCode.Space)){
            Bounce();
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
        if (canJump){
        //if (IsGrounded()) {
            canJump = false;
            carRigidBody.AddForce(transform.up * jumpForce * 1000 * (sizeArray[0]/sizeArray[2]), ForceMode.Impulse);
            carRigidBody.mass = sizeArray[currentScaleIndex] * 950;
            StartCoroutine(JumpCooldown());
        }
    }
    void TransformBounce() {
        if (canTransform){
        //if (IsGrounded()) {
            canTransform = false;
            carRigidBody.AddForce(transform.up * jumpForce * 1000 * (sizeArray[0]/sizeArray[2]), ForceMode.Impulse);
            carRigidBody.mass = sizeArray[currentScaleIndex] * 950;
            StartCoroutine(TransformCooldown());
        }
    }

    private IEnumerator JumpCooldown() {
        yield return new WaitForSeconds(jumpCooldownInSeconds);
        canJump = true;
    }

    private IEnumerator TransformCooldown() {
        yield return new WaitForSeconds(transformCooldownInSeconds);
        canTransform = true;
    }

    // bool IsGrounded() {
    //     bool debug = Physics.Raycast(transform.position, -Vector3.up, collider.bounds.extents.y + 0.1);
    //     Debug.Log(debug);
    //     return debug;
    // }
}
