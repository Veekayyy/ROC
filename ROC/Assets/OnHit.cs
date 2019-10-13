using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{

    public GameObject effet;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effetG = Instantiate(effet, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effetG, 1f);



    }
}
