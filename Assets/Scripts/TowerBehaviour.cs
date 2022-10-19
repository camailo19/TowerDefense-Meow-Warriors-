using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{

  [SerializeField]  private float range;
  [SerializeField] private float damage;
  [SerializeField] private float timeBetweenShots;
    private GameObject currentTarget;
    private float nextTimeToShoot;

    public float healthbar;
    public GameObject healthBar;
    [SerializeField] private float health;

    private Transform target;
    private Rigidbody2D rb;



    private void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextTimeToShoot = Time.time;
        health = healthbar;
    }

    public void ishit(float damage)
    {
        health -= damage;
    }


    private void updateNearestAlly()
    {
        GameObject currentNearestAlly = null;
        float distance = Mathf.Infinity;

        foreach(GameObject ally in Allies.allies)
        {
            if(ally != null)
            {
                float _distance = (transform.position - ally.transform.position).magnitude;

                if (_distance < distance)
                {
                    distance = _distance;
                    currentNearestAlly = ally;
                }
            }


        }
        if(distance<= range)
        {
            currentTarget = currentNearestAlly;
        }
        else{
            currentTarget = null;
        }
    }


    private void Update()
    {
        updateNearestAlly();
        if(Time.time>= nextTimeToShoot)
        {
            if(currentTarget != null)
            {
                shoot();
                nextTimeToShoot = Time.time + timeBetweenShots;
            }
        }

        DamageTower();
        if (health <= 0)
        {
            Enemies.enemies.Remove(gameObject);
            Destroy(gameObject);
        }



    }


    private void shoot()
    {
           PlayerBehaviour allyScript = currentTarget.GetComponent<PlayerBehaviour>();
            allyScript.ishit(damage);
    }

    public void DamageTower()
    {
        healthBar.transform.localScale = new Vector3(health / healthbar, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }


}
