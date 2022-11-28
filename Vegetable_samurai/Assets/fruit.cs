using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    public GameObject FruitSliced;
    public float startForce = 15f;

    Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Blade")
        {
            Vector3 direction= (coll.transform.position-transform.position).normalized;

            Quaternion rotation=Quaternion.LookRotation(direction);

           GameObject SlicedFruit= Instantiate(FruitSliced, transform.position, rotation);
            Destroy(SlicedFruit,3f);
            Destroy(gameObject);
        }
    }
}
