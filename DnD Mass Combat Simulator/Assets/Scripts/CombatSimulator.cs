using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatSimulator : MonoBehaviour
{
    public int attackers;
    public int playerAC;
    public int attackDamageDie;
    public int attackDamageDieCount;
    public int attackersToHit;
    public int averageDamage;

    public TextMeshProUGUI attackersOutput;
    public TextMeshProUGUI damageOutput;
    public TextMeshProUGUI averageDamageOutput;
    
    int howManyHit;
    int totalDMG;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MassCombatSimulator();
        }
    }

    public void MassCombatSimulator()
    {
        howManyHit = 0;
        totalDMG = 0;
        averageDamage = 0;

        for (int i = 0; i < attackers; i++)
        {
            int dieRoll = Random.Range(1, 20);

            if (dieRoll + attackersToHit >= playerAC)
            {
                howManyHit++;

                totalDMG = totalDMG + (Random.Range(1, attackDamageDie) * attackDamageDieCount);
                averageDamage = totalDMG / howManyHit;
            }

        }

        attackersOutput.text = howManyHit.ToString();
        averageDamageOutput.text = averageDamage.ToString();
        damageOutput.text = totalDMG.ToString() + "!";

    }


}

