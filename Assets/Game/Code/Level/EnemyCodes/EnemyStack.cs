using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStack : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private GameObject playerDirection;
    

    [Header("Stack Properties")]
    [SerializeField] private float followSpeed;


    void Start()
    {
        playerDirection = GameObject.FindGameObjectWithTag("Player");
    }


    public void UpdateEnemyPosition(Transform followedStack, bool isFollowStart)
    {
        StartCoroutine(StartFollowingToLastStackPosition(followedStack, isFollowStart));
    }
    IEnumerator StartFollowingToLastStackPosition(Transform followedStack, bool isFollowStart)
    {
        while(isFollowStart)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedStack.position.x, followSpeed * Time.deltaTime),
            transform.position.y,
            Mathf.Lerp(transform.position.z, followedStack.position.z, followSpeed * Time.deltaTime));

            //transform.rotation = Quaternion.Lerp(transform.rotation, followedRotation, followSpeed * Time.deltaTime);
        }
    }
    
    void Update()
    {
        this.transform.rotation = Quaternion.Lerp(transform.rotation, playerDirection.transform.rotation, followSpeed * Time.deltaTime);
    }
}
