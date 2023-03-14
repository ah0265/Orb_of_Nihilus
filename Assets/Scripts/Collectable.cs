using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;

public class Collectable : MonoBehaviour
{
    public GameObject scorePopUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject instance = Instantiate(scorePopUp, transform.position, Quaternion.identity);
            int randScoreBonus = 1;
            other.GetComponent<PlayerShip_Jupiter>().score += randScoreBonus;
            instance.GetComponentInChildren<TextMeshProUGUI>().text = "+" + randScoreBonus;
        }
    }

    
}
