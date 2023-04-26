using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEnemy : MonoBehaviour
{
    public static CollectEnemy instance;
    [Header("Prefabs Refs")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject collectedVFX;
    [SerializeField] private GameObject collectEnemyGameObject;

    [Header("Data Refs")]
    [SerializeField] private PlayerValues playerVars;


    private bool CanBeCollect;

    void Awake()
    {
        instance = this;
    }


    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            //print("Colidiu com o player NEW");
            if(playerVars.currentStack < playerVars.maxStack)
            {
                playerVars.currentStack += 1;
                Player.instance.UpdateStack();
                UIManager.instance.UpdateCurrencyGameplay();
                Instantiate(collectedVFX, collectEnemyGameObject.transform.position, Quaternion.identity);
                Destroy(this.enemyPrefab);
            }
        }
    }

    public void SetCanBeCollect(bool booleanCollect)
    {
        CanBeCollect = booleanCollect;
    }

}
