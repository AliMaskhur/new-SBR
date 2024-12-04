using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nameplayer : MonoBehaviour
{
    public Text textNameplayer;
    public int scoreBulat;
    public float scorekoma;
    public GameObject panelEndGame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTextNameScore()
    {
        panelEndGame.SetActive(true);

        textNameplayer.text = InputName.namePlayer + " " + (scoreBulat.ToString() + "/" + scorekoma.ToString());
    }
}
