using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    [Header("Hard light shake")]
    public HardLight2D hardLight;
    public float shakeDuration = 0.3f;
    public float shakeStrength = 1f;
    public int shakeVibrato = 90;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Shake(() => Vector3.one * hardLight.Range, x => hardLight.Range = x.x, shakeDuration, shakeStrength, shakeVibrato, 90, true, false)
            .SetLoops(-1, LoopType.Yoyo);

    }


}
