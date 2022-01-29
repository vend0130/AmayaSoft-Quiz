using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class MyEffect : MonoBehaviour
{
    [SerializeField] protected float _duration;
    [SerializeField] protected float[] _keyFrame;
    [SerializeField] protected UnityEvent _endEffect;

    protected bool _playEffect;

    public virtual void Play()
    {
        if (_playEffect)
            return;

        _playEffect = true;

        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < _keyFrame.Length; i++)
        {
            Effect(sequence, i);
        }

        sequence.AppendCallback(() => _endEffect.Invoke());

        sequence.Play();
    }
    protected abstract void Effect(Sequence sequence, int frame);
}