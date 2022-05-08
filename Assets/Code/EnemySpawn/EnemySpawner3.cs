using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner3 : MonoBehaviour
{
    public GameObject theEnemy;
    int xPos, zPos, yPos, i = 0;
    public int negxPos = -24, posxPos = 8, negzPos = 1, poszPos = 30, enemyCount = 4;
    public Turn player;
    [SerializeField] private Camera Camera;
    [SerializeField] private Canvas HealthBarCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player.setTotalEnemies(enemyCount);
        StartCoroutine(EnemyDrop());
    }

    public int enemies() {
        return enemyCount;
    }
    IEnumerator EnemyDrop()
    {
        while (i < enemyCount)
        {
            if (i == 1)
            {
                negzPos = 60;
                poszPos = 62;
                negxPos = -93;
                posxPos = -65;
                yPos = 6;
            } else if (i == 2) {
                negzPos = 3;
                poszPos = 19;
                negxPos = -95;
                posxPos = -68;
                yPos = 3;
            } else if (i == 3) {
                negzPos = 3;
                poszPos = 16;
                negxPos = -95;
                posxPos = -68;
                yPos = 36;
            } else {
                yPos = 0;
            }
            xPos = Random.Range(negxPos, posxPos);
            zPos = Random.Range(negzPos, poszPos);
            GameObject thisEnemy = Instantiate(theEnemy, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            Target target = thisEnemy.GetComponent<Target>();
            if (i == 1)
            {
                target.leftWayPoint = -94;
                target.rightWayPoint = -64;
            } else if (i == 2) {
                target.leftWayPoint = -96;
                target.rightWayPoint = -67;
            } else if (i == 3) {
                target.leftWayPoint = -96;
                target.rightWayPoint = -67;
            } else {
                target.leftWayPoint = -24;
                target.rightWayPoint = 8;
            }
            target.setupHP(HealthBarCanvas, Camera);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }
}
