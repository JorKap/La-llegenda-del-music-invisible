using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text;
    private CanvasGroup canvasGroup;
    private float fade = 0;
    private Color color;
    private string message;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        canvasGroup.alpha = fade;
    }


    public void DisplayText(string message, Color color)
    {
        StartCoroutine(FadeIn(message, color));
    }
    IEnumerator FadeIn(string message, Color color)
    {
        while (fade < 1)
        {
            fade += 0.1f;
            canvasGroup.alpha = fade;
            text.text = message;
            color.a = fade;
            text.color = color;

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (fade > 0)
        {
            fade -= 0.1f;
            canvasGroup.alpha = fade;
            color.a = fade;
            text.color = color;

            yield return new WaitForEndOfFrame();
        }
    }
}
