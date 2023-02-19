using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    public bool isGround;
    public int height;
    public int width;

    private void Update()
    {
        height = Screen.height;
        width = Screen.width;
        if (isGround)
        {
            Screen.SetResolution(height, width, true);
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
        else
        {
            Screen.SetResolution(width, height, true);
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
        }
    }
}
