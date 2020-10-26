using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }
    void Update()

    {
        // Quit! Saves us in the case of the player getting destroyed.
        if (Input.GetKey("escape"))
        {

            Application.Quit();

        }
    }
}