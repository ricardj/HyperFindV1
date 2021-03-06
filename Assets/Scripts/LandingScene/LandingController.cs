using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LandingController : MonoBehaviour
{
    Material materialToFade;
    public RawImage rawImage;
    public string materialPropertyToFade = "_FadeAmount";
    public Image imageToFade;
    public GameObject objectToScale;




    // Start is called before the first frame update
    void Start()
    {
        materialToFade = rawImage.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Transition();
        }
    }

    public void Transition()
    {

        float timeAnimation = 4f;
        
        DOTween.To(() => materialToFade.GetFloat(materialPropertyToFade), x => materialToFade.SetFloat(materialPropertyToFade, x), 0.82f, timeAnimation).OnComplete(()=>
        {     
            
        });
        objectToScale.transform.DOMove(Vector3.up * 200, timeAnimation + 2).SetEase(Ease.InOutSine).SetRelative();

        
        
    }
}
