using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillbar;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI LevelText;
    public void UpdateBar(int currentValue, int maxValue)
    {
        fillbar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }

    public void UpdateLevel(int level)
    {
        LevelText.text = level.ToString();
    }
}
