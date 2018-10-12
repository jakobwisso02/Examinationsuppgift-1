using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{


    // Variabler:

    // Skeppets färger
    public SpriteRenderer rend;
    public Color leftGreen;
    public Color rightBlue;
    public Color newColor;

    // Random färger
    public float red;
    public float green;
    public float blue;
    public Color randomColor;
    public SpriteRenderer shipRend;


    // Skeppets rörlighet
    public float rotationSpeedLeft = 150f; // Bestämmer värdet på variabeln som sedan blir hur snabbt man svänger vänster
    public float rotationSpeedRight = 300f; // Bestämmer värdet på variabeln som sedan blir hur snabbt man svänger höger
    public float shipSpeed; // En variabel som jag använder för att få en speed på mitt skepp 


    public float timer; // Skapar en variabel till timern
    public int timerCount; // Skapar en variabel till timern som ska 

    // Screen wrapping
    public Vector3 newPosition;

    // Random spawn
    public float ySpawn;
    public float xSpawn;
    public float randomSpawn;






    // Use this for initialization
    void Start()
    {

        shipSpeed = Random.Range(2f, 8f); // Randomiserar skeppets hastighet varje gång man startar spelet


        Vector2 randomSpawn; // Gör randomSpawn variabeln till en Vector med 2 dimensioner

        xSpawn = Random.Range(-8.3f, 8.3f); // Randomiserar värdet på variabeln xSpawn varje gång man startar spelet


        ySpawn = Random.Range(-4.25f, 4f); // Randomiserar värdet på variabeln ySpawn varje gång man startar spelet
                                           //^jag har ändrat 4.25f till 4f eftersom det var ett bugg att man spawnade för högt upp och fastade in en konstant screenwarps

        randomSpawn = new Vector2(xSpawn, ySpawn); // Gör randomSpawn variabeln till en Vector med x och y kordinater

        transform.position = randomSpawn; // Att positionen av skeppet sätts till en random spawn

    }

    // Update is called once per frame
    void Update()
    {

        // Gör så att skeppet svänger vänster och byter färg till grön på knapptryck A
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(0f, 0f, rotationSpeedLeft * Time.deltaTime); // Gör så att skeppet svänger vänster

            rend.color = leftGreen; // Renderar den gröna färgen på skeppet

        }

        // Gör så att skeppet svänger höger och byter färg till blå på knapptryck D
        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(0f, 0f, -rotationSpeedRight * Time.deltaTime); // Gör så att skeppet svänger höger

            rend.color = rightBlue; // Renderar den blåa färgen på skeppet

        }



        transform.Translate(shipSpeed * Time.deltaTime, 0f, 0f, Space.Self); // gör så att skeppet åker framåt automatiskt


        // Gör så att skeppets fart halveras om man trycker på knapptryck S
        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(-(shipSpeed / 2f) * Time.deltaTime, 0f, 0f, Space.Self); // tar speeden och halverar den

        }



        // Timer

        timer += 1 * Time.deltaTime; // Räknar tid per frame

        if (timer > timerCount) // Om timer är större än timerCount händer det som står i måsvingarna
        {

            timerCount += 1; // Lägger till +1 varje sekund

            print(timerCount); // Printar sekunderna

        }





        //random färg på space
        if (Input.GetKeyDown(KeyCode.Space)) // Om "Space" trycks ned så händer det som står inom måsvingarna nedan
        {

            red = Random.Range(0f, 1f); // Randomiserar värdet på röd färg
            green = Random.Range(0f, 1f); // Randomiserar värdet på grön färg
            blue = Random.Range(0f, 1f); // Randomiserar värdet på blå färg

            randomColor = new Color(red, green, blue); // Skapar en ny färg med de randomiserade RGB färgerna
            shipRend.color = randomColor; // Renderar den nya färgen på skeppet

        }


        //screen warping
        Vector2 newPosition = transform.position;

        if (newPosition.x > 8.5f || newPosition.x < -8.5f) // Gör så att när man når någon av de här kordinaterna på x axeln så händer det som står inom måsvingarna
        {

            newPosition.x -= newPosition.x * 2; // Säger till skeppet att flytta sig till kordinaterna mittemot där man åker in i "väggen" (x axeln)

        }

        if (newPosition.y > 4.5f || newPosition.y < -4.5f) // Gör så att när man når någon av de här kordinaterna på y axeln så händer det som står inom måsvingarna
        {

            newPosition.y -= newPosition.y * 2; // Säger till skeppet att flytta sig till kordinaterna mittemot där man åker in i "väggen" (y axeln)

        }

        transform.position = newPosition; // Att positionen av skeppet sätts till en ny position

    }

}
