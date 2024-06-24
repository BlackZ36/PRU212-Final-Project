using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    public GameObject Star;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.arlarmTime = 15f;
        timer.StartTime();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinish)
        {
            StarSpawn();
            timer.arlarmTime = 15f;
            timer.StartTime();

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

    public void StarSpawn()
    {
        Bounds bounds = OrthographicBounds(Camera.main);
        Vector2 spawnPos = new Vector2(Random.Range( bounds.min.x,  bounds.max.x), Random.Range( bounds.min.y, bounds.max.y));
        GameObject obj = Instantiate(Star, spawnPos, Quaternion.identity);
    }
}
