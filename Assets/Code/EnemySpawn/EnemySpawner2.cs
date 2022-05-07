using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject theEnemy;
    int xPos, zPos, yPos, i = 0;
    public int negxPos = -22, posxPos = 10, negzPos = -14, poszPos = 21, enemyCount = 4;
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
            if (i == 2)
            {
                negzPos = 28;
                poszPos = 35;
                yPos = 3;
            } else if (i == 3) {
                negzPos = 43;
                poszPos = 50;
                yPos = 6;
            } else {
                yPos = 0;
            }
            xPos = Random.Range(negxPos, posxPos);
            zPos = Random.Range(negzPos, poszPos);
            GameObject thisEnemy = Instantiate(theEnemy, new Vector3(xPos,yPos,zPos), Quaternion.identity);
            Target target = thisEnemy.GetComponent<Target>();
            target.setupHP(HealthBarCanvas, Camera);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }
}
