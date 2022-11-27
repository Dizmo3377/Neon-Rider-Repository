using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static GameObject[] particles;
    private void Awake()
    {
        GetData();
    }
    public static GameObject Create(string name, Vector2 position) 
    {
        for (int i = 0; i < particles.Length; i++)
        {
            if (particles[i].name.ToLower() == name.ToLower())
            {
                GameObject particle = Instantiate(particles[i], position, Quaternion.identity);
                ParticleSystem ps = particle.GetComponent<ParticleSystem>();
                ps.Play();
                return particle;
            }
        }
        return null;
    }

    public static GameObject Create(string name, Vector2 position, Quaternion quaternion)
    {
        for (int i = 0; i < particles.Length; i++)
        {
            if (particles[i].name.ToLower() == name.ToLower())
            {
                GameObject particle = Instantiate(particles[i], position, quaternion);
                ParticleSystem ps = particle.GetComponent<ParticleSystem>();
                ps.Play();
                return particle;
            }
        }
        return null;
    }

    private void GetData()
    {
        try
        {
            particles = Resources.LoadAll<GameObject>("Particles");
        }
        catch (System.NullReferenceException)
        {
            Debug.LogError("Error loading audio assets in ParticleManager. Folder is missing or something, idk");
            throw;
        }
    }
}