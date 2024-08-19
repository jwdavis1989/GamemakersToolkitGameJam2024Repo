using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string[] gameModes = {"Title", "Race", "Paused", "Victory", "Game Over"};
    private string currentGameMode;
    [Header("Player Endpoint")]
    public GameObject player;
    private PrometeoCarController playerPrometeoScript;

    [Header("UI & Sound")]
    public GameObject titleUI;
    public GameObject raceUI;
    public GameObject musicPlayer;
    private AudioSource backgroundMusic;

    [Header("Race Attributes")]
    public float raceDuration = 120f;
    public float raceDurationRemaining;
    public GameObject raceCountdownLight;
    public bool isCountdownFinished = false;
    public bool hasWon = false;
    public bool hasLost = false;

    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        playerPrometeoScript = player.GetComponent<PrometeoCarController>();
        playerPrometeoScript.enabled = false;
        currentGameMode = gameModes[0];
        backgroundMusic = musicPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //If Racing . . .
        if (currentGameMode == gameModes[1]) {
            HandleRaceLogic();
        }
    }

    public void StartButton() {
        titleUI.SetActive(false);
        raceUI.SetActive(true);
        backgroundMusic.Stop();
        PitchUpMusic();
        backgroundMusic.Play();
        currentGameMode = gameModes[1];
        spawnCountdownLight();
        raceDurationRemaining = raceDuration;
        player.SetActive(true);
    }

    public void ExitButton() {
        Application.Quit();
    }

    public void ToggleMusic() {
        musicPlayer.SetActive(true);
    }

    public void PitchUpMusic() {
        backgroundMusic.pitch += 0.25f;
    }

    void spawnCountdownLight() {
        Instantiate(raceCountdownLight, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void HandleRaceLogic() {
        if (isCountdownFinished) {
            raceDurationRemaining -= Time.deltaTime;
        }
    }

    public void EnablePlayerControl() {
        player.GetComponent<CarGrowthController>().isControlLocked = false;
        playerPrometeoScript.enabled = true;
        isCountdownFinished = true;
    }
}
