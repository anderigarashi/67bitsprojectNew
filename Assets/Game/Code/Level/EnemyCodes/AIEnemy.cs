using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    enum AIenemy00 { walk, waitIdle }

    [Header("AI Enemy References")]
    [SerializeField] private AIenemy00 _currentState;
    [SerializeField] private GameObject enemyOBJ;
    [SerializeField] private float enemySpeedMove;
    private float timeWalking;
    private bool startWalking;
    private float timeWaiting;
    private bool startWaiting;
    private float randomDirection;

    [SerializeField] private Animator EnemyAnim;


    void Start()
    {
        SetEnemyDecision();
    }


    void Update()
    {
        if(startWalking)
        {
            timeWalking -= Time.deltaTime;
            enemyOBJ.transform.Translate(0, 0, enemySpeedMove * Time.deltaTime);
            if(timeWalking <= 0)
            { 
                startWalking = false;
                SetEnemyDecision();
                EnemyAnim.SetBool("isWalking", false);
            }
        }
        if(startWaiting)
        {
            timeWaiting -= Time.deltaTime;
            if(timeWaiting <= 0)
            { 
                startWaiting = false;
                SetEnemyDecision();
            }
        }
    }

    //---- Enemy state Verification ----//
    private void SetEnemyDecision()
    {
        switch (_currentState)
        {
            case AIenemy00.walk:
            AIWalking();
            //Debug.Log("Enemy Walking");
            _currentState = AIenemy00.waitIdle;
            break;
            case AIenemy00.waitIdle:
            AIWaiting();
            //Debug.Log("Enemy Waiting Idle");
            _currentState = AIenemy00.walk;
            break;
        }
    }

    private void AIWalking()
    {
        randomDirection = Random.Range(1, 360);
        enemyOBJ.transform.localRotation = Quaternion.Euler(0, randomDirection, 0);
        timeWalking = Random.Range(2, 5);
        startWalking = true;
        EnemyAnim.SetBool("isWalking", true);
    }
    private void AIWaiting()
    {
        timeWaiting = Random.Range(3, 6);
        startWaiting = true;
    }
}
