using DG.Tweening;

public class BounceEffect : MyEffect
{
    protected override void Effect(Sequence sequence, int frame)
    {
        sequence.Append(transform.DOScale(_keyFrame[frame], _duration));
    }
}