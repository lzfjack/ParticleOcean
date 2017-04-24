using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour {

    public ParticleSystem pSystem;
    private ParticleSystem.Particle[] particleArray;
    public Gradient colorGradient;

    public int seaResolution = 20;
    public float spacing = 0.5f;

    public float noiseScale = 0.2f;
    public float heightScale = 3f;

    private float perlinNoiseAnimX = 0.01f;
    private float perlinNoiseAnimY = 0.01f;

    // Use this for initialization
    void Start () {
        particleArray = new ParticleSystem.Particle[seaResolution * seaResolution];
        pSystem.maxParticles = seaResolution * seaResolution;
        pSystem.Emit(seaResolution * seaResolution);
        pSystem.GetParticles(particleArray);
	}

	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < seaResolution; i++) {
            for (int j = 0; j < seaResolution; j++) {
                float zPos = Mathf.PerlinNoise(i * noiseScale + perlinNoiseAnimX, j * noiseScale + perlinNoiseAnimY) * heightScale;
                particleArray[i * seaResolution + j].color = colorGradient.Evaluate(zPos);
                particleArray[i * seaResolution + j].position = new Vector3(i * spacing, zPos, j * spacing);
            }
        }

        perlinNoiseAnimX += 0.01f;
        perlinNoiseAnimY += 0.01f;

        pSystem.SetParticles(particleArray, particleArray.Length);
    }
}
