using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float jumpStr=5f;
    bool birdCanFly = true;
    bool canStartAgain = false;
    GameObject GM;
    AudioSource _audio;
    public AudioClip _wings, _hit, _score;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.FindGameObjectWithTag("GMTag");
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        birdMov();
        restartGame();
    }

    void birdMov()
    {
        if (Input.GetMouseButtonDown(0) && birdCanFly)
        {
            rb.linearVelocity = (Vector2.up * jumpStr);
            _audio.PlayOneShot(_wings);
        }

        if (rb.linearVelocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
            }
        }
    }

    void restartGame()
    {
        if (canStartAgain)
        {
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="MiddlePipe")
        {
            GM.GetComponent<gameManagerScript>().addScore();
            _audio.PlayOneShot(_score);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="PipeTag")
        {
            Debug.Log("Gameover");
            birdCanFly=false;
            GetComponent<CircleCollider2D>().isTrigger = true;
            GM.GetComponent<gameManagerScript>()._gameOverText.enabled = true;
            canStartAgain = true;
            _audio.PlayOneShot(_hit);
        }
    }
}

