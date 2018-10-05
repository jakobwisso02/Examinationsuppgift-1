using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    //TODO: få skeppet att ändra färg när jag svänger... Sedan C och A uppgifter...



    //variabler:

    //skeppets färger
    //public Color newColor;
    public SpriteRenderer rend;
    public Color leftGreen;
    public Color rightBlue;
    
    //= new Color(0.1f, 0.8f, 0.3f);    
    //= new Color(0.1f, 0.3f, 0.8f);


    //skeppets rörlighet
    [Range(-720, 720)]
    public float rotationSpeed = 320f;
    public float shipSpeed = 2f;
    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.A))
        {
            rend.color = leftGreen;
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rend.color = rightBlue;
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }


        /*if (Input.GetKey(KeyCode.A))
        {
            //rend.color = newColor;
            //rend.color = new Color(0.2f, 1f, 0.3f);

            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rend.color = newColor;
            //rend.color = new Color(0.2f, 0.3f, 1f);

            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }*/


        transform.Translate(shipSpeed * Time.deltaTime, 0f, 0f, Space.Self);

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-(shipSpeed - 1f) * Time.deltaTime, 0f, 0f, Space.Self);
        }

    }
}
