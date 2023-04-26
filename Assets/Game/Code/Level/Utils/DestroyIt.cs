using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIt : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.2f);
    }

}
