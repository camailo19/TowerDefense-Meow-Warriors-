using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;

public class ClickController : MonoBehaviour
{
    public PositionPoint ClickPosition { get; private set; }
    GameObject maintower;
    GameObject newtower;
    GameObject playerX;
    string[] matlist;
    string[] matlist2;
    string[] matlist3;
    string myFilePath, fileName; string myFilePath2, fileName2; string myFilePath3, fileName3;
    string txtDocumentName;
    string txtDocumentName2;
    string txtDocumentName3;
    public bool isplaying=false;





    private TowerBehaviour myTower;



    List<Vector3> paths = new List<Vector3>();
    List<Vector3> positionxy = new List<Vector3>();

    List<GameObject> towers = new List<GameObject>();
    List<GameObject> players = new List<GameObject>();


    List<GameObject> lasttowerposition = new List<GameObject>();





    private void Start()

    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Chat_Logs/");
        CreateTextFile();


        paths.Add(new Vector3(-17.9f, 0.9f, 0.0f));
        paths.Add(new Vector3(-15.3f, 0.9f, 0.0f));
        paths.Add(new Vector3(-17.9f, 3.4f, 0.0f));
        paths.Add(new Vector3(-15.3f, 3.4f, 0.0f));
        paths.Add(new Vector3(-12.7f, 3.4f, 0.0f));
        paths.Add(new Vector3(-12.7f, 0.9f, 0.0f));
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
    void Update()
    {
       
        if (isplaying == true)
        {
            Debug.Log("Estoy revisando");
            Debug.Log("Valor Restante Torres:"+ Enemies.enemies.Count);
            Debug.Log("Valor Restante Jugadores:"+Allies.allies.Count);



            if (Enemies.enemies.Count == 0 )
            {
                matlist3 = new string[20];
                Debug.Log("Ganaron los players");
                matlist3[0] = "Los gatos son los ganadores con: "+Allies.allies.Count+" unidades restantes";
                File.WriteAllLines(txtDocumentName3, matlist3);
                isplaying = false;
            }


            if (Allies.allies.Count == 0)
            {
                matlist3 = new string[20];
                Debug.Log("Ganaron los towers");
                matlist3[0] = "Las torres son los ganadores con: " + Enemies.enemies.Count + " unidades restantes";
                File.WriteAllLines(txtDocumentName3, matlist3);
                isplaying = false;

            }
            
        }

    }

    public void CreateTextFile()
    {
        txtDocumentName = Application.streamingAssetsPath + "/Chat_Logs/" + "Jugadores" + ".txt";
        txtDocumentName2 = Application.streamingAssetsPath + "/Chat_Logs/" + "Torres" + ".txt";
        txtDocumentName3 = Application.streamingAssetsPath + "/Chat_Logs/" + "GanadoryPerdedor" + ".txt";

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

    public void start()
    {
        deletePlayers();
        delete();
        RandomVOIPosition2();
        RandomPlacePlayer();
        isplaying = true;
    }



    public void startagain()
    {
        deletePlayers();
        delete();
    }


    public void calllastTowerPosition()
    {
        foreach (var objectss in lasttowerposition)
        {
            Debug.Log(objectss);
        }
    }

    public void deletelastTowerPosition()
    {
        foreach (var objects in lasttowerposition)
        {
            Destroy(objects);
        }
    }



    public void RandomPlacePlayer()
    {

        int contjugadores = 0;
        int maxcostplayer = 36;
        int randomPositionPlayer;
        int quantity = 20;
        int contador = 0;
        matlist = new string[quantity];
        string tipodejugador="";


        List<int> numerospositionpoll = new List<int>();

        while (maxcostplayer >= 2 && contjugadores <= 18)
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
                    tipodejugador = "Gato Guerrero";

                    numerospositionpoll.Add(randomPositionPlayer);
                    players.Add(playerX);
                    
                    matlist[contador] = " Posición " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador;
                    contador++;
                    contjugadores++;
                }

                if (randomPlayerType == 2 && maxcostplayer >= 5)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player2, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 5;
                    tipodejugador = "Gato Gobernante";

                    numerospositionpoll.Add(randomPositionPlayer);
                    players.Add(playerX);
                    
                    matlist[contador] = " Posición " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador;
                    contador++;
                    contjugadores++;
                }

