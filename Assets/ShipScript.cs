using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    //TODO: få screen warpingen att fungera



    //variabler:

    //skeppets färger
    public SpriteRenderer rend;
    public Color leftGreen;
    public Color rightBlue;
    public Color newColor;

    //random färger
    public float red;
    public float green;
    public float blue;
    public Color spaceColor;
    public SpriteRenderer shipRend;



    //skeppets rörlighet
    [Range(-720, 720)]
    public float rotationSpeedLeft = 150f;

    [Range(-720, 720)]
    public float rotationSpeedRight = 300f;
    public float shipSpeed;

    //timer
    public float timer;
    public int timerCount;



    //screen wrapping
    public Vector3 spawnPosition;
    public Vector3 shipPos;
    public Vector3 changePositionY;
    public Vector3 changePositionX;
    public Vector3 changePositionNegativeX;
    public Vector3 changePositionNegativeY;

    //random spawn
    public float ySpawn;
    public float xSpawn;


    // Use this for initialization
    void Start()
    {
        //randomiserar skeppets hastighet
        shipSpeed = Random.Range(2f, 8f);

        //randomiserar skeppets x axel spawn
        xSpawn = Random.Range(-8.35f, 8.35f);

        //randomiserar skeppets y axel spawn
        ySpawn = Random.Range(-4.5f, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {

        //gör så att skeppet svänger vänster och byter färg till grön på knapptryck A
        if (Input.GetKey(KeyCode.A))
        {

            //styrning
            transform.Rotate(0f, 0f, rotationSpeedLeft * Time.deltaTime);

            //färg
            rend.color = newColor;
            rend.color = leftGreen;

        }

        //gör så att skeppet svänger höger och byter färg till blå på knapptryck D
        if (Input.GetKey(KeyCode.D))
        {

            //styrning
            transform.Rotate(0f, 0f, -rotationSpeedRight * Time.deltaTime);

            //färg
            rend.color = newColor;
            rend.color = rightBlue;

        }


        //gör så att skeppet åker framåt automatiskt
        transform.Translate(shipSpeed * Time.deltaTime, 0f, 0f, Space.Self);


        //gör så att skeppets fart halveras med knapptryck
        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(-(shipSpeed / 2f) * Time.deltaTime, 0f, 0f, Space.Self);

        }



        //timer

        timer += 1 * Time.deltaTime;

        if (timer > timerCount)
        {

            timerCount += 1; //lägger till 1 varje sekund

            print(timerCount); //printar sekunderna

        }


        //ej klart
        if (shipPos.y >= 5.35f)
        {
            changePositionNegativeY.y = -5.35f;
        }

        if (shipPos.y >= -5.35f)
        {
            changePositionY.y = 5.35f;
        }

        if (shipPos.x >= 9.25f)
        {

        }

        if (shipPos.x >= -9.25f)
        {

        }




        //random färg på space
        if (Input.GetKeyDown(KeyCode.Space)) //läser av om space trycks ned
        {
            red = Random.Range(0f, 1f); //randomiserar värdet på röd färg
            green = Random.Range(0f, 1f); //randomiserar värdet på grön färg
            blue = Random.Range(0f, 1f); //randomiserar värdet på blå färg

            spaceColor = new Color(red, green, blue);
            shipRend.color = spaceColor;
        }
    }
}
