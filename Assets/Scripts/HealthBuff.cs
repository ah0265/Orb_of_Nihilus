using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().health += amount;
        target.GetComponent<Player>().healthDisplay.text = target.GetComponent<Player>().health.ToString();
    }
    public void Update()
    {
        
    }
}
