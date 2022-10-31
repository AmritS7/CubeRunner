using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class TextFadeOut : MonoBehaviour
{
    //Fade time in seconds
    public float fadeOutTime;
    public Text score;

    void Start()
    {
        FindObjectOfType<TextFadeOut>().FadeOut();
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            FindObjectOfType<TextFadeOut>().displayScore();
        }
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            StartCoroutine(displayScore());
        }

    }
    private IEnumerator FadeOutRoutine()
    {
        Text text = GetComponent<Text>();
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }

    public IEnumerator displayScore()
    {
        yield return new WaitForSeconds(5f);
        score.enabled = true;
    }
   
}