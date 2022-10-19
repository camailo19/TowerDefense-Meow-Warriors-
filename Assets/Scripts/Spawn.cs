using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject prefabtype;
    // Start is called before the first frame update
    bool spawnit=false;
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        /*      if (Input.GetMouseButtonDown(0))
              {
                 
        */

  
        if (Input.GetMouseButtonDown(0) && spawnit)
        {
            var pos = Input.mousePosition;
            Vector3 spawnposition = Camera.main.ScreenToWorldPoint(pos);
         GameObject   g = Instantiate(prefabtype, (Vector2)spawnposition, Quaternion.identity);
            spawnit = false;   
        }

    }


    public void SpawnObject()
    {
        spawnit = true;        

    }
}
