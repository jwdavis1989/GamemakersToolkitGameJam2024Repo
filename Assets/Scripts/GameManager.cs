using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string[] gameModes = {"Title", "Race", "Paused", "Victory", "Game Over"};
    private string currentGameMode;
    public GameObject titleUI;
    public GameObject raceUI;
    public GameObject musicPlayer;
    private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        currentGameMode = gameModes[0];
        backgroundMusic = musicPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton() {
        titleUI.SetActive(false);
        raceUI.SetActive(true);
        backgroundMusic.Stop();
        backgroundMusic.pitch = 0.75f;
        backgroundMusic.Play();
        currentGameMode = gameModes[1];
    }

    public void ToggleMusic() {
        musicPlayer.SetActive(true);
    }
}
