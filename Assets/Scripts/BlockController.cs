using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    float speed = 25f;
    public float xMax = -5.5f;
    public float xMin = 5.5f;

    public float velocity = 0.2f;
    public static bool isGameEnd;
    // Start is called before the first frame update
    void Start()
    {
        isGameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameEnd)
        {
            /*float h = Input.acceleration.x * Time.deltaTime * velocity;
            if ((transform.position.x + h) > xMin && (transform.position.x + h) < xMax)
            {
                transform.Translate(h, 0, 0);
            }*/

            float h = Input.acceleration.x * speed*Time.deltaTime;
            print("Running");
            transform.Translate(h , 0, 0);
            if (transform.position.x>7.25f || transform.position.x<-7.25f) {
                Vector2 v = transform.position;
                v.x = Mathf.Clamp(v.x, -7.25f, 7.25f);
                transform.position = v;
            }


            /*if (transform.position.x - 0.2f >-5.5)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    print("Left Key");
                    transform.Translate(-0.2f, 0, 0);
                }
            }
            if (transform.position.x + 0.2f < 5.5)
            {
                print("Right Key");
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(0.2f, 0, 0);
                }
            }*/

        }
    }//update


}//class
