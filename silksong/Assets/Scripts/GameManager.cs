using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timer;
    public float levelDuration = 60;
    public bool isLevelFinished;
    public string nextLevelName;
    public Health playerHealth;
    public Health shoreHealth;
    private void Awake()
    {
        playerHealth.OnDeath += Lose;
        shoreHealth.OnDeath += Lose;
    }
    private void OnDestroy() 
    {
        playerHealth.OnDeath -= Lose;
        shoreHealth.OnDeath -= Lose;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > levelDuration) 
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
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void EndButton()
    {
        SceneManager.LoadScene("startscreen");
    }

}
