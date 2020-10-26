using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScriptHorizontal2 : MonoBehaviour
{
    private bool goLeft = true;
    public float speed = 2.5f;

    void Update()
    {
        if (goLeft)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= 58.0f)
        {
            goLeft = false;
        }

        if (transform.position.x >= 70.0f)
        {
            goLeft = true;
        }


    }
}
