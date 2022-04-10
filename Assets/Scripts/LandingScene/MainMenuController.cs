using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
public class MainMenuController : MonoBehaviour
{
    [Header("Animation values")]
    public float startSequenceAnimationDuration = 4f;
    public float initialOptionsFadeDuration = 0.5f;

    [Header("UI references")]
    public ExtendedButton startButton;
    public ExtendedButton creditsButton;
    public ExtendedButton exitButton;

    public Transform mainTitleAlternativePlaceholder;
    public Transform mainTitleNormalPlaceholder;

    public CanvasGroup optionsPanel;
    public GameObject mainTitlesPanel;

    [Header("Events")]
    public UnityEvent OnStartButtonEvent;
    public UnityEvent OnCreditsButtonEvent;
    public UnityEvent OnExitButtonEvent;

    [Header("Audio Clips")]
    public AudioClip selectionClip;
    public AudioClip changeClip;


    //Flag values
    bool initialClick = false;

    public void Start()
    {
        startButton.onClick.AddListener(() => OnStartButton());
        creditsButton.onClick.AddListener(() => OnCreditsButton());
        exitButton.onClick.AddListener(() => OnExitButton());

        List<ExtendedButton> buttons = new List<ExtendedButton> { startButton, creditsButton, exitButton };
        buttons.ForEach(button => button.OnSelectEvent.AddListener(() => AudioManager.get.PlayClip(changeClip)));
    }

    public void OnStartButton()
    {
        OnStartButtonEvent.Invoke();
        AudioManager.get.PlayClip(selectionClip);
        LandingSceneManager.get.NewGame();
    }

    public void OnCreditsButton()
    {
        OnCreditsButtonEvent.Invoke();
        AudioManager.get.PlayClip(selectionClip);
        LandingSceneManager.get.Credits();

    }

    public void OnExitButton()
    {
        OnExitButtonEvent.Invoke();
        AudioManager.get.PlayClip(selectionClip);
        LandingSceneManager.get.ExitGame();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!initialClick)
            {
                initialClick = true;
                StartCoroutine(InitialSequence());
                AudioManager.get.PlayClip(changeClip);

            }
        }
    }

    public IEnumerator InitialSequence()
    {

        mainTitlesPanel.transform.DOMove(mainTitleAlternativePlaceholder.transform.position, startSequenceAnimationDuration);
        yield return new WaitForSeconds(startSequenceAnimationDuration);
        optionsPanel.gameObject.SetActive(true);
        optionsPanel.DOFade(0, initialOptionsFadeDuration).From();

    }
}
