using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagger : Singleton<PlayerManagger>
{

   

    public PlayerBtn ClickedBtn { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickPlayer(PlayerBtn playerBtn)
    {
        this.ClickedBtn = playerBtn;
    }

    public void BuyPlayer()
    {
        ClickedBtn = null;
    }

}
