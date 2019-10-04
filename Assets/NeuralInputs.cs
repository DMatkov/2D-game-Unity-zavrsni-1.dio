using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NeuralInputs : MonoBehaviour
{

    private int velicinaPopulacije = 10;
    private int brojGeneracije = 0;
    private int[] layers = new int[] { 1, 10, 10, 1 };
    private List<NeuralNetwork> nets;
    

    public float CurrentFitness;
    public float MaxFitness = -2f;
    public float IgracX;
    public float IgracY;

    public int dx, dy;
    public int BoxRadius = 6;


    // Parametar po kojemu odredujemo uspjeh
    public float Fitness()
    {
        CurrentFitness = IgracX;
        if (CurrentFitness > MaxFitness)
        {
            MaxFitness = CurrentFitness;
        }

        return MaxFitness;

    }

    //pozicija na kojoj se nalazi igrac
    public void GetPozicije()
    {
        IgracX = gameObject.GetComponent<Rigidbody2D>().position.x;
        IgracY = gameObject.GetComponent<Rigidbody2D>().position.y;
    }

    //je li igrac na podu
    public void ProvjeraNaPodu()
    {
        bool NaPodu = true;
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            NaPodu = false;
        }
    }

    //je li igrac mrtav
    public void ProvjeraMrtav()
    {
        bool IgracJeMrtav = false;
        if (gameObject.GetComponent<Rigidbody2D>().position.y < -2.0143f)
        {
            IgracJeMrtav = true;
        }
    }

    //Update every frame -----------------------------------------
    void Update()
    {
        GetPozicije();
        Fitness();
        tileChecking();
    }
    //------------------------------------------------------------

    public void GetInputs() {

    }

    public void tileChecking() { 

        for(float i = IgracX-2; i <= IgracX+2; i++) {
            for(float j = IgracY-2; j <= IgracY+2; j++) {
                if(i != IgracX || j != IgracY) { //ignorira centar, poziciju igraca
                    Debug.Log("wa: ");
                }
            }
        }
    }

    public void GetTile()
    {

    }

    /*
    public void getInputs()
    {
        GetPozicije();
        //sprites = getSprites();
        int[] inputs = { };

        for (dy = -BoxRadius * 16; dy > (BoxRadius * 16); dy += 16)
        {
            for (dx = -BoxRadius * 16; dx > (BoxRadius * 16); dx += 16)
            {
                inputs[inputs.Length+1] = 0;
                int tile = GetTile(dx, dy);

                if (tile == 1 && IgracY +dy < 0x1B0) 
                {
                    inputs[inputs.Length] = 1;
                }

               
            }
        }
      //return inputs;
    }*/
}
