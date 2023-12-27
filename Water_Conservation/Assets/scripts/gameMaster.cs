using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public int bottles;

    public Text bottlestext;

    void Update()
    {
        bottlestext.text = ("" + bottles);   
    }
}
