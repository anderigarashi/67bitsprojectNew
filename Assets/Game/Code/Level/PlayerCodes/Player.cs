using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Move Controls")]
    public DynamicJoystick moveJoystick;
    private float _xMove, _zMove;
    [SerializeField] private float speedMove = 5;


    [Header("Physics & Anim Char")]
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;


    [Header("Stack References")]
    private Vector3 _firstStackPos;
    private Vector3 _currentStackPos;
    List<GameObject> _stackList = new List<GameObject>();
    private int _stackListIndexCounter = 0;
    [SerializeField] private GameObject spawnStackPosition;
    [SerializeField] private GameObject enemyDyiedPrefab;


    [Header("Skins Vars / Refs")]
    [SerializeField] private Vector2 skins01UVoffset;
    [SerializeField] private Vector2 skins02UVoffset;
    [SerializeField] private Vector2 skins03UVoffset;
    [SerializeField] private Vector2 skins04UVoffset;
    [SerializeField] private SkinnedMeshRenderer CharacterShirt;
    [SerializeField] private SkinnedMeshRenderer CharacterBody;
    [SerializeField] private SkinnedMeshRenderer CharacterPants;


    [Header("Data Refs")]
    [SerializeField] private PlayerValues playerVars;


    //---- Counter Sell Unstack System Vars ----//
    private float counterSellStack;
    private bool isSellingStacks;
    private float setSpeedCounter = 1.2f;
    private bool maxSpeedCounter;
    [SerializeField] private GameObject rpgNumber;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        var objJoystick = GameObject.FindGameObjectWithTag("joystick");
        playerVars.currentStack = 0;
        playerVars.maxStack = 5;
        playerVars.currentSkin = 0;
        playerVars.coinsPlayer = 100;
        playerVars.punchForce = 650;
        playerVars.haveSkin0 = true;
        playerVars.haveSkin1 = false;
        playerVars.haveSkin2 = false;
        playerVars.haveSkin3 = false;
    }
    
    void Update()
    {
        //---- Basic Movement ----//
        _xMove = moveJoystick.Horizontal;
        _zMove = moveJoystick.Vertical;
        Vector3 dir = new Vector3(_xMove, 0, _zMove);
        Vector3 forwardMove = Vector3.forward * _zMove * speedMove * Time.deltaTime;
        Vector3 horizontalMove = Vector3.right * _xMove * speedMove * Time.deltaTime;
        rb.velocity = new Vector3(_xMove*speedMove, rb.velocity.y, _zMove*speedMove);


        //---- Movement verification to change Anim ----//
        if(dir != Vector3.zero)
        {
            transform.LookAt(transform.position + dir);
            anim.SetBool("isRunning", true);
        } else { anim.SetBool("isRunning", false); }


        //---- Counter to Increase the Unstack selling speed ----//
        if(isSellingStacks)
        {
            counterSellStack += Time.deltaTime;
            if(counterSellStack >= setSpeedCounter && _stackList.Count > 0)
            {
                SellEnemyStack();
                counterSellStack = 0;
                if(setSpeedCounter > 0.5f && maxSpeedCounter == false)
                {
                    setSpeedCounter -= 0.2f;
                    if(setSpeedCounter <= 0.45f){ maxSpeedCounter = true; }
                }
            }
        }
    }

    //---- Sell Enemy Stacked ----//
    private void SellEnemyStack()
    {
        if(_stackList.Count > 0)
        {
            int lastStackList = _stackList.Count;
            GameObject stackRef = GameObject.Find("Stack_"+_stackList.Count);
            Destroy(stackRef.gameObject);
            playerVars.coinsPlayer += 10;
            Vector3 playerPos = new Vector3(transform.position.x, 2.659f, 10.788f);
            Instantiate(rpgNumber, playerPos, Quaternion.identity);
            if(playerVars.currentStack > 0) { playerVars.currentStack -= 1; }
            _stackList.RemoveAt(_stackList.Count -1);
            if(_stackListIndexCounter > 0) { _stackListIndexCounter--; }
            UIManager.instance.UpdateCurrencyGameplay();
        } else { print("lista vazia!"); }
    }
    

    [ContextMenu("Instantiate Stack Player")]
    public void UpdateStack()
    {
        var newObj = Instantiate(enemyDyiedPrefab, spawnStackPosition.transform.position, spawnStackPosition.transform.rotation);
        _stackList.Add(newObj);
        newObj.name = "Stack_" + _stackList.Count;
        if(_stackList.Count == 1)
        {
            newObj.gameObject.GetComponentInChildren<EnemyStack>().UpdateEnemyPosition(spawnStackPosition.transform, true);
            newObj.transform.position = new Vector3(spawnStackPosition.transform.position.x, spawnStackPosition.transform.position.y
             + (0.35f * _stackList.Count), spawnStackPosition.transform.position.z);
        }
        else if(_stackList.Count > 1)
        {
            newObj.transform.position = new Vector3(spawnStackPosition.transform.position.x, spawnStackPosition.transform.position.y
             + (0.35f * _stackList.Count), spawnStackPosition.transform.position.z);
            newObj.gameObject.GetComponentInChildren<EnemyStack>().UpdateEnemyPosition(_stackList[_stackListIndexCounter].transform, true);
            _stackListIndexCounter++; //used to new stack follow the old stack
        }
    }


    [ContextMenu("Update Current Skin changing UV Position")]
    public void UpdateSkinAtual(int skinAtualInt)
    {
        if(skinAtualInt == 0)
        {
            CharacterBody.material.mainTextureOffset = new Vector2(skins01UVoffset.x, skins01UVoffset.y);
            CharacterPants.material.mainTextureOffset = new Vector2(skins01UVoffset.x, skins01UVoffset.y);
            CharacterShirt.material.mainTextureOffset = new Vector2(skins01UVoffset.x, skins01UVoffset.y);
        }
        else if(skinAtualInt == 1)
        {
            CharacterBody.material.mainTextureOffset = new Vector2(skins02UVoffset.x, skins02UVoffset.y);
            CharacterPants.material.mainTextureOffset = new Vector2(skins02UVoffset.x, skins02UVoffset.y);
            CharacterShirt.material.mainTextureOffset = new Vector2(skins02UVoffset.x, skins02UVoffset.y);
        }
        else if(skinAtualInt == 2)
        {
            CharacterBody.material.mainTextureOffset = new Vector2(skins03UVoffset.x, skins03UVoffset.y);
            CharacterPants.material.mainTextureOffset = new Vector2(skins03UVoffset.x, skins03UVoffset.y);
            CharacterShirt.material.mainTextureOffset = new Vector2(skins03UVoffset.x, skins03UVoffset.y);
        }
        else if(skinAtualInt == 3)
        {
            CharacterBody.material.mainTextureOffset = new Vector2(skins04UVoffset.x, skins04UVoffset.y);
            CharacterPants.material.mainTextureOffset = new Vector2(skins04UVoffset.x, skins04UVoffset.y);
            CharacterShirt.material.mainTextureOffset = new Vector2(skins04UVoffset.x, skins04UVoffset.y);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy") { anim.SetBool("punch", true); }
        if(other.gameObject.tag == "sellenemy") { isSellingStacks = true; }
        if(other.gameObject.tag == "buyskins") { UIManager.instance.Open_Close_BuyShop(true); }
        if(other.gameObject.tag == "upgradestack") { UIManager.instance.Open_Close_UpgradeStacks(true); }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "sellenemy")
        {
            isSellingStacks = false;
            setSpeedCounter = 1.2f;
            counterSellStack = 0;
            maxSpeedCounter = false;
        }
        if(other.gameObject.tag == "upgradestack") { UIManager.instance.Open_Close_UpgradeStacks(false); }
        if(other.gameObject.tag == "buyskins") { UIManager.instance.Open_Close_BuyShop(false); }
    }
}
