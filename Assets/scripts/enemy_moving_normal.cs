using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moving_normal : MonoBehaviour
{
    bool rigth = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigth)
        {
            rigth = false;
        }
        else
        {
            rigth = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigth)
        {
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }
    }
}
