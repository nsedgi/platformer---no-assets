using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image healthbarTotal;
    [SerializeField] private Image healthbarCurrent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthbarCurrent.fillAmount = playerHealth.currentHealth/playerHealth.startingHealth;
    }
}
