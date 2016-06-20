using UnityEngine;

public class ParticleController : MonoBehaviour {

    public float speed = -1.5f;
    public EmitterController Emitter;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, speed, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (transform.position.z < -6f)
        {
            Destroy(gameObject);
            Emitter.DeleteParticle();
        }
    }
}
