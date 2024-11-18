using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegsService
{
    public static Action Changed;

    public static void ChangePegs()
    {
        Changed?.Invoke();
    }
}
