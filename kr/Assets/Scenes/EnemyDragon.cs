using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject dragonGoodEggPrefab;
    public GameObject dragonBadEggPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirections = 0.1f;
    
    void Start()
    {
        Invoke("DropEgg", 2f);
    }
    void DropEgg()
    {
        int random = Random.Range(0, 4);
        if (random == 0)
        {
            Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
            GameObject egg1 = Instantiate<GameObject>(dragonBadEggPrefab);
            egg1.transform.position = transform.position + myVector;
        }
        else
        {
            Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
            GameObject egg = Instantiate<GameObject>(dragonGoodEggPrefab);
            egg.transform.position = transform.position + myVector;
        }
        Invoke("DropEgg", timeBetweenEggDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position; //1
        pos.x += speed * Time.deltaTime; //2
        transform.position = pos; //3
        if (pos.x < -leftRightDistance) //1
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance) //2
        {
            speed = -Mathf.Abs(speed);
        }

    }
    private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }


}