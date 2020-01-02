using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenActivate : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().enabled = true;
    }
}
