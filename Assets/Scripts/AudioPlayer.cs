using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume;
    
    [Header("Damage")] 
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume;

    private static AudioPlayer _instance;
    
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }
    
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null) return;
        
        Vector3 camPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, camPos, volume);
    }
}
