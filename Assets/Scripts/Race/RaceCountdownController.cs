using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCountdownController : MonoBehaviour
{
    private Transform trafficLight;
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    private bool isCurrentlyDescending = true;
    [Header("Animation")]
    public float descentCeiling = 1;
    public Vector3 startingPosition = new Vector3(-5f, 20f, 5f);
    public Vector3 descentSpeed = new Vector3(0, -8f, 0);
    private bool isCountingDown = false;
    private float countDownInterval = 1.15f;
    private int countDownRemaining = 4;
    private float countDownBeginningPause = 1.03f;

    [Header("Countdown")]
    public AudioSource countDownSound;
    float fixedTimer;

    // Start is called before the first frame update
    void Start() {
        trafficLight = this.gameObject.transform.GetChild(0);
        trafficLight.position = startingPosition;
        countDownSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() { 
        HandleDescent();
        HandleCountdown();
    }

    void HandleDescent() {
        if (trafficLight.position.y > descentCeiling && isCurrentlyDescending) {
            trafficLight.position += descentSpeed * Time.deltaTime;
        }
        else {
            trafficLight.position = new Vector3(trafficLight.position.x, descentCeiling, trafficLight.position.z);
            if (isCurrentlyDescending) {
                isCountingDown = true;
            }
            isCurrentlyDescending = false;
        }
    }

    void HandleCountdown() {
        if (isCountingDown) {
            InvokeRepeating("Beep", countDownBeginningPause, countDownInterval);
            countDownSound.Play(0);
            isCountingDown = false;
        }
    }

    void Beep() {
        Debug.Log(countDownRemaining);
        if (countDownRemaining == 4) {
            redLight.SetActive(true);
        }
        else if (countDownRemaining == 3) {
            redLight.SetActive(false);
            yellowLight.SetActive(true);
        }
        else if (countDownRemaining == 2) {
            yellowLight.SetActive(false);
            greenLight.SetActive(true);
        }
        countDownRemaining--;

        if (!countDownSound.isPlaying) {
            CancelInvoke("Beep");
        }
    }
}
