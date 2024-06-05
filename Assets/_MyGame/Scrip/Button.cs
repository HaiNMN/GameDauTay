using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ButtonSound()
    {
        _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.jumAudio);
    }
}
