using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpforce;
    public Text countText;          
    public Text winText;
    public Text livesText;
    public bool win;
    public AudioSource effectSource;
    public GameObject peck;

    private int count;
    private int lives;
    private bool dirRight;
    
    public Transform teleportPoint;
    public Camera cam;
    public Animator anim;

    // Use this for initialization
    void Start () {
        peck.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        SetCountText();
        SetLivesText();
        winText.text = "";
        win = false;
        dirRight = true;
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //physics
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

        anim.SetFloat("speed", Mathf.Abs(moveHorizontal));

        //sprite flipper
        if (dirRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (dirRight == true && moveHorizontal < 0)
        {
            Flip();
        }



        //peck attack
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isPecking", true);
            peck.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            peck.SetActive(false);
            anim.SetBool("isPecking", false);
        }

    }

    private void Flip()
    {
        dirRight = !dirRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    //jump
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Platform")
        {
            anim.SetBool("isJumping", false);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2 (0, jumpforce), ForceMode2D.Impulse);
                effectSource.Play();
                anim.SetBool("isJumping", true);
            }
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    //pickups and enemies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        } else if (other.gameObject.CompareTag("Enemy") && peck.activeInHierarchy == false)
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
        else if (other.gameObject.CompareTag("Enemy") && peck.activeInHierarchy == true)
        {
            other.gameObject.SetActive(false);
        }

    
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count == 4)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            //this.gameObject.transform.position = teleportPoint.position;
            if (currentScene.name == "Barn_1")
            {
                SceneManager.LoadScene("Barn_2", LoadSceneMode.Single);
            }
            else if (currentScene.name == "Barn_2")
            {
                SceneManager.LoadScene("Win_Screen", LoadSceneMode.Single);
            }
            
            lives = 3;
            SetLivesText();
        }

        if (count >= 8)
        {
            winText.text = "You win!";
            win = true;
        }
            
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            //winText.text = "You lose!";
            //gameObject.SetActive(false);
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
        }
 
    }
}
