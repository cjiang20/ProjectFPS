using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    int xPos, zPos, i = 0;
    public int negxPos = -22, posxPos = 10, negzPos = -14, poszPos = 21, enemyCount = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyDrop()
    {
        while (i < enemyCount)
        {
            if (i == 3)
            {
                negzPos = 28;
                poszPos = 35;
            }
            xPos = Random.Range(negxPos, posxPos);
            zPos = Random.Range(negzPos, poszPos);
            Instantiate(theEnemy, new Vector3(xPos,0,zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }
}
