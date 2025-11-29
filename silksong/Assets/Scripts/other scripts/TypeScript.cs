using System.Collections;
using TMPro;
using UnityEngine;

public class TypeScript : MonoBehaviour
{
    public TMP_Text textUI;
    public float delay = 0.4f;

    private void Start()
    {
        StartCoroutine(RevealWords());
    }

    IEnumerator RevealWords()
    {
        textUI.ForceMeshUpdate();
        int totalWords = textUI.textInfo.characterCount;

        textUI.maxVisibleWords = 0;

        for (int i = 1; i <= totalWords; i++)
        {
            textUI.maxVisibleWords = i;
            yield return new WaitForSeconds(delay);
        }
    }
}
