using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1;
    private float timer = 0;
    [SerializeField] private GameObject[] pipe;
    [SerializeField] private float height;
    private int pointOfPrefabs;

    public bool isTest;

    private GameObject newpipe;

    private void Start()
    {
        isTest = false;

        pointOfPrefabs = Random.Range(0, pipe.Length);
        newpipe = Instantiate(pipe[pointOfPrefabs]);
        newpipe.transform.position = transform.position + new Vector3(10.5f, Random.Range(-height, height), 0);
    }

    private void Update()
    {
        if(isTest == true)
        {
            if(timer > maxTime)
            {
                pointOfPrefabs = Random.Range(0, pipe.Length);
                newpipe = Instantiate(pipe[pointOfPrefabs]);
                newpipe.transform.position = transform.position + new Vector3(10.5f, Random.Range(-height, height), 0);
                Destroy(newpipe, 15);
                timer = 0;
            }    
        
            timer += Time.deltaTime;
        }     
    }
}