using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    int xPos, zPos, i = 0;
    public int enemyCount = 3;
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
            xPos = Random.Range(-21, 14);
            zPos = Random.Range(-14, 21);
            Instantiate(theEnemy, new Vector3(xPos,0,zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }
}
