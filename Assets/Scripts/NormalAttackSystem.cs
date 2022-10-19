using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackSystem : MonoBehaviour
{

    public Transform SwordController;
    public float SwordRadio;
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float timenextAttack;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Hit()
    {
       
        Collider2D[] Objectts = Physics2D.OverlapCircleAll(SwordController.position, SwordRadio);

        foreach (Collider2D collisioner in Objectts)
        {
            if (collisioner.CompareTag("Enemy"))
            {
             //   enemyComponent.ishit(damagehit);
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(SwordController.position, SwordRadio);

    }



}
