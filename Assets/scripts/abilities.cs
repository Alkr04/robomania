using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilities : MonoBehaviour
{
    public Transform Hbar;
    public moving moving;
    // Start is called before the first frame update
    void Start()
    {
        moving = this.GetComponent<moving>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void heal()
    {
        /*foreach (Transform child in moving.Hbar)
        {
            if ()
            {

            }
            else
            {
                moving.Children.Add(child.gameObject);
            }
        }*/
    }
}
