using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJupiter : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
	private int flag=0;
	public int count;

    public GameObject[] enemies;
	public Transform spawnPos;

	private PlayerShip_Jupiter player;

	private void Start()
	{
		player = FindObjectOfType<PlayerShip_Jupiter>();
		timeBtwSpawn = startTimeBtwSpawn;
	}

	private void Update()
	{
		if(timeBtwSpawn <= 0 && player.isDead == false && flag<count){
			int randEnemy = Random.Range(0, enemies.Length);
			Instantiate(enemies[randEnemy], spawnPos.position, Quaternion.identity);
			timeBtwSpawn = startTimeBtwSpawn;
			flag++;
		} else{ 
			timeBtwSpawn -= Time.deltaTime;		
		}
	}
}
