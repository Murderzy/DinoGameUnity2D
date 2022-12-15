using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject CactusA;
    [SerializeField]
    private GameObject CactusB;
    [SerializeField]
    private GameObject CactusC;
    private float cactusTime;
    private float cactusSpawnTime = 1.5f;
    private float TimeRange = 4;

    // Start is called before the first frame update
    void Start()
    {
        cactusTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cactusTime -= Time.deltaTime;
        if(cactusTime < 0)
        {
            cactusTime = cactusSpawnTime + TimeRange;
            SpawnCactus();
        }
    }

    private void SpawnCactus()
    {
        this.transform.position = this.transform.position;
        switch (Random.Range(1, 4))
        {
            case 1:
                GameObject.Instantiate(CactusA, this.transform.position, Quaternion.identity);
                break;
            case 2:
                GameObject.Instantiate(CactusB, this.transform.position, Quaternion.identity);
                break;
            case 3:
                GameObject.Instantiate(CactusC, this.transform.position, Quaternion.identity);
                break;
            default:
                Debug.LogError("switch out of range");
                break;
        }
    }
}
