using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dengarus_enviorment : MonoBehaviour
{
    public int damage = 10;
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
        collision.transform.GetComponent<moving>().hurt(damage);
    }
}
