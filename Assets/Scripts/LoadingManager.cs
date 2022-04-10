using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
            DontDestroyOnLoad(this);
        }
        else if (get != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        // DontDestroyOnLoad(this);
    }

    bool hiding = false;
    bool showing = false;
    public void Hide(Action finishHide)
    {
        if (!hiding)
        {
            hiding = true;
            GetComponentInChildren<CanvasGroup>().DOFade(0, 1f).OnComplete(() =>
             {
                 //gameObject.SetActive(false);
                 hiding = false;
                 finishHide.Invoke();
                 Destroy(gameObject);
             });
        }
    }

    public void Show(Action onCompleteAction)
    {
        if (!showing)
        {
            //gameObject.SetActive(true);

            showing = true;
            GetComponentInChildren<CanvasGroup>().DOFade(1, 1f).OnComplete(() =>
            {
                showing = false;
                onCompleteAction.Invoke();
            });
        }
    }


}
