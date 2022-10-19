using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private GameObject towerPrefab2;
    [SerializeField]
    private GameObject towerPrefab3;
    [SerializeField]
    private GameObject towerPrefab4;

    [SerializeField]
    private GameObject playerprefab1;
    [SerializeField]
    private GameObject playerprefab2;
    [SerializeField]
    private GameObject playerprefab3;
    [SerializeField]
    private GameObject playerprefab4;

    private TowerBehaviour selectedTower;




    // Start is called before the first frame update

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }

    public GameObject TowerPrefab2
    {
        get
        {
            return towerPrefab2;
        }
    }

    public GameObject TowerPrefab3
    {
        get
        {
            return towerPrefab3;
        }
    }

    public GameObject TowerPrefab4
    {
        get
        {
            return towerPrefab4;
        }
    }


    public GameObject Player1
    {
        get
        {
            return playerprefab1;
        }
    }

 public GameObject Player2
{
    get
        {
        return playerprefab2;
    }
}

public GameObject Player3
{
    get
        {
        return playerprefab3;
    }
}

public GameObject Player4
{
    get
        {
        return playerprefab4;
    }
}


    void Start()
    {
        
    }

 


    // Update is called once per frame
    void Update()
    {
        
    }
}
