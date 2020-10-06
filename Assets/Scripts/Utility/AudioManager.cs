using UnityEngine;

[System.Serializable]
public class Sound{
    public string name;
    public AudioClip clip;
    [Range(0,1)]
    public float volume = 0.7f;
    [Range(0.5f,1.5f)]
    public float pitch = 1f;
    [Range(0f, 0.5f)]
	public float randomVolume = 0.1f;
	[Range(0f, 0.5f)]
	public float randomPitch = 0.1f;
    public bool loop = false;
    private AudioSource source;
    public void SetSource(AudioSource _source){
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void Play(){
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
		source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    Sound[] sounds;
    void Awake(){
        instance = this;
        if(instance ==null){
            Debug.LogError("cant find the script panic panic panic");
        }
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_"+i+"_"+sounds[i].name);
            _go.transform.SetParent(this.transform);
            AudioSource source = _go.AddComponent<AudioSource>();
            sounds[i].SetSource(source);
        }
    }

    private void Start()
    {
        PlaySound("Theme");
    }


    public void PlaySound(string _name){
        foreach (var sound in sounds)
        {
            if(sound.name == _name){
                sound.Play();
                return;
            }
        }
        Debug.LogWarning("Audio manager sound not found in sounds array "+_name);
    }

}
