using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BigEnemy : MonoBehaviour
{
   

	public float speed;
	private Rigidbody2D rb;
	public float stoppingDistance;
	public float retreatDistance;
	private Transform player;

	public int health;

	private float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject scorePopUp;
	public GameObject projectile;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = this.GetComponent<Rigidbody2D>();	
		timeBtwShots = startTimeBtwShots;
	}
	private void Swarm()
	{
		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90;
        direction.Normalize();
    }

	private void Update()
	{
		if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
		{
			Swarm();
		}
		else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
			transform.position = this.transform.position;
        }
		else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
		}


		if (timeBtwShots <=0)
        {
			Instantiate(projectile, transform.position, transform.rotation);
			timeBtwShots = startTimeBtwShots;
        }
		else
        {
			timeBtwShots -= Time.deltaTime;
        }



		if (health <= 0){

            GameObject instance = Instantiate(scorePopUp, transform.position, Quaternion.identity);
            int randScoreBonus = 5;
            player.GetComponent<Player>().score += randScoreBonus;
            instance.GetComponentInChildren<TextMeshProUGUI>().text = "+" + randScoreBonus;
            Destroy(gameObject);
		}


	}

	
}
