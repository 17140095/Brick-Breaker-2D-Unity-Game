using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    int score = 0;
    public float speed = 0.2f;
    public GameObject GreenBrick;
    float VelocityX;
    float VelocityY;

    public int vref = 4;

    public Text scoreText;
    public Text gameOverText;
    public Canvas endCanvas;

    AudioSource[] sounds;
    AudioSource background;
    AudioSource win;
    AudioSource gameOver;
    AudioSource tic;
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        print(sounds.Length);
        background = sounds[3];
        gameOver = sounds[2];
        tic = sounds[1];
        win = sounds[0];

        rb = GetComponent<Rigidbody2D>();
        RandomVelocity(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BlockController.isGameEnd)
        {
            if (transform.position.y < -6)
            {
                gameOverText.text = "You Lose!";
                background.Stop();
                gameOver.Play();
                endCanvas.gameObject.SetActive(true);
                BlockController.isGameEnd = true;
            }
            if (GameObject.FindGameObjectsWithTag("Green").Length<=0 &&
                GameObject.FindGameObjectsWithTag("Red").Length<=0)
            {
                gameOverText.text = "You Win!";
                endCanvas.gameObject.SetActive(true);
                background.Stop();
                win.Play();
                BlockController.isGameEnd = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject col = collision.collider.gameObject;
        if (col.tag == "Green") {
            score++;
            tic.Play();
            Destroy(col);
        }
        if (col.name == "block") {
            RandomVelocity(Random.Range(-4,4));
        }
        if (col.tag == "Red") {
            GameObject.Instantiate(GreenBrick,col.transform.position,col.transform.rotation);
            score++;
            tic.Play();
            print("Red");
            Destroy(col);
        }
        scoreText.text = "Score: " + score;
        if (col.name == "Top")
        {
            //VelocityY = -vref;
            VelocityY = -1 * VelocityY;
            Vector3 vel = rb.velocity;
            vel.y = VelocityY;
            rb.velocity = vel;
        }
        if (col.name == "Left")
        {
            print("Left");
            XRandomVelocity(6);

        }
        if (col.name == "Right")
        {
            XRandomVelocity(-6);
            
        }

    }

    void XRandomVelocity(int rx) {
        VelocityX = rx;
        Vector3 vel = rb.velocity;
        vel.x = VelocityX;
        rb.velocity = vel * speed;

    }
    void RandomVelocity(int rx) {
        Vector3 v = rb.velocity;
        //v.x = Random.Range(-4, 4);
        v.x = rx;
        v.y = 6;
        VelocityX = v.x;
        VelocityY = v.y;
        rb.velocity = v * speed;
    }
    public void RestartGame() {
        endCanvas.gameObject.SetActive(false);
        BlockController.isGameEnd = false;
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
