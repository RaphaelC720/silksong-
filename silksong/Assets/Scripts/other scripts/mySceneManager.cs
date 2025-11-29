using UnityEngine;
using UnityEngine.SceneManagement;

public class mySceneManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject levelSelectPanel;
    private bool controlOpen;
    private bool levelSelectOpen;
    private void Start()
    {
        controlOpen = false;
        levelSelectOpen = false;
    }
    public void openControls()
    {
        if (controlOpen == false)
        {
            controlsPanel.SetActive(true);
            controlOpen = true;
        }
        else if (controlOpen == true) 
        {
            controlsPanel.SetActive(false);
            controlOpen = false;
        }
    }
    public void openLevelSelect()
    {
        if (levelSelectOpen == false)
        {
            levelSelectPanel.SetActive(true);
            levelSelectOpen = true;
        }
        else if (levelSelectOpen == true)
        {
            levelSelectPanel.SetActive(false);
            levelSelectOpen = false;
        }
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
