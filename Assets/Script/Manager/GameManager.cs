using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float speedObstacle;
    public float speedBullet;
    public float speedEnemy;
    public bool isGameOver;
    public int score;
    public int bulletRound;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bulletText;
    [SerializeField] private Button startBtn;
    [SerializeField] private GameObject player;
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public Sprite[] sprite;
    private Image image;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        image = GameObject.Find("MuteButton").GetComponent<Image>();

        OnStartGame();
    }

    void Update()
    {
        CheckMuteSound();
        SetText();
    }

    private void CheckMuteSound()
    {
        if (SoundManager.instance.GetComponent<AudioSource>().mute == false)
        {
            image.sprite = sprite[1];
        }
        else if (SoundManager.instance.GetComponent<AudioSource>().mute == true)
        {
            image.sprite = sprite[0];
        }
    }

    private void SetText()
    {
        bulletText.text = bulletRound.ToString();
        scoreText.text = score.ToString();
    }

    private void SpawnObject()
    {
        SpawnObstacle.instance.SpawnObstacleOnScreen();
        SpawnStar.instance.SpawnStarOnScreen();
        SpawnEnemy.instance.SpawnEnemyOnScreen();
    }

    private void ShowPlayer()
    {
        player.gameObject.SetActive(true);
    }

    private void OnStartGame()
    {
        bulletRound = 1;
        isGameOver = true;
        mainMenu.SetActive(true);
        gameOverMenu.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }

    public void OnGameOver()
    {
        isGameOver = true;
        mainMenu.gameObject.SetActive(false);
        gameOverMenu.gameObject.SetActive(true);
    }

    public void MuteSoundButton()
    {
        if (SoundManager.instance.GetComponent<AudioSource>().mute == false)
        {
            SoundManager.instance.GetComponent<AudioSource>().mute = true;
        }
        else if (SoundManager.instance.GetComponent<AudioSource>().mute == true)
        {
            SoundManager.instance.GetComponent<AudioSource>().mute = false;
        }
    }

    public void StartButton()
    {
        SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.clickSound);
        mainMenu.SetActive(false);
        isGameOver = false;
        SpawnObject();
        Destroy(startBtn);
        Invoke("ShowPlayer", 0.1f);
    }

    public void RestartButton()
    {
        SoundManager.instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.instance.clickSound);

        if (isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
