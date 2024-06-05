using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class coolDownSkill : MonoBehaviour
{
    public Image fillSkill;

    public void UpdateSkill(float cooldownPercentage)
    {
        fillSkill.fillAmount = cooldownPercentage;
    }
}
