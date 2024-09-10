
using UnityEngine;

public static class AnimCurve
{
    // public CurvesSO straightCurve;
    
    
    public static AnimationCurve Load()
    {
        var curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        return new AnimationCurve();
    }
}
