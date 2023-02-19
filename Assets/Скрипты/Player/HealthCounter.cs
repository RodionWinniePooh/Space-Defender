using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public void HealthChanged(float damage)
    {
        this.GetComponent<Image>().fillAmount = (this.GetComponent<Image>().fillAmount  - damage);
    }
}
