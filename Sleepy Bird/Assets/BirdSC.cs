using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSC : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float flapStrenght;
    public logicSC logic;
    public movePipeSC pipe;
    public FadeSC fade;
    public GroundScript ground;
    public pipeSpawnerSC pipeSpawn;
    public bool birdIsAlive = true;
    [SerializeField] public float tiltingSpeed = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        //to access logicSC
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicSC>();
        pipe = GameObject.FindGameObjectWithTag("pipe").GetComponent<movePipeSC>();
        pipeSpawn = GameObject.FindGameObjectWithTag("pipeSpawner").GetComponent<pipeSpawnerSC>();
        //ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<GroundScript>();
        //fade = GameObject.FindGameObjectWithTag("fade").GetComponent<FadeSC>();
    }

    // Update is called once per frame
    void Update()
    {
        //to make bird gain altitude
        if (Input.GetMouseButtonDown(0) && birdIsAlive)
        {
            birdRigidBody.velocity = Vector2.up * flapStrenght;
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
        Debug.Log("Game Stopped");
    }
}
