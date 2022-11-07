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
    GameObject lasttower;
    string[] matlist;
    string[] matlist2;
    string[] matlist3;
    string myFilePath, fileName; string myFilePath2, fileName2; string myFilePath3, fileName3; string myFilePath4, fileName4;
    string txtDocumentName;
    string txtDocumentName2;
    string txtDocumentName3;
    string txtDocumentName4;
    public bool isplaying=false;





    private TowerBehaviour myTower;

    List<Vector3> paths = new List<Vector3>();
    List<Vector3> positionxy = new List<Vector3>();

    List<GameObject> towers = new List<GameObject>();
    List<GameObject> towersloads = new List<GameObject>();
    List<GameObject> players = new List<GameObject>();


    int qtoweri;
    int qtowerii;
    int qtoweriii;
    int qplayeri;
    int qplayerii;
    int qplayeriii;
    int qplayeriv;



    List<Vector3> lasttowerposition = new List<Vector3>();

    List<int>  towertype = new List<int>();

    float timeofplaying=0.0f;
    float nexttime=0.0f;




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

            if (Enemies.enemies.Count == 1 )
            {
                nexttime = Time.time;

                File.AppendAllText(txtDocumentName4, "\n ----------Resultado--------------");
                File.AppendAllText(txtDocumentName4, "\n");
                File.AppendAllText(txtDocumentName4, "\n Ganaron los gatos con "+Allies.allies.Count+"unidades restantes y un tiempo de "+(nexttime-timeofplaying));
                File.AppendAllText(txtDocumentName4, "\n");

                matlist3 = new string[20];
                Debug.Log("Ganaron los players");
                //matlist3[0] = "Nueva Partida";
                //matlist3[1] = "Los gatos son los ganadores con: "+Allies.allies.Count+" unidades restantes";
                File.AppendAllText(txtDocumentName4, "\n");
                File.AppendAllText(txtDocumentName3, "\n ----------Nueva Partida--------------");
                File.AppendAllText(txtDocumentName4, "\n");
                File.AppendAllText(txtDocumentName3, "\n ganaron los gatos, slay");
                File.AppendAllText(txtDocumentName4, "\n");
                isplaying = false;
                Load();
            }


            if (Allies.allies.Count == 0)
            {
                nexttime = Time.time;
                matlist3 = new string[20];
                Debug.Log("Ganaron los towers");
                //  matlist3[0] = "Nueva Partida";
                //  matlist3[1] = "Las torres son los ganadores con: " + Enemies.enemies.Count + " unidades restantes";
                File.AppendAllText(txtDocumentName4, "\n");
                File.AppendAllText(txtDocumentName4, "\n ----------Resultado--------------");
                File.AppendAllText(txtDocumentName4, "\n");
                File.AppendAllText(txtDocumentName4, "\n Ganaron las torres con " + Enemies.enemies.Count + "unidades restantes y un tiempo de " + (nexttime - timeofplaying));
                File.AppendAllText(txtDocumentName4, "\n");
                File.AppendAllText(txtDocumentName3, "\n ----------Nueva Partida--------------");
                File.AppendAllText(txtDocumentName3, "\n ganaron las torres");

                isplaying = false;
                Load();
            }
            
        }

    }

    public void CreateTextFile()
    {
        txtDocumentName = Application.streamingAssetsPath + "/Chat_Logs/" + "Jugadores" + ".txt";
        txtDocumentName2 = Application.streamingAssetsPath + "/Chat_Logs/" + "Torres" + ".txt";
        txtDocumentName3 = Application.streamingAssetsPath + "/Chat_Logs/" + "GanadoryPerdedor" + ".txt";
        txtDocumentName4 = Application.streamingAssetsPath + "/Chat_Logs/" + "Historial de Batalla" + ".txt";
    }


    public void delete()
    {
 

        foreach (var objects in towers)
        {
            Enemies.enemies.Remove(objects);
            Destroy(objects);
        }


    }

    public void deletePlayers()
    {


        foreach (var objects in players)
        {
            Allies.allies.Remove(objects);
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
        RandomVOIPosition2();
        RandomPlacePlayer();
        timeofplaying = Time.time;
        isplaying = true;
    }

    public void CSV()
    {



    }





    public void startagain()
    {
        deletePlayers();
        delete();
    }


    public void Load()
    {
        deletePlayers();
        delete();
        for (int i = 0; i < lasttowerposition.Count; i++)
        {

            if (towertype[i] == 0)
            {
                lasttower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab, lasttowerposition[i], Quaternion.identity);
                towersloads.Add(lasttower);
                towers.Add(lasttower);
        
            }


            if (towertype[i] == 2)
            {
                lasttower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab2, lasttowerposition[i], Quaternion.identity);
                towersloads.Add(lasttower);
                towers.Add(lasttower);
            }


            if (towertype[i] == 3)
            {
                lasttower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab3, lasttowerposition[i], Quaternion.identity);
                towersloads.Add(lasttower);
                towers.Add(lasttower);
            }


            if (towertype[i] == 4)
            {
                lasttower = (GameObject)Instantiate(GameManager.Instance.TowerPrefab4, lasttowerposition[i], Quaternion.identity);
                towersloads.Add(lasttower);
                towers.Add(lasttower);
            }
        }
        RandomPlacePlayer();
        timeofplaying = Time.time;
        isplaying = true;
    }

    public void deletelastTowerPosition()
    {
        foreach (var objects in towersloads)
        {
            Destroy(objects);
        }
    }



    public void RandomPlacePlayer()
    {
        File.AppendAllText(txtDocumentName4, "\n");
        File.AppendAllText(txtDocumentName4, "\n ----------Nueva Partida--------------");
        File.AppendAllText(txtDocumentName4, "\n");
        File.AppendAllText(txtDocumentName4, "\n ----------Formación Jugadores--------------");
        File.AppendAllText(txtDocumentName4, "\n");
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

                    File.AppendAllText(txtDocumentName4, "\n "+" Posición: "+ positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador);


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
                    File.AppendAllText(txtDocumentName4, "\n " + " Posición: " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador);

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
                    File.AppendAllText(txtDocumentName4, "\n " + " Posición: " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador);

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
                    File.AppendAllText(txtDocumentName4, "\n " + " Posición: " + positionxy[randomPositionPlayer] + " Tipo de Jugador: " + tipodejugador);
                }



            }
         
           


        }
             matlist[contador] = "Numero de Jugadores: " + contjugadores; 
            File.WriteAllLines(txtDocumentName, matlist);
        File.AppendAllText(txtDocumentName4, "\n " + "Numero de Jugadores: " + contjugadores);

    }


    public void RandomVOIPosition2()
    {
        File.AppendAllText(txtDocumentName4, "\n");
        File.AppendAllText(txtDocumentName4, "\n ----------Formación Torres--------------");
        File.AppendAllText(txtDocumentName4, "\n");
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
       towertype.Add(0);
       lasttowerposition.Add(new Vector3(-17.9f, 0.9f, 0.0f));

        towers.Add(maintower);

        File.AppendAllText(txtDocumentName4, "\n"+"Posición  (-17.9,0.9,0.0)"+"Tipo de Torre: Principal");


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
                    towertype.Add(2);
                    lasttowerposition.Add(paths[randomNum]);
                    tipodetorre = "Torre 1";
                    matlist2[contador] = " Posición " + paths[randomNum] + " Tipo de Torre: " + tipodetorre;
                    File.AppendAllText(txtDocumentName4, "\n Posición " + paths[randomNum] + "Tipo de Torre:" + tipodetorre);

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

                    towertype.Add(3);
                    lasttowerposition.Add(paths[randomNum]);
                    tipodetorre = "Torre 2";
                    matlist2[contador] = " Posición " + paths[randomNum] + " Tipo de Torre: " + tipodetorre;
                    File.AppendAllText(txtDocumentName4, "\n Posición " + paths[randomNum] + "Tipo de Torre:" + tipodetorre);
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


                    lasttowerposition.Add(paths[randomNum]);
                    towertype.Add(4);
                    tipodetorre = "Torre 3";
                    matlist2[contador] = " Posición " + paths[randomNum] + " Tipo de Torre: " + tipodetorre;
                    File.AppendAllText(txtDocumentName4, "\n Posición " + paths[randomNum] + "Tipo de Torre:" + tipodetorre);
                    contador++;


                }

              
            }

        }

        matlist2[contador] = "\n Numero de Torres: " + conttorres;
        File.WriteAllLines(txtDocumentName2, matlist2);
        File.AppendAllText(txtDocumentName4, "\n Número de Torres: "+ conttorres);


    }




}