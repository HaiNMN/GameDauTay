using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDistr : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
