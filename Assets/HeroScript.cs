using Assets;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public SpriteRenderer mySpriteRenderer;
    public AudioSource myAudioSource;
    public float flapStrength;
    public LogicScript logicScript;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        //myRigidBody.gravityScale = 1.5f;      THAT'S DUMP!
        MovingScript.movingSpeed = 20;
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(HasExitedScreen() == true)
        {
            DeadHero();
        }
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        {
            myRigidBody.velocity = Vector2.up * flapStrength; //Vector2.up predstavlja vektor (0,1)   0 x osa, 1 y osa
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeadHero();
    }

    private bool HasExitedScreen()
    {
        return Mathf.Abs(transform.position.y) > 24;
    }

    private void DeadHero()
    {
        if(birdIsAlive == true)
        {
            birdIsAlive = false;
            myAudioSource.Stop();
            logicScript.GameOver();
            mySpriteRenderer.color = Color.HSVToRGB(100, 100, 100);
        }
    }
}
