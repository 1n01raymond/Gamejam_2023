using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    public Transform bed;
    public List<Transform> regenPlace = new List<Transform>();
    public List<RootEnemy> enemies = new List<RootEnemy>();

    public RootEnemy enemyPrefab;

    public float regenInterval;
    private float regenTimer;

    void Awake(){
        // set regenTimer to regenInterval
        regenTimer = regenInterval;

        // add from children to regenPlace
        foreach (Transform child in transform)
        {
            regenPlace.Add(child);
        }
    }

    void Update()
    {
        // instantiate root enemy from enemyPrefab at random regenPlace with interval
        if (regenTimer > regenInterval)
        {
            int index = Random.Range(0, regenPlace.Count);

            

            RootEnemy enemy = Instantiate(enemyPrefab, regenPlace[index].position, Quaternion.identity, regenPlace[index]);
            
            // rotate enemy to look at bed
            Vector3 dir = bed.position - enemy.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            enemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            enemies.Add(enemy);
            regenTimer = 0;
        } else {
            regenTimer += Time.deltaTime;
        }

    }
}
