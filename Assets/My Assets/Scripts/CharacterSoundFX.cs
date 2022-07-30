using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attack, die;
    // Start is called before the first frame update
    void Start()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        soundFX.clip = attack;
        soundFX.Play();
    }

    public void Die()
    {
        soundFX.clip = die;
        soundFX.Play();
    }
}
