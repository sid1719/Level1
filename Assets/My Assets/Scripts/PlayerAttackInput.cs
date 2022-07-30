using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;
    // Start is called before the first frame update
    public GameObject attackPoint,attackPoint2;
    private CharacterSoundFX soundFX;
    void Start()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimation.Fire();
            soundFX.Attack();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            playerAnimation.Tail();
            soundFX.Attack();
        }
    }

    void ActivateAttackPoint1()
    {
        attackPoint.SetActive(true);
    }
    void DeactivateAttackPoint1()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }


    void ActivateAttackPoint2()
    {
        attackPoint2.SetActive(true);
    }
    void DeactivateAttackPoint2()
    {
        if (attackPoint2.activeInHierarchy)
        {
            attackPoint2.SetActive(false);
        }
    }
}
