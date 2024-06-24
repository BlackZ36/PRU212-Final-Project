using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPEnemyUI : MonoBehaviour
{
    public Text HPText;
    

    public void SetHPText(string txt)
    {
        if (HPText)
        {
            HPText.text = txt;
        }

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
