using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float deliveryDelay = .5f;
    [SerializeField] Color hasPackageColor = new Color(1, 1, 1, 1);
    [SerializeField] Color noPackageColor = new Color(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    bool hasPackage;
    void OnCollisionEnter2D(Collision2D other) 
    {
            Debug.Log("Watch out, bucko!");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked Up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, deliveryDelay);
        }
        else if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
