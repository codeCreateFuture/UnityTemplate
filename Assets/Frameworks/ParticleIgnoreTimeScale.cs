using UnityEngine;
using System.Collections;

public class ParticleIgnoreTimeScale : MonoBehaviour {

    ParticleSystem[] particles;
	// Use this for initialization
	void Awake () {
        particles = gameObject.GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < particles.Length; ++i)
        {
            particles[i].Simulate(Time.unscaledDeltaTime, true, false);
        }
	}
}
