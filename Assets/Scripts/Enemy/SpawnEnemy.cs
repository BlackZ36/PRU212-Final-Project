using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
   List<GameObject> enemys;

    public GameObject enemyPreFab;
    public  GameObject bossPrefab; 

    protected float timeSpawnEnemy = 0f;
    protected float timeDlayEnemy = 1f;
    protected float timeCount = 0f;
    protected float timeDlayCount = 15f;
    protected float timeSpawnBoss= 0f;
    protected float timeDlayBoss = 30f;
    private int totalEnemy =0;

    private void Start()
    {
        this.enemys = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Spawns();
        this.CheckMinionDeath();
        this.SpawnBoss();
        timeCount+= Time.deltaTime; 
        if(timeCount<timeDlayCount) return;
        else{
            totalEnemy++;
            timeCount =0;
        }

    }
    private void Spawns()
    {
        this.timeSpawnEnemy += Time.deltaTime;
        if (this.timeSpawnEnemy < this.timeDlayEnemy) return;
        this.timeSpawnEnemy = 0;
        if (this.enemys.Count > 5) return;
        GameObject minion = Instantiate(this.enemyPreFab);
        minion.transform.position = new Vector2(Random.Range(-60,60), Random.Range(-23,23));
        this.enemys.Add(minion);
    }
    private void SpawnBoss()
    {
        this.timeSpawnBoss += Time.deltaTime;
        if (this.timeSpawnBoss < this.timeDlayBoss) return;
        this.timeSpawnBoss = 0;
        GameObject minion = Instantiate(this.bossPrefab);
        minion.transform.position = new Vector2(Random.Range(-60,60), Random.Range(-23,23));
    }
    void CheckMinionDeath()
    {
        GameObject miniondie;
        for (int i = 0; i < this.enemys.Count; i++)
        {
            miniondie = this.enemys[i];
            if (miniondie == null)
            {
                this.enemys.RemoveAt(i);
            }
        }
    }
}
