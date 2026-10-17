using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] public AudioClip jump, die, coin, key, win, lose;
    [SerializeField] AudioSource player;
    public static AudioController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySound(AudioClip sound)
    {
        player.clip = sound;
        StartCoroutine("OnPlaySound");
    }
    IEnumerator OnPlaySound()
    {
        yield return new WaitUntil(() => !player.isPlaying);
        player.Play();
    }
}
