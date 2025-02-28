using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public GameObject player;
    public AudioSource wingFlap;
    public AudioSource collideSound;

    public int JumpForce = 10;

    public LogicScript logic;
    public bool Alive = true;
    public int Boundary = 16;
    public bool dyingPlay = false;
    public GameObject GoUpWing;
    public GameObject GoDownWing;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Alive){
            Jump();
            wingFlap.Play();
            GoUpWing.SetActive(true);
            GoDownWing.SetActive(false);
            Invoke("Falling", 0.2f);
        }
        if((transform.position.y > Boundary || transform.position.y < (Boundary * -1)) && dyingPlay == false){
            logic.gameOver();
            Alive = false;
            collideSound.Play();
            dyingPlay = true;
        }
    }
    void Falling(){
        GoUpWing.SetActive(false);
        GoDownWing.SetActive(true);
    }
    void Jump(){
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * JumpForce;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Alive = false;
        collideSound.Play();
    }

}
