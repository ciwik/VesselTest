using UnityEngine;

public class EmitterController : MonoBehaviour
{
    private const float R = 0.4f;
    private const float R2 = R * R;
    private const float emitTime = 0.05f;
    private const int MaxParticleCount = 1000;

    public GameObject ParticlePrefab;

    private float Z;
    private int particleCount = 0;

    void Start()
    {
        Z = transform.position.z;
    }

    private float time = 0;
    void Update()
    {
        time += Time.deltaTime;
        if (time > emitTime)
        {
            if (particleCount < MaxParticleCount)
                CreateParticle();            
            time = 0;
        }
    }

    private void CreateParticle()
    {
        float x, y;
        x = Random.Range(-R, R);
        y = Random.Range(-1f, 1f) * Mathf.Sqrt(R2 - x * x);
        GameObject particle = (GameObject)Instantiate(ParticlePrefab, new Vector3(x, y, Z), Quaternion.identity);
        particle.GetComponent<ParticleController>().Emitter = this;
        particleCount++;        
    }

    public void DeleteParticle()
    {
        particleCount--;
    }
}
