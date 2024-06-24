using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BanDan : MonoBehaviour
{
    float rotationSpeed = 5f;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    private float bulletSpeed = 12f;
    public float attackSpeed = 0.2f;
    Timer timers;
    [SerializeField]
    public AudioSource soundGun1;
    public AudioSource soundGun2;
    public AudioSource soundGun3;
    public AudioSource soundGun4;




    // Start is called before the first frame update
    public void Start()
    {

        timers = GetComponent<Timer>();
        timers.arlarmTime = 1;
        timers.StartTime();
    }

    // Update is called once per frame
    public void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 closestWalkerDirection = Vector2.zero;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject e in enemys)
        {
            float distance = Vector2.Distance(transform.position, e.transform.position);
            if (distance < closestDistance && distance <= 15f)
            {
                closestDistance = distance;
                closestWalkerDirection = (e.transform.position - transform.position).normalized;

            }
        }
        //Usung1
        if (collision.CompareTag("USung1"))
        {
            
            if (closestDistance <= 12f)
            {
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {
                   
                    GameObject bullet = Instantiate(bullet1, transform.position, transform.rotation);
                    soundGun1.Play();
                    bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    timers.arlarmTime = attackSpeed + 0.05f;
                    timers.StartTime();
                }
               
            }
        }
        //Usung2
        if (collision.CompareTag("USung2"))
        {
           
            if (closestDistance <= 12f)
            {             
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {

                    GameObject bullet = Instantiate(bullet2, transform.position, transform.rotation);
                    soundGun2.Play();
                    bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    timers.arlarmTime = attackSpeed + 0.1f;
                    timers.StartTime();
                }

            }
        }

        //Usung2
        if (collision.CompareTag("USung3"))
        {
            
            Quaternion rotation1 = Quaternion.Euler(0, 0, 10);
            Quaternion rotation2 = Quaternion.Euler(0, 0, -10);

            Vector2 v2= new Vector2(3, 1);
            if (closestDistance <= 12f)
            {
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {

                    GameObject b1 = Instantiate(bullet3, transform.position, transform.rotation);
                    GameObject b2 = Instantiate(bullet3, transform.position, transform.rotation);
                    GameObject b3 = Instantiate(bullet3, transform.position, transform.rotation);
                    b1.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    soundGun3.Play();
                    b2.GetComponent<Rigidbody2D>().velocity = rotation1 * closestWalkerDirection * bulletSpeed;
                    b3.GetComponent<Rigidbody2D>().velocity = rotation2 * closestWalkerDirection * bulletSpeed;
                    timers.arlarmTime = (attackSpeed + 0.2f);
                    timers.StartTime();
                }

            }
        }

        //Usung4
        if (collision.CompareTag("USung4"))
        {
            if (closestDistance <= 12f)
            {
                float angle = Mathf.Atan2(closestWalkerDirection.y, closestWalkerDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                if (timers.isFinish)
                {

                    GameObject bullet = Instantiate(bullet4, transform.position, transform.rotation);
                    soundGun4.Play();
                    bullet.GetComponent<Rigidbody2D>().velocity = closestWalkerDirection * bulletSpeed;
                    timers.arlarmTime = (attackSpeed + 0.2f);
                    timers.StartTime();
                }

            }
        }
     
    }



 











}
