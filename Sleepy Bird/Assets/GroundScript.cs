using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] public float groundSpeed = 1f;
    [SerializeField] private float groumdWidth = 6f;

    private SpriteRenderer ground;

    private Vector2 startSize;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<SpriteRenderer>();
        startSize = new Vector2(ground.size.x, ground.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        ground.size = new Vector2(ground.size.x + groundSpeed * Time.deltaTime, ground.size.y);

        if (ground.size.x > groumdWidth)
        {
            ground.size = startSize;
        }
    }
}
