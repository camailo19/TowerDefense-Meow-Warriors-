using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickController : MonoBehaviour
{
    public PositionPoint ClickPosition { get; private set; }
    GameObject maintower;
    GameObject newtower;
    GameObject playerX;

    private TowerBehaviour myTower;
     


    List<Vector3> paths = new List<Vector3>();
    List<Vector3> positionxy = new List<Vector3>();

    List<GameObject> towers = new List<GameObject>();
    List<GameObject> players = new List<GameObject>();






    private void Start()

    {
        paths.Add(new Vector3(-15.3f, 0.9f, 0.0f));
        paths.Add(new Vector3(-17.9f, 3.4f, 0.0f));
        paths.Add(new Vector3(-15.3f, 3.4f, 0.0f));
        paths.Add(new Vector3(-12.7f, 3.4f, 0.0f));
        paths.Add(new Vector3(-12.7f, 0.9f, 0.0f));
        paths.Add(new Vector3(-17.9f, 0.9f, 0.0f));
        paths.Add(new Vector3(-12.7f, -1.6f, 0.0f));
        paths.Add(new Vector3(-15.3f, -1.6f, 0.0f));
        paths.Add(new Vector3(-17.9f, -1.6f, 0.0f));


        positionxy.Add(new Vector3(-3.2f, 4.25f, 0.0f));
        positionxy.Add(new Vector3(-3.2f, 3.0f, 0.0f));
        positionxy.Add(new Vector3(-3.2f, 0.5f, 0.0f));
        positionxy.Add(new Vector3(-3.2f, -0.75f, 0.0f));
        positionxy.Add(new Vector3(-3.2f, -2.0f, 0.0f));
        positionxy.Add(new Vector3(-3.2f, -3.25f, 0.0f));
   //     positionxy.Add(new Vector3(-3.2f, -4.5f, 0.0f));

        positionxy.Add(new Vector3(-1.9f, 4.25f, 0.0f));
        positionxy.Add(new Vector3(-1.9f, 3.0f, 0.0f));
        positionxy.Add(new Vector3(-1.9f, 0.5f, 0.0f));
        positionxy.Add(new Vector3(-1.9f, -0.75f, 0.0f));
        positionxy.Add(new Vector3(-1.9f, -2.0f, 0.0f));
        positionxy.Add(new Vector3(-1.9f, -3.25f, 0.0f));
    //    positionxy.Add(new Vector3(-1.9f, -4.5f, 0.0f));

        positionxy.Add(new Vector3(-0.6f, 4.25f, 0.0f));
        positionxy.Add(new Vector3(-0.6f, 3.0f, 0.0f));
        positionxy.Add(new Vector3(-0.6f, 0.5f, 0.0f));
        positionxy.Add(new Vector3(-0.6f, -0.75f, 0.0f));
        positionxy.Add(new Vector3(-0.6f, -2.0f, 0.0f));
        positionxy.Add(new Vector3(-0.6f, -3.25f, 0.0f));
       // positionxy.Add(new Vector3(-0.6f, -4.5f, 0.0f));



    }
     void Update() {
        
        
    }



    public void delete()
    {
        Destroy(maintower);

        foreach (var objects in towers)
        {
            Destroy(objects);
        }


    }

    public void deletePlayers()
    {
        

        foreach (var objects in players)
        {
            Destroy(objects);
        }


    }






    public void Setup(PositionPoint ClickPos, Vector3 worldPos, Transform parent)
    {
        this.ClickPosition = ClickPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(ClickPos, this);
    }

    private void OnMouseOver()
    {
       
    }



    public void RandomPlacePlayer()
    {

        int contjugadores = 0;
        int maxcostplayer = 36;
        int randomPositionPlayer;

        List<int> numerospositionpoll = new List<int>();

        while (maxcostplayer >= 2 && contjugadores < 18)
        {
            randomPositionPlayer = Random.Range(0, 18);

            if (numerospositionpoll.Contains(randomPositionPlayer) != true)
            {
                int randomPlayerType;
                randomPlayerType = Random.Range(1, 5);

                if (randomPlayerType == 1 && maxcostplayer >= 2)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player1, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 2;
                }

                if (randomPlayerType == 2 && maxcostplayer >= 10)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player2, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 10;
                }

                if (randomPlayerType == 3 && maxcostplayer >= 4)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player3, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 4;
                }

                if (randomPlayerType == 4 && maxcostplayer >= 5)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player4, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 5;
                }


                numerospositionpoll.Add(randomPositionPlayer);
                players.Add(playerX);
                contjugadores++;

            }

        }
    }


    public void RandomVOIPosition2()
    {
        int contprecio = 50;
        int randomNum;
        int conttorres = 0;
        List<int> numeros = new List<int>();
        numeros.Add(0);
        maintower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab, new Vector3(-15.3f, 0.9f, 0.0f), Quaternion.identity);
        maintower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;

        while (contprecio>=5 && conttorres<8)
        {
           randomNum = Random.Range(1, 9);

            if(numeros.Contains(randomNum) != true)
            {
                int randomTower;
                randomTower = Random.Range(1, 4);
                if (randomTower == 1 && contprecio >= 5)
                {
                    newtower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab2, paths[randomNum], Quaternion.identity);
                    newtower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    contprecio = contprecio - 5;
                }

                if (randomTower == 2 && contprecio >= 10)
                {
                    newtower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab3, paths[randomNum], Quaternion.identity);
                    newtower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    contprecio = contprecio - 10;

                }


                if (randomTower == 3 && contprecio >= 15)
                {
                    newtower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab4, paths[randomNum], Quaternion.identity);
                    newtower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    contprecio = contprecio - 15;

                }

                               numeros.Add(randomNum);
                towers.Add(newtower);
                conttorres++;
            }

        }



    }

   
}