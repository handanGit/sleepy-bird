using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSC : MonoBehaviour
{

    [SerializeField] private CanvasGroup fadingGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    public float alphaValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fadeScreen()
    {
        fadingGroup.alpha += Time.deltaTime;
        if(fadingGroup.alpha >= 1)
        {
            fadingGroup.alpha -= Time.deltaTime;
        }
    }
}
