using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator : MonoBehaviour
{
    public Sprite[] sattack;
    public SpriteRenderer rsprites;
    public Sprite idl;
    public Sprite[] slash;
    // Start is called before the first frame update
    void Start()
    {
        //rsprites = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stattack()
    {
        StartCoroutine(attack());
    }
    public IEnumerator attack()
    {
        for (int i = 0; i < sattack.Length; i++)
        {
            rsprites.sprite = sattack[i];
            yield return new WaitForSeconds(0.04f);
        }
        yield return new WaitForSeconds(0.4f);
        rsprites.sprite = idl;
        yield return null;
    }
}
