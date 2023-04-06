using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public float speed; 
    public float maxSpeed = 1.5f;
    public float changeSpeed; 

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

        _meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(4);

        if(speed < maxSpeed)
        {
            speed += changeSpeed;       
            StartCoroutine(SpeedIncrease());
        }
    }
}
