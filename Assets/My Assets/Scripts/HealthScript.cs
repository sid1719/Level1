using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthScript : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    public float health = 100f;
    public static string winner = "";
    [SerializeField]
    private Image health_UI;
    private CharacterSoundFX soundFX;

    private void Awake()
    {
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }
    void Start()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        
    }

    private void Update()
    {
        if (health <= 0)
        {
            if(tag=="Enemy")
            {
                winner="Player1 Wins";
            }
            else
            {
                winner="Player 2 wins";
            }
            playerAnimation.Dead();
            soundFX.Die();
        }
    }
    public void ApplyDamage(float damage)
    {
        health -= damage;

       if(health_UI!=null)
        {
            health_UI.fillAmount = health / 100f;
        }
    }
}
