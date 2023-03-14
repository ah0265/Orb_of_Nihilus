using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff_Jupiter : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerShip_Jupiter>().health += amount;
        target.GetComponent<PlayerShip_Jupiter>().healthDisplay.text = target.GetComponent<Player>().health.ToString();
    }
    public void Update()
    {
        
    }
}
