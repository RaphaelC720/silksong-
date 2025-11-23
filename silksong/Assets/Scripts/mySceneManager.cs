using UnityEngine;
using UnityEngine.SceneManagement;

public class mySceneManager : MonoBehaviour
{
    public GameObject controlsPanel;
    private bool controlOpen;
    private void Start()
    {
        controlOpen = false;
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
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void EndButton()
    {
        SceneManager.LoadScene("startscreen");
    }


}
