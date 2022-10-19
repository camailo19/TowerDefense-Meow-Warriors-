using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{


    // Start is called before the first frame update
    [SerializeField] private int range;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float timeBetweenShots;
    private GameObject currentTarget;
    private float nextTimeToShoot;
    public float healthbar;
    public GameObject healthBar;
    private Transform target;
    [SerializeField] private float health;


   private Rigidbody2D rb;

    private void Awake()
    {
        Allies.allies.Add(gameObject);
    }



    void Start()
    {
        target = ChooseTarget();
        nextTimeToShoot = Time.time;
        rb = GetComponent<Rigidbody2D>();
        health = healthbar;
    }

    public void ishit(float damage)
    {
        health -= damage;
    }


        // Update is called once per frame
        void Update()
    {
        updateNearestEnemy();
        if (Time.time >= nextTimeToShoot)
        {
            if (currentTarget != null)
            {
                attack();


                nextTimeToShoot = Time.time + timeBetweenShots;
            }
        }

        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
        else
        {
            target = ChooseTarget();
        }


        DamagePlayer();

        if (health <= 0)
        {
            Allies.allies.Remove(gameObject);
            Destroy(gameObject);
        } 
    }


    private void updateNearestEnemy()
    {
        GameObject currentNearestEnemy = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies.enemies)
        {
            if (enemy != null)
            {
                float _distance = (transform.position - enemy.transform.position).magnitude;

                if (_distance < distance)
                {
                    distance = _distance;
                    currentNearestEnemy = enemy;
                }
            }


        }
        if (distance <= range)
        {
            currentTarget = currentNearestEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }








    private void FixedUpdate()
    {
        
    }




    public Transform ChooseTarget()
    {
        GameObject[] chooseTower = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (chooseTower.Length == 0)
            return null;

        closest = chooseTower[0].transform;
        for (int i = 1; i < chooseTower.Length; ++i)
        {
            float distance = (chooseTower[i].transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                closest = chooseTower[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }





    private void attack()
    {
        TowerBehaviour enemyScript = currentTarget.GetComponent<TowerBehaviour>();
        enemyScript.ishit(damage);
    }


    public void DamagePlayer()
    {
        healthBar.transform.localScale = new Vector3(health /healthbar, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }




}
