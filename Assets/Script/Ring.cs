using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    public ParticleSystem pSystem;
    private ParticleSystem.Particle[] particleArray;
    public Gradient colorGradient;

    public float ringResolution = 500;
    public float minRadius = 4;
    public float maxRadius = 10;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
