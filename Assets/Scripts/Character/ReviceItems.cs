using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviceItems : MonoBehaviour
{
    // Start is called before the first frame update

    joystickCharacter js;
    public new GameObject animation;
    public new GameObject animationSpeed;
    float totalSpeed;
    private float timeSpeedExit = 0;
    private float timeDlaySpeedExit = 5;
    private float timeArmorExit = 0;
    private float timeDlayArmorExit = 4;
    private bool checkSpeed = false;
    private int checkArmor = 1;
    private Color startColor = Color.red;
    private Color endColor = Color.black;
    [Range(0, 10)]
    float speedBlink = 9;
    Renderer ren;
    public int checkStone = 1;
    public float timeStoneExit = 0;
    public float timeDelayStone = 5;
    public int checkCountStone = 0;
    MenuEvent me;
    void Start()
    {
        js = FindObjectOfType<joystickCharacter>();
        me = FindObjectOfType<MenuEvent>();
    }
    void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkSpeed == true)
        {
            this.timeSpeedExit += Time.deltaTime;
            if (this.timeSpeedExit < this.timeDlaySpeedExit)
            {
                GameObject ani = Instantiate(animationSpeed, transform.position, Quaternion.identity) as GameObject;
                Destroy(ani, 0.2f);
                return;
            }
            else
            {
                this.timeSpeedExit = 0;
                speedReduce();
            }
        }
        if (checkArmor == 2)
        {
            GameObject ani = Instantiate(animation, transform.position, Quaternion.identity) as GameObject;
            Destroy(ani, 0.018f);
        }
        if (checkArmor == 3)
        {
            this.timeArmorExit += Time.deltaTime;
            if (this.timeArmorExit < this.timeDlayArmorExit)
            {
                ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speedBlink, 1));
                return;
            }
            else
            {
                this.timeArmorExit = 0;
                immortalTime();
            }
        }
        if (checkStone == 2 && checkCountStone == 1)
        {
            timeStoneExit += Time.deltaTime;
            if (timeStoneExit < timeDelayStone) return;
            else
            {
                timeStoneExit = 0;
                ReciveStone(5f);
                checkStone = 1;
                checkCountStone = 0;
            }

        }
        if (checkStone == 2 && checkCountStone >= 2)
        {
            timeStoneExit += Time.deltaTime;
            if (timeStoneExit < timeDelayStone) return;
            else
            {
                timeStoneExit = 0;
                js.setSpeed(10);
                checkStone = 1;
                checkCountStone = 0;
            }

        }
    }
    void speedReduce()
    {
        ReciveItemSpeedUp(-5f);
        checkSpeed = false;
    }
    void immortalTime()
    {
        ReciveItemArmor(false);
        checkArmor = 1;
    }
    public virtual void ReciveItemSpeedUp(float spUp)
    {
        totalSpeed = js.getSpeed();
        totalSpeed += spUp;
        js.setSpeed(totalSpeed);
        checkSpeed = true;
    }
    public virtual void ReciveStone(float spUp)
    {
        checkCountStone++;
        if (checkCountStone >= 3)
        {
            js.setSpeed(0);
            // return;
        }
        else
        {
            totalSpeed = js.getSpeed();
            totalSpeed += spUp;
            js.setSpeed(totalSpeed);
            checkStone = 2;
        }
    }
    public virtual void ReciveItemArmor(bool armor)
    {
        js.setArmor(armor);
        checkArmor = 2;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (checkArmor == 2 || checkArmor == 3)
            {
                checkArmor = 3;
            }
            else
            {
                me.ShowGameoverPanel(true);
                Time.timeScale = 0;
            }
        }
    }
}
