using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chuyencanh : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.jumAudio);
    }
}
