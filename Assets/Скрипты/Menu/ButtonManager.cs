using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int scene;

       public void Load()
       {
            Application.LoadLevel(scene);
       }
       public void Restart()
       {
            Application.LoadLevel(Application.loadedLevel);
       }
}
