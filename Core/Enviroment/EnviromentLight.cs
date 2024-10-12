public class EnvironmentLight : MonoBehaviour
{
    public GameObject torchModel;   
    public Light torchLight;        
    public ParticleSystem fireEffect;  

    void Start()
    {
        fireEffect.Play();
    }

    void Update()
    {
        torchLight.intensity = Mathf.Lerp(1.0f, 1.5f, Mathf.PingPong(Time.time * 0.2f, 1));
    }
}
