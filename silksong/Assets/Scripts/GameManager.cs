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
    public GameObject transitionText;
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
                transitionText.SetActive(true);
                //FinishLevel();
            }
        }
    }
    private void FinishLevel () 
    {
        SceneManager.LoadScene(nextLevelName);
    }
    public void Lose()
    {
        SceneManager.LoadScene("endscreen");
    }

}
