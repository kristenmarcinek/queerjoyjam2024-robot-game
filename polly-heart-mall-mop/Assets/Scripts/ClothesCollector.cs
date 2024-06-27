using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesCollector : MonoBehaviour
{
    [field: Header("Particle Collecting")]
    public ParticleSystem ps;
    List<ParticleSystem.Particle> clothes = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleTrigger()
    {
        int triggeredParticles = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, clothes);

        for (int i = 0; i < triggeredParticles; i++)
        {
            ParticleSystem.Particle p = clothes[i];
            p.remainingLifetime = 0;
            Debug.Log("collect");
            clothes[i] = p;

        }


        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, clothes);

    }
}
