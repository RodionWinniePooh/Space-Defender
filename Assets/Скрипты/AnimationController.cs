using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public bool state=false;

    public AudioSource click;
    public void ButtonClick()
    {
        state = !state;
        click.Play();
}

    private void Update()
    {
        if (!state)
        {
            anim.SetBool("isSetting", false);
        }
        else
        {
            anim.SetBool("isSetting", true);
        }
    }

}
