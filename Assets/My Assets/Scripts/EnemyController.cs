using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}
public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_Anim;
    private NavMeshAgent navAgent;

    private Transform playerTarget;
    public float move_speed = 2.5f;

    public float attack_Distance = 1f;
    public float chase_Player_After_Attck_Distance = 1f;

    private float wait_Before_Attack_time = 3f;
    private float attack_Timer;

    private EnemyState enemy_State;
    public GameObject attackPoint, attackPoint2;
    private CharacterSoundFX soundFX;
    // Start is called before the first frame update
    void Awake()
    {
        enemy_Anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    private void Start()
    {
        enemy_State = EnemyState.CHASE;

        attack_Timer = wait_Before_Attack_time;
    }
    // Update is called once per frame
    void Update()
    {
        if(enemy_State==EnemyState.CHASE)
        {
            ChasePlayer();
        }
        if(enemy_State==EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed=move_speed;

        if(navAgent.velocity.sqrMagnitude==0)
        {
            enemy_Anim.Walk(false);
        }
        else
        {
            enemy_Anim.Walk(true);
        }

        if(Vector3.Distance(transform.position,playerTarget.position)<=attack_Distance)
        {
            enemy_State = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        enemy_Anim.Walk(false);

        attack_Timer += Time.deltaTime;

        if(attack_Timer >wait_Before_Attack_time)
        {
            if(Random.Range(0,2)>0)
            {
                enemy_Anim.Fire();
                soundFX.Attack();
            }
            else
            {
                enemy_Anim.Tail();
                soundFX.Attack();
            }
            attack_Timer = 0f;
        }

        if(Vector3.Distance(transform.position,playerTarget.position)>attack_Distance+chase_Player_After_Attck_Distance)
        {
            navAgent.isStopped = false;
            enemy_State = EnemyState.CHASE;
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
