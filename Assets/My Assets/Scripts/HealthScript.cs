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
            this.gameObject.transform.position= new Vector3(this.transform.position.x, 0.6f, this.transform.position.z);
            playerAnimation.Fly(false);
            playerAnimation.Dead();
            soundFX.Die();

            GameObject.Find("Enemy").GetComponent<EnemyController>().enabled = false;

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
