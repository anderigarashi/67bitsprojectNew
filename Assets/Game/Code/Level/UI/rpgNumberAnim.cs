using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rpgNumberAnim : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private int alphaValueToReduce;
    [SerializeField] private TextMeshPro textRpgNumber;
    [SerializeField] private Vector3 scaleValueToReduce;
    private int alphaValue = 255;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speedMove * Time.deltaTime, 0);
        if(transform.localScale.x > 0) { transform.localScale -= scaleValueToReduce; }
        if(transform.localScale.x < 0.8f)
        { 
            alphaValue -= alphaValueToReduce;
            textRpgNumber.faceColor = new Color32(255, 224, 1, (byte)alphaValue);
        }
        
        if(alphaValue <= 20)
        {
            Destroy(gameObject);
        }
    }
}
