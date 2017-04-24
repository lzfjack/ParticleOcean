using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    public ParticleSystem pSystem;
    private ParticleSystem.Particle[] pArray;
    public Gradient colorGradient;

    public int ringParticleNum = 500;
    public float minRadius = 4;
    public float maxRadius = 10;
    public float speed = 1;

    private float[] pRadius;
    private float[] pAngle;


    // Use this for initialization
    void Start () {
        pArray = new ParticleSystem.Particle[ringParticleNum];
        pAngle = new float[ringParticleNum];
        pRadius = new float[ringParticleNum];
        pSystem.maxParticles = ringParticleNum;
        pSystem.Emit(ringParticleNum);
        pSystem.GetParticles(pArray);

        for (int i = 0; i < ringParticleNum; i++) {
            float angle = Random.Range(0f, 360f);

            float midRadius = (maxRadius + minRadius) / 2f;
            float minRate = Random.Range(1f, midRadius / minRadius);
            float maxRate = Random.Range(midRadius / maxRadius, 1f);
            float radius = Random.Range(minRadius * minRate, maxRadius * maxRate);

            pRadius[i] = radius;
            pAngle[i] = angle;
            pArray[i].position = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));

        }

        pSystem.SetParticles(pArray, ringParticleNum);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < ringParticleNum; i++) {
            if (i % 2 == 0) {
                pAngle[i] += Time.deltaTime * speed;
                pAngle[i] = pAngle[i] % 360;
            } else {
                pAngle[i] -= Time.deltaTime * speed;
                if (pAngle[i] < 0) {
                    pAngle[i] = 360;
                }
            }

            pArray[i].position = new Vector3(pRadius[i] * Mathf.Cos(pAngle[i]), pRadius[i] * Mathf.Sin(pAngle[i]));
        }

        pSystem.SetParticles(pArray, ringParticleNum);
	}
}
