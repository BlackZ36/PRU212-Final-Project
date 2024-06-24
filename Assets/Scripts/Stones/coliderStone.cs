using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coliderStone : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ReviceItems ri = other.GetComponent<ReviceItems>();
            ri.ReciveStone(-5f);
            Destroy(gameObject);
        }
    }   
}
