using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MainMenuController : MonoBehaviour
{
    [Header("Animation values")]
    public float startSequenceAnimationDuration = 4f;
    public float initialOptionsFadeDuration = 0.5f;

    [Header("UI references")]
    public Button startButton;
    public Button creditsButton;
    public Button exitButton;

    public Transform mainTitleAlternativePlaceholder;
    public Transform mainTitleNormalPlaceholder;

    public CanvasGroup optionsPanel;
    public GameObject mainTitlesPanel;

    //Flag values
    bool initialClick = false;

    public void Start()
    {
        startButton.onClick.AddListener(() => OnStartButton());
        creditsButton.onClick.AddListener(() => OnCreditsButton());
        exitButton.onClick.AddListener(() => OnExitButton());
    }

    public void OnStartButton()
    {

    }

    public void OnCreditsButton()
    {

    }

    public void OnExitButton()
    {

    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!initialClick)
            {
                initialClick = true;
                StartCoroutine(InitialSequence());
            }
        }
    }

    public IEnumerator InitialSequence()
    {
        Debug.Log("So far so good");
        mainTitlesPanel.transform.DOMove(mainTitleAlternativePlaceholder.transform.position, startSequenceAnimationDuration);
        yield return new WaitForSeconds(startSequenceAnimationDuration);
        optionsPanel.gameObject.SetActive(true);
        optionsPanel.DOFade(0, initialOptionsFadeDuration).From();

    }
}
