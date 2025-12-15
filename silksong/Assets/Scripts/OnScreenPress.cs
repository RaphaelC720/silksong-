using UnityEngine;
using UnityEngine.SceneManagement;

public class OnScreenPress : MonoBehaviour
{
    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("startscreen");
        }
    }
}
