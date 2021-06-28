using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    public bool isHit = false;
    [SerializeField] GameObject bloodEffect;
    public Replay r1;
    public float currentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void takeDamage(float damage)
    {
        isHit = true;
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        Instantiate(bloodEffect, transform.position,Quaternion.Euler(35f,35f,35f),this.transform);
      //  Destroy(bloodEffect);
        if (currentHealth > 0)
        {
            isHit = false;
            //damage
        }
        else
        {        //kill
            Instantiate(bloodEffect);
            if (this.gameObject.tag == "Player")
            {
                this.gameObject.SetActive(false);
                r1.Setup();
               // Application.Quit();
            }
            else
            this.gameObject.SetActive(false);
        }

    }
}
