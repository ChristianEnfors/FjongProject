using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombatSimulator : MonoBehaviour
{
    public int attackers;
    public int playerAC;
    public int attackDamageDie;
    public int attackDamageDieCount;
    public int attackersToHit;

    public TextMeshProUGUI attackersOutput;
    public TextMeshProUGUI damageOutput;
    public TextMeshProUGUI averageDamageOutput;
    public TextMeshProUGUI noOfDieOutput;

    public GameObject inputParent;

    TMP_InputField attackersInput;
    TMP_InputField playerACInput;
    TMP_InputField attackersToHitInput;
    TMP_Dropdown attackDieInput;
    Slider noOfDiesInput;


    int averageDamage;
    int howManyHit;
    int totalDMG;

    private void Start()
    {
        attackersInput = inputParent.transform.GetChild(1).GetComponent<TMP_InputField>();
        playerACInput = inputParent.transform.GetChild(3).GetComponent<TMP_InputField>();
        attackDieInput = inputParent.transform.GetChild(5).GetComponent<TMP_Dropdown>();
        noOfDiesInput = inputParent.transform.GetChild(7).GetComponent<Slider>();
        attackersToHitInput = inputParent.transform.GetChild(10).GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MassCombatSimulator();
        }

        int.TryParse(attackersInput.text, out attackers);
        int.TryParse(playerACInput.text, out playerAC);
        int.TryParse(attackersToHitInput.text, out attackersToHit);

        string attackDamageDieString = attackDieInput.options[attackDieInput.value].text;
        attackDamageDie = int.Parse (attackDamageDieString.TrimStart('D'));

        attackDamageDieCount = (int)noOfDiesInput.value;
        noOfDieOutput.text = attackDamageDieCount.ToString();





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