                if (randomPlayerType == 3 && maxcostplayer >= 2)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player3, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 2;
                    tipodejugador = "Gato Cazador";

                    numerospositionpoll.Add(randomPositionPlayer);
                    players.Add(playerX);
                    
                    matlist[contador] = " Posición " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador;
                    contador++;
                    contjugadores++;
                }

                if (randomPlayerType == 4 && maxcostplayer >= 5)
                {
                    playerX = (GameObject)Instantiate(GameManager.Instance.Player4, positionxy[randomPositionPlayer], Quaternion.identity);
                    playerX.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    maxcostplayer = maxcostplayer - 5;
                    tipodejugador = "Gato Mago";

                    numerospositionpoll.Add(randomPositionPlayer);
                    players.Add(playerX);
                   
                    matlist[contador] = " Posición " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador;
                    contador++;
                    contjugadores++;
                }



            }
         
           


        }
             matlist[contador] = "Numero de Jugadores: " + contjugadores; 
            File.WriteAllLines(txtDocumentName, matlist);

    }


    public void RandomVOIPosition2()
    {
        int contprecio = 50;
        int randomNum;
        int conttorres = 0;
        List<int> numeros = new List<int>();
        numeros.Add(0);
        maintower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab, new Vector3(-17.9f, 0.9f, 0.0f), Quaternion.identity);
        maintower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
        int quantity = 8;
        int contador = 0;
        matlist2 = new string[quantity];
        string tipodetorre = "";

        lasttowerposition.Add(maintower);


        while (contprecio >= 5 && conttorres < 8)
        {
            randomNum = Random.Range(1, 9);

            if (numeros.Contains(randomNum) != true)
            {
                int randomTower;
                randomTower = Random.Range(1, 4);
                if (randomTower == 1 && contprecio >= 5)
                {
                    newtower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab2, paths[randomNum], Quaternion.identity);
                    newtower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    contprecio = contprecio - 5;
                    numeros.Add(randomNum);
                    towers.Add(newtower);
                    conttorres++;

                    lasttowerposition.Add(newtower);
                    tipodetorre = "Torre 1";
                    matlist2[contador] = " Posición " + paths[randomNum] + " Tipo de Torre: " + tipodetorre;
                    contador++;
                }

                if (randomTower == 2 && contprecio >= 10)
                {
                    newtower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab3, paths[randomNum], Quaternion.identity);
                    newtower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    contprecio = contprecio - 10;
                    numeros.Add(randomNum);
                    towers.Add(newtower);
                    conttorres++;


                    lasttowerposition.Add(newtower);
                    tipodetorre = "Torre 2";
                    matlist2[contador] = " Posición " + paths[randomNum] + " Tipo de Torre: " + tipodetorre;
                    contador++;

                }


                if (randomTower == 3 && contprecio >= 15)
                {
                    newtower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab4, paths[randomNum], Quaternion.identity);
                    newtower.GetComponent<SpriteRenderer>().sortingOrder = ClickPosition.Y;
                    contprecio = contprecio - 15;
                    numeros.Add(randomNum);
                    towers.Add(newtower);
                    conttorres++;

                    lasttowerposition.Add(newtower);

                    tipodetorre = "Torre 3";
                    matlist2[contador] = " Posición " + paths[randomNum] + " Tipo de Torre: " + tipodetorre;
                    contador++;


                }

              
            }

        }

        matlist2[contador] = "\n Numero de Torres: " + conttorres;
        File.WriteAllLines(txtDocumentName2, matlist2);



    }




}