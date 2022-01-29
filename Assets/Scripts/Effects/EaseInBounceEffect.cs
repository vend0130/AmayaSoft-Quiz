using DG.Tweening;

public class EaseInBounceEffect : MyEffect
{
    protected override void Effect(Sequence sequence, int frame)
    {
        sequence.Append(transform.DOMoveX(transform.position.x + _keyFrame[frame], _duration));
    }

    public void EndEffect()
    {
        _playEffect = false;
    }
}