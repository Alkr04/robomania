using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    public int hp = 1;
    enemy_moving_normal mover;
    public Collider2D Stank;
    public counter count;
    // Start is called before the first frame update
    void Start()
    {
        mover = this.GetComponent<enemy_moving_normal>();
        count = FindObjectOfType<counter>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void damage()
    {
        mover.turn();
        //print("plz turn");
        if (hp == 0)
        {
            count.point++;
            Instantiate(Stank, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
