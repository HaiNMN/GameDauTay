using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUp_skill : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;


    public void duongban()
    {   
        
        Debug.Log("+1 duong ban");
        Move.Instance.setBullet(5);
        Time.timeScale = 1;
        if(pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
        
    }

    public void tangSpeed()
    {
        
        Debug.Log("+1 toc do");
        Move.Instance.setSpeedBullet(2);
        Time.timeScale = 1;
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
            
    }
    public void chieu()
    {
        Debug.Log("+1 chieu");
    }

}
