using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_create : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject portal;
    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<BigEnemy>().health <= 0)
        {
            Instantiate(portal, transform.position, Quaternion.identity);
        }
    }
}
