using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProJupiter : MonoBehaviour
{
	public float speed;
	public int damage;
	public GameObject hit_effect;
    public float percentage_minor;
    public float percentage_major;
    public GameObject PowerUp;
    public GameObject BigPowerUp;
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
		if(other.CompareTag("Enemy")){ 
			other.GetComponent<EnemyJupiter>().health-=damage;
			if (other.GetComponent<EnemyJupiter>().health == 0)
			{
				Death();
			}
			Instantiate(hit_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
        if (other.CompareTag("BigEnemy"))
        {
            other.GetComponent<EnemyJupiter>().health -= damage;
            if (other.GetComponent<EnemyJupiter>().health == 0)
            {
                BigDeath();
            }
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("Asteroid"))
        {
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void Death()
    {
        float rand = Random.Range(0f, 100f);
        if (rand < percentage_minor)
        {
            Instantiate(PowerUp, transform.position, Quaternion.identity);
        }
    }
    public void BigDeath()
    {
        float rand = Random.Range(0f, 100f);
        if (rand < percentage_major)
        {
            Instantiate(BigPowerUp, transform.position, Quaternion.identity);
        }
    }
}
