using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun3Controller : MonoBehaviour
{
    int radius;
    int size;
    [SerializeField]

    public float maxHP;
    public float currentHP;
    private Vector3 initialScale;
    bool isColliding = false;
    BanDan bd;
    Timer timers;


    // Start is called before the first frame update
    void Start()
    {
        timers = GetComponent<Timer>();
        bd = GetComponent<BanDan>();
        initialScale = transform.localScale;
        radius = (int)gameObject.transform.localScale.x;

        if (radius == 2)
        {
            maxHP = Random.Range(10, 16);
            currentHP = maxHP;
        }
        if (radius == 3)
        {
            maxHP = Random.Range(16, 21);
            currentHP = maxHP;
        }
        if (radius == 4)
        {
            maxHP = Random.Range(21, 31);
            currentHP = maxHP;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] walkers = GameObject.FindGameObjectsWithTag("Enemy");

            Vector2 closestWalkerDirection = Vector2.zero;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject walker in walkers)
            {
                float distance = Vector2.Distance(transform.position, walker.transform.position);
                if (distance < closestDistance && distance <= 12f)
                {
                    closestDistance = distance;
                    closestWalkerDirection = (walker.transform.position - transform.position).normalized;

                }
            }
            if (closestDistance <= 12f)
            {
                if (timers.isFinish)
                {
                    currentHP -= 1;
                    float scaleRatio = currentHP / maxHP;
                    if (transform.localScale.x >= 1.5f)
                    {
                        transform.localScale = initialScale * scaleRatio;
                    }

                    timers.arlarmTime = 0.2f;
                    timers.StartTime();
                }
                if (currentHP == 0)
                {
                    Destroy(gameObject);
                }

            }

        }



    }
}
