using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    // public float _animationSpeed = 1f;

    public float speed; 
    public float maxSpeed = 1.5f;
    public float changeSpeed; 

    // public float time;

    private void Awake() 
    {
        _meshRenderer = GetComponent<MeshRenderer>();    
    }
    private void Start() 
    {
        StartCoroutine(SpeedIncrease());
    }

    private void Update() 
    {
        // time += Time.deltaTime;
        // StartCoroutine(SpeedIncrease());
        // speed += Time.deltaTime * chengeSpeed; 

        _meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(4);

        if(speed < maxSpeed)
        {
            speed += changeSpeed;       
            // _meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
            StartCoroutine(SpeedIncrease());
        }
    }
}
