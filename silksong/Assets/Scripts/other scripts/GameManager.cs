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
        
    }
    private void OnDestroy() 
    {
        playerHealth.OnDeath -= Lose;
        shoreHealth.OnDeath -= Lose;
    }
    private void Update()
    {
        if(isLevelFinished == false)
        {
            timer -= Time.deltaTime;
        }
        timerText.text = ((int)timer).ToString();
        if (timer <= 0) 
        {
            isLevelFinished = true;
            if (isLevelFinished == true)
            {
                darkenPanel.SetActive(true);
                dayText.SetActive(false);
                transitionDayText.SetActive(true);
                transitionCountdownText.SetActive(true);
                DurationText.SetActive(true);
                startscreenButton.SetActive(true);
            }
        }

        if (CountdownScript.Instance.timeLeft <= 2 && isLevelFinished)
        {
            StartLevel();                
            

            dayText.SetActive(true);
            darkenPanel.SetActive(false);
            transitionDayText.SetActive(false);
            transitionCountdownText.SetActive(false);
            DurationText.SetActive(false);
            startscreenButton.SetActive(false);
        }
        else
        {
            return;
        }
    }
    public void StartLevel()
    {
        isLevelFinished = false;
        dayNumber = 1;
        dayNumber++;
        dayNumberText.text = "Day " + dayNumber;
        
        timer = levelDuration += 5;
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
