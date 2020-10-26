using UnityEngine;
using System.Collections;

public class enemyScriptVertical : MonoBehaviour
{

    private bool goUp = true;
    public float speed = 5.0f;

    void Update()
    {
        if (goUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= 9.0f)
        {
            goUp = false;
        }

        if (transform.position.y <= -0.18f)
        {
            goUp = true;
        }

     
    }
}
