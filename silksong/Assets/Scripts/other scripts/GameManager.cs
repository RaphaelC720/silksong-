using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timer;
    public float levelDuration = 60;
    public bool isLevelFinished;
    public string nextLevelName;
    public Health playerHealth;
    public Health shoreHealth;
    public TextMeshProUGUI timerText;
    public GameObject darkenPanel;
    public GameObject dayText;
    public int dayNumber;
    public TextMeshProUGUI dayNumberText;
    public GameObject transitionDayText;
    public GameObject transitionCountdownText;
    public GameObject DurationText;
    public GameObject startscreenButton;
    bool transitionStarted = false;

    public GameObject BoxSpawner;
    public GameObject BottleSpawner;
    public GameObject AlgaeSpawner;

    private void Awake()
    {
        playerHealth.OnDeath += Lose;
        shoreHealth.OnDeath += Lose;
    }
    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        timer = levelDuration;
        isLevelFinished = false;

        //spaawners
        BoxSpawner.SetActive(true);
        BottleSpawner.SetActive(false);
        AlgaeSpawner.SetActive(false);
    }
    private void OnDestroy() 
    {
        playerHealth.OnDeath -= Lose;
        shoreHealth.OnDeath -= Lose;
    }
    private void Update()
    {
        if(!isLevelFinished)
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer).ToString();
        }
        if (timer <= 0 && !transitionStarted) 
        {
            StartTransition();
        }
        if (isLevelFinished && CountdownScript.Instance.timeLeft <= 0)
        {
            StartLevel();
            EndTransition();
        }
        //spawner update
        if (dayNumber == 16)
        {
            SceneManager.LoadScene("FinalScene");
        }
        else if (dayNumber == 13)
        {
            AlgaeSpawner.SetActive(true);
            BottleSpawner.SetActive(true);
            BoxSpawner.SetActive(true);
        }
        else if (dayNumber == 10)
        {
            BoxSpawner.SetActive(true);
            AlgaeSpawner.SetActive(true);
        }
        else if (dayNumber == 8)
        {
            AlgaeSpawner.SetActive(true);
            BoxSpawner.SetActive(false);
            BottleSpawner.SetActive(false);
        }
        else if (dayNumber == 5)
        {
            BoxSpawner.SetActive(true);
        }
        else if (dayNumber == 3)
        {
            BottleSpawner.SetActive(true);
            BoxSpawner.SetActive(false);
        }
    }
    public void StartLevel()
    {
        dayNumber++;
        dayNumberText.text = "Day " + dayNumber;

        isLevelFinished = false;
        timer = levelDuration += 1;
    }
    public void StartTransition()
    {
        isLevelFinished = true;
        transitionStarted = true;

        darkenPanel.SetActive(true);
        dayText.SetActive(true);
        transitionDayText.SetActive(true);
        transitionCountdownText.SetActive(true);
        DurationText.SetActive(true);
        startscreenButton.SetActive(true);

        CountdownScript.Instance.ResetCountdown();
    }
    void EndTransition()
    {
        darkenPanel.SetActive(false);
        dayText.SetActive(true);
        transitionDayText.SetActive(false);
        transitionCountdownText.SetActive(false);
        DurationText.SetActive(false);
        startscreenButton.SetActive(false);

        transitionStarted = false;
    }
    public void StartScreen() 
    {
        SceneManager.LoadScene("startscreen");
    }
    public void Lose()
    {
        SceneManager.LoadScene("endscreen");
    }

}
