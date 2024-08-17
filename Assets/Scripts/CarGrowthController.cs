using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGrowthController : MonoBehaviour
{
    [Header("Sizes")]
    public float[] sizeArray = {0.5f, 1f, 2f};
    private int currentScaleIndex = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    void GetInputs() {
        //Shrink
        if (Input.GetKeyDown("q") && currentScaleIndex > 0) {
            currentScaleIndex--;
            updateScale(sizeArray[currentScaleIndex]);
        }

        //Grow
        if (Input.GetKeyDown("e") && currentScaleIndex < 2) {
            currentScaleIndex++;
            updateScale(sizeArray[currentScaleIndex]);
        }
    }

    void updateScale(float size) {
        transform.localScale = new Vector3(size, size, size);
    }
}
