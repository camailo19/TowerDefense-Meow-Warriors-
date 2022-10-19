using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBtn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

  

    public GameObject PlayerPrefab
    {
        get
        {
            return playerPrefab;
        }
    }

}
