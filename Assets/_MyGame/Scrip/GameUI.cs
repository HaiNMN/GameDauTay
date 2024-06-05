using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI YouCore;
    public TextMeshProUGUI BestScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore.SetText(GameManager.instance.GetScore().ToString());
        YouCore.SetText(GameManager.instance.GetScore().ToString());
        BestScore.SetText(GameManager.instance.GetBestScore().ToString());
    }
}
