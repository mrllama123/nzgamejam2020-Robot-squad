using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    private string currentText = "";
    private string fullText;

    // Use this for initialization
    void Start()
    {
        fullText = GetComponent<Text>().text;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        
    }
}
