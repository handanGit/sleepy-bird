using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSC : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float flapStrenght;
    public bool birdIsAlive = true;
    public AudioSource flapSFX;
    public AudioSource hitSFX;
    //public GameObject birdShowcase;

    public logicSC logic;
    public movePipeSC pipe;
    public GroundScript ground;
    public pipeSpawnerSC pipeSpawn;
    
    [SerializeField] public float tiltingSpeed = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        //to access logicSC
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicSC>();
        pipe = GameObject.FindGameObjectWithTag("pipe").GetComponent<movePipeSC>();
        pipeSpawn = GameObject.FindGameObjectWithTag("pipeSpawner").GetComponent<pipeSpawnerSC>();
        //ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<GroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //to make bird gain altitude
        if (Input.GetMouseButtonDown(0) && birdIsAlive)
        {
            birdRigidBody.velocity = Vector2.up * flapStrenght;
            flapSFX.Play();
            
            //birdShowcase.SetActive(false);
        }
        
    }

    //to make bird tilting
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, birdRigidBody.velocity.y * tiltingSpeed);
        
    }

    //trigger game over screen after collide with pipe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //fade.fadeScreen();
        logic.gameOver();
        birdIsAlive = false;
        hitSFX.Play();
        Debug.Log("Game Stopped");
    }
}
