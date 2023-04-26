using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private GameObject playerDirection;


    [Header("Enemy References/Properties")]
    //[SerializeField] private float punchForce;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody _rbMain;
    [SerializeField] private GameObject AIcontroller;


    [Header("Prefabs / Rbs / Colliders")]
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Rigidbody rbHips;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Collider[] _colliders;


    [Header("Prefabs")]
    [SerializeField] private GameObject enemyCollectableCollider;
    [SerializeField] private GameObject enemyMeshTag;
    [SerializeField] private GameObject enemyPrefab;

    [Header("Data Refs")]
    [SerializeField] private PlayerValues playerVars;


    private bool livingEnemy;


    void Start()
    {
        livingEnemy = true;
        _rigidbodies = this.GetComponentsInChildren<Rigidbody>();
        _colliders = this.GetComponentsInChildren<Collider>();
        playerDirection = GameObject.FindGameObjectWithTag("Player");
    }


    //---- Trigger ----//
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && livingEnemy)
        {
            livingEnemy = false;
            Destroy(AIcontroller);
            PrepareToPunch();
        }
    }


    //----Change rbs and Collider to Impulse Force----//
    private void PrepareToPunch()
    {
        foreach(Rigidbody _rb in _rigidbodies) { _rb.isKinematic = false; }
        foreach(Collider _cl in _colliders) { _cl.enabled = true; }
        Destroy(_capsuleCollider);
        _rbMain.isKinematic = true;
        anim.enabled = false;
        PlayerPunch();
    }


    //---- Apply force in forward Player Direction ----//
    private void PlayerPunch()
    {
        rbHips.AddForce(playerDirection.transform.forward * playerVars.punchForce, ForceMode.Impulse);
        Invoke("WaitToBeCollectable", 1);
    }


    //---- Delay to active Collectable Trigger ----//
    private void WaitToBeCollectable()
    {
        enemyCollectableCollider.gameObject.SetActive(true);
        CollectEnemy.instance.SetCanBeCollect(true);
        enemyMeshTag.tag = "EnemyDied";
    }

}
