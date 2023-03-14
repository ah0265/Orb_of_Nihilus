using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    public float rotSpeed;
    public GameObject projectile;
    public Transform spawnPos;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public float speed;
    public int health;
    public TextMeshProUGUI healthDisplay;
    private float safeTime;
    public float startSafeTime;

    public int score;
    public TextMeshProUGUI scoreDisplay;

    public Animator hurtPanel;
    public GameObject damPopUp;

    public Animator cam;

    public GameObject losePanel;
    public bool isDead;

    private void Start()
    {
        healthDisplay.text = health.ToString();
    }

    private void Update()
    {
        Vector3 moveInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += speed * Time.deltaTime * moveInput.normalized;

        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }

        scoreDisplay.text = score.ToString();

        if (health <= 0)
        {
            losePanel.SetActive(true);
            speed = 0;
            isDead = true;
        }
        if(health == 0) {
            Destroy(gameObject);
        } 

        if (isDead != true)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, spawnPos.position, transform.rotation);
            }

            if (Input.GetMouseButton(0))
            {

                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, spawnPos.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }
    }

    public void TakeDam(int dam)
    {
        if (safeTime <= 0)
        {

            cam.SetTrigger("shake");

            GameObject instance = Instantiate(damPopUp, transform.position, Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = "-" + dam;
            hurtPanel.SetTrigger("hurt");
            health -= dam;
            healthDisplay.text = health.ToString();
            safeTime = startSafeTime;
        }

    }
}
