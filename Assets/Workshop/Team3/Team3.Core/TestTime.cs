public interface ITime
{
    float getDeltaTime();
}

public class TestTime : ITime
{
    public TestTime()
    {

    }

    public float getDeltaTime()
    {
        return UnityEngine.Time.deltaTime;
    }
}
