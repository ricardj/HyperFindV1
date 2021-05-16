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

    public void Hide()
    {
        GetComponentInChildren<CanvasGroup>().DOFade(0, 1f).OnComplete(() =>
         {
             Destroy(gameObject);
         });
    }

    public void Show(Action onCompleteAction)
    {
        GetComponentInChildren<CanvasGroup>().DOFade(1, 1f).OnComplete(() =>
        {
            onCompleteAction.Invoke();
        });
    }

    
}
