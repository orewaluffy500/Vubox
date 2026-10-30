namespace vubox.engine;


public static class JsaMath
{
    public static float Lerp(float begin, float end, float lerpFactor) => begin + (end - begin) * lerpFactor;
}