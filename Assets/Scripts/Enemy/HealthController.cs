using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHp=1;
    public int maxHpBoss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
   public void hpIc(){
        maxHp++;
    }
    public void maxboss(){
        maxHpBoss = maxHp*2;
    }
}
