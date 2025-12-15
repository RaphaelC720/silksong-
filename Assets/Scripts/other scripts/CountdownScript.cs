using TMPro;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    public float timeLeft;
    public TextMeshProUGUI countdownText;
    public static CountdownScript Instance;
    private bool timerStarted = false;

    public void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if (GameManager.Instance.isLevelFinished && !timerStarted)
        {
            timerStarted = true;
        }

        if (timerStarted)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft > 0)
            {
                countdownText.text = Mathf.Ceil(timeLeft).ToString();
            }
            else
            {
                enabled = false;
            }
        }
    }
    public void ResetCountdown()
    {
        timeLeft = 5f;
        timerStarted = false;
        enabled = true;
    }

}
