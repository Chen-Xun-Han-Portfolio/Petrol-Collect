using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

[RequireComponent(typeof(Image))]
public class Loop_background2 : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;

    void Awake()
    {
        var image = GetComponent<Image>();
        var rectTransform = GetComponent<RectTransform>();

        var sprite = image.sprite;
        var posTween = DOTween.To(
            () => rectTransform.anchoredPosition, x => rectTransform.anchoredPosition = x,
            new Vector2(
                -sprite.texture.width * 0.5f,
                -sprite.texture.height * 0.5f),
            backgroundSpeed);

        posTween.SetEase(Ease.Linear);
        posTween.SetLoops(-1, LoopType.Restart);

        var sizeTween = DOTween.To(
            () => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x,
            new Vector2(
                sprite.texture.width,
                sprite.texture.height),
            backgroundSpeed);

        sizeTween.SetEase(Ease.Linear);
        sizeTween.SetLoops(-1, LoopType.Restart);
    }
}

