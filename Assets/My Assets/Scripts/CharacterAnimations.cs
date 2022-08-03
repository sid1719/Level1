using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool("Walk", walk);
    }
    public void Fly(bool fly)
    {
        anim.SetBool("Fly",fly);
    }
    public void Fire()
    {
        anim.SetTrigger("Fire");
    }
    public void Head()
    {
        anim.SetTrigger("Head");
    }
    public void Tail()
    {
        anim.SetTrigger("Tail");
    }

    public void Dead()
    {
        anim.SetTrigger("Dead");
    }    
}
