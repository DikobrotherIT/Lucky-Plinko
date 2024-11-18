using System;

public class BackgroundService
{
    public static Action Changed;

    public static void ChangeBackground()
    {
        Changed?.Invoke();
    }
}
