using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject victoryUI;
    public GameObject musicPlayer;
    private AudioSource backgroundMusic;
    public TextMeshProUGUI timerText;

    [Header("Race Attributes")]
    public float raceDuration = 15f;
    public float raceDurationRemaining;
    public float raceDurationDangerDivisor = 3f;
    public GameObject raceCountdownLight;
    public bool isCountdownFinished = false;
    private bool isRunningOutOfTime = false;
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
        SetTimerTextDisplay();
        player.SetActive(true);
    }

    public void ExitButton() {
        Application.Quit();
    }

    public void RestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisplayVictoryScreen() {
        titleUI.SetActive(false);
        raceUI.SetActive(false);
        victoryUI.SetActive(true);
        player.SetActive(false);
        currentGameMode = gameModes[3];
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
            UpdateTimerTextDisplay();
            if (!isRunningOutOfTime && raceDurationRemaining < (raceDuration / raceDurationDangerDivisor)) {
                isRunningOutOfTime = true;
                PitchUpMusic();
            }
        }
    }

    public void EnablePlayerControl() {
        player.GetComponent<CarGrowthController>().isControlLocked = false;
        playerPrometeoScript.enabled = true;
        isCountdownFinished = true;
    }

    public void SetTimerTextDisplay() {
        raceDurationRemaining = raceDuration;
        int minutes = Mathf.FloorToInt(raceDurationRemaining / 60);
        int seconds = Mathf.FloorToInt(raceDurationRemaining % 60);
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void UpdateTimerTextDisplay() {
        raceDurationRemaining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(raceDurationRemaining / 60);
        int seconds = Mathf.FloorToInt(raceDurationRemaining % 60);
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
