using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGun : MonoBehaviour
{
    // Start is called before the first frame update
    Timer timers;

    [SerializeField]
    GameObject Gun1;
    [SerializeField]
    GameObject Gun2;
    [SerializeField]
    GameObject Gun3;
    [SerializeField]
    GameObject Gun4;

    GameObject GunX;
    public int maxGun = 5;
    public int currentGun = 0;
    public float timePlay;

    float P1;
    float P2;
    float P3;
    float P4;
    

    // Start is called before the first frame update
    public void Start()
    {
        timers = GetComponent<Timer>();
        timers.arlarmTime = 30;
        timers.StartTime();
    }

    // Update is called once per frame
    public void Update()
    {
        timePlay = Time.time;
        if(timePlay <= 120)
        {
            P1 = -0.3333f * timePlay + 50;
            P2 = P1 + 30;
            P3 = P2 + 0.1666f * timePlay + 15;
            P4 = P3 + 0.1666f * timePlay + 5;

        }
        else if ( timePlay > 120)
        {
            P1 = 10;
            P2 = 30;
            P3 = 35;
            P4 = 25;
        }



        if (currentGun < maxGun)
        {
            GunSpawn();
            currentGun++;
        }
        if(timers.isFinish)
        {
            maxGun++;
            timers.arlarmTime = 30;
            timers.StartTime();
        }
    }

    private Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    public void GunSpawn()
    {
        Bounds bounds = OrthographicBounds(Camera.main);
        float X = Random.Range(bounds.min.x, bounds.max.x);
        float Y = Random.Range(bounds.min.y, bounds.max.y);
        int random = Random.Range(0, 100);
        if (random <= P1)
        {
            GunX = Gun1;

        }
        else if (random > P1 && random <= P2)
        {
            GunX = Gun2;
        }
        else if (random > P2 && random <= P3)
        {
            GunX = Gun3;
        }
        else if (random > P3 && random <= P4)
        {
            GunX = Gun4;
        }
        GameObject obj = Instantiate(GunX, new Vector2(X, Y), Quaternion.identity);
        int size = Random.Range(2, 5);
        obj.transform.localScale = new Vector3(size, size, 1f);
       

    }

}
