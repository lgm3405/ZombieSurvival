using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RestartBtnTween : MonoBehaviour, IPointerEnterHandler
{
    Tween shakeAni = default;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("마우스를 올려 두었다.");

        if (shakeAni == null || shakeAni == default)
        {
            shakeAni = transform.DOShakeScale(0.5f, 1, 10, 90, true, ShakeRandomnessMode.Harmonic).SetAutoKill();   // SetAutoKill : 트윈이 동작 후 자동으로 끈다
            shakeAni.onKill += () => DisposeShake();
            return;
        }

        //Debug.Log("Shake Ani 가 비어 있지는 않다.");
    }

    //! Tween 이 Kill 될 때 shakeAni 변수를 비워주는 함수
    private void DisposeShake()
    {
        shakeAni = default;
        transform.localScale = Vector3.one;
    }
    

}
