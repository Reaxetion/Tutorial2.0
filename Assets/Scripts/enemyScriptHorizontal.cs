using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScriptHorizontal : MonoBehaviour
{

    private bool goLeft = true;
    public float speed = 2.5f;

    void Update()
    {
        if (goLeft)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -2.0f)
        {
            goLeft = false;
        }

        if (transform.position.x >= 8.0f)
        {
            goLeft = true;
        }


    }
}
