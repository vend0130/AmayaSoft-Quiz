using UnityEngine;
using DG.Tweening;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _targetAlpha;
    [SerializeField] private float _duration;

    public void FadeIn()
    {
        _canvasGroup.gameObject.SetActive(true);
        _canvasGroup.DOFade(1, _duration);
    }
}