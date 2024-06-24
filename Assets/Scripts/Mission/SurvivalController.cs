using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class SurvivalController : MonoBehaviour
{
    Timer timer;
    Survival sv;
    float curentSize;
    bool outBo = false;
    MenuEvent me;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 5;
        timer.StartTime();
        sv = FindObjectOfType<Survival>();

        curentSize = sv.size;
        me = FindObjectOfType<MenuEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinish)
        {
            curentSize -= 0.03f;
            gameObject.transform.localScale = new Vector3(curentSize, curentSize, 1f);

            timer.arlarmTime = 0.01f;
            timer.StartTime();

        }
        if(curentSize <= 35f )
        {
            outBo = false;           
            Destroy(gameObject,0.1f);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            outBo = true; 
        }
        if(outBo == true)
        {
            me.ShowGameoverPanel(true);
            Time.timeScale = 0;
        }
      
       

    }


}
