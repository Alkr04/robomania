using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steam_tank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.GetComponent<player_attack>().steam < collision.transform.GetComponent<player_attack>().msteam)
            {
                collision.transform.GetComponent<player_attack>().energy(-5);
                Destroy(this.gameObject);
            }
        }
    }
}
