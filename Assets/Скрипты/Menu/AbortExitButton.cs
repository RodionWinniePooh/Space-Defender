using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbortExitButton : MonoBehaviour
{
    public void Abort()
    {
        FindObjectOfType<ExitConfirmButton>().exit = false;
    }
}
