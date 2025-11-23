using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float levelDuration = 60;
    public bool isLevelFinished;
    public string nextLevelName;
    public Health playerHealth;
    public Health shoreHealth;
    public TextMeshProUGUI timerText;
    private void Awake()
    {
        playerHealth.OnDeath += Lose;
        shoreHealth.OnDeath += Lose;
    }
    private void Start()
    {
        timer = levelDuration;
    }
    private void OnDestroy() 
    {
        playerHealth.OnDeath -= Lose;
        shoreHealth.OnDeath -= Lose;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = ((int)timer).ToString();
        if (timer <= 0) 
        {
            if (!isLevelFinished)
            {
                isLevelFinished = true;
                FinishLevel();
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
