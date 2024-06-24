using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossController : MonoBehaviour
{
    // Start is called before the first frame update
     public float timeSpawn = 0f;
    public float timeDlay = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timeSpawn += Time.deltaTime;
            if (timeSpawn < timeDlay) return;
            else{
                Destroy(gameObject);
                timeSpawn =0;
            }
    }
}
