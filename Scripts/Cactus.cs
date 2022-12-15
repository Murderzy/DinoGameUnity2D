using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    
    private float Speed = 2.5f;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector2.left * Speed;   
    }

    // Update is called once per frame
    void Update()
    {
        //  движение кактуса влево
        this.transform.Translate(moveDirection * Time.deltaTime);
    }
}
