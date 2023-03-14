using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Mars : MonoBehaviour
{
    public float speed;
    public int damage;
    public GameObject hit_effect;
    //public GameObject sound;

    private void Start()
    {
        //Instantiate(sound);
    }
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDam(damage);
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("Asteroid"))
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
