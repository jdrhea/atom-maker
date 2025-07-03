using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    AudioManager AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    public void PlayMouseClick()
    {
        AudioManager.PlaySFX(AudioManager.click);
    }
    public void PlayCash()
    {
        AudioManager.PlaySFX(AudioManager.cash);
    }
}
