using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    [Header("UI de victoire")]
    public CanvasGroup victoryPanel;
    public float fadeDuration = 0.5f;
    public AudioSource victoryMusic;

    [Header("Animation optionnelle")]
    public Animator victoryAnimator;
    public string victoryTrigger = "Play";

    private void Awake()
    {
        if (victoryPanel)
        {
            victoryPanel.alpha = 0f;
            victoryPanel.interactable = false;
            victoryPanel.blocksRaycasts = false;
        }
    }

    public void PlayVictory()
    {
        if (victoryAnimator && !string.IsNullOrEmpty(victoryTrigger))
        {
            victoryAnimator.SetTrigger(victoryTrigger);
        }
        if (victoryMusic) victoryMusic.Play();
        if (victoryPanel) StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        victoryPanel.interactable = true;
        victoryPanel.blocksRaycasts = true;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            victoryPanel.alpha = Mathf.InverseLerp(0f, fadeDuration, t);
            yield return null;
        }
        victoryPanel.alpha = 1f;
    }
}