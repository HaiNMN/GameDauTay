using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelUp : MonoBehaviour
{
    [SerializeField] int exMax=10;
    [SerializeField] int currentEx=0;
    [SerializeField] int currentLever=1;



    [SerializeField] GameObject pauseMenu;
    public bool like;
    public bool activateme=false;

    public HealthBar levelBar;

    
    public int currentLeverPlus = 2;

    public static LevelUp Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentEx = 0;

        levelBar.UpdateLevel(currentLever);

        levelBar.UpdateBar(currentEx, exMax);
    }
    

    public 


    void Update()
    {
        if(currentLever <=10)
        {
            if(getLever()>=currentLeverPlus)
            {
                currentLeverPlus++;
                if(like == false)
                {
                    activateme = true;
                    if(activateme == true)
                    {
                        if(pauseMenu != null)
                        {
                            pauseMenu.SetActive(true);
                            Time.timeScale = 0;
                        }
                        like = true;
                    }
                }
            
            }
        }
        
        if(Input.GetKeyUp(KeyCode.T))
        {
            UpEx(1);
        }
        if(currentEx >= exMax)
        {
            currentLever++;
            currentEx = 0;
            like = false;
        }
    }
    public void UpEx(int value)
    {
        this.currentEx+=value;
        levelBar.UpdateBar(currentEx, exMax);
        levelBar.UpdateLevel(currentLever);

    }

    public int getLever()
    {
        return currentLever;
    }

}
