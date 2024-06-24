using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject character;
    private float speed = 3.5f; 
    private float timeIcSpeed=0; 
    private float timeIcDelaySpeed=30; 
    // public GameObject character;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject walkers = GameObject.FindWithTag("Player");
        Vector3 distance = walkers.transform.position - transform.position;
        Vector3 targetPoint = walkers.transform.position - distance.normalized * 1;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, speed * Time.deltaTime);

        timeIcSpeed += Time.deltaTime; 
        if(timeIcSpeed <timeIcDelaySpeed) return;
        else{
            speed += 0.25f;
            timeIcSpeed =0;
        }
    }
}
