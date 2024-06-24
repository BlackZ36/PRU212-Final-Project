using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStarController : MonoBehaviour
{
    BanDan bd;
    public AudioSource soundStar;
    // Start is called before the first frame update
    void Start()
    {
        bd = FindObjectOfType<BanDan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrEnter2D(Collision2D collision)
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundStar.Play();
            bd.attackSpeed = bd.attackSpeed * 0.5f;
            Destroy(gameObject, 0.4f);
        }
    }
}
