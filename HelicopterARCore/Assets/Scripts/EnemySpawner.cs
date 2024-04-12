using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPlane;
    public Button SpawnButton;
    
    void Start()
    {
        Button SpawnButton = GameObject.Find("SpawnButton").GetComponent<Button>();
        SpawnButton.onClick.AddListener(Spawn);
    }

    
    void Update()
    {
        
    }

    private void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 2, Random.Range(-10, 11));
        Instantiate(EnemyPlane, randomSpawnPosition, Quaternion.identity);
    }
}
