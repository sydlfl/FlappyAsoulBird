using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Audio Manager,store all audios as well as play and stop 
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Store single audio
    /// </summary>
    
    [System.Serializable]

    public class Sound
    {
        [Header("AudioClip")]
        public AudioClip clip;

        [Header("AudioGroup")]
        public AudioMixerGroup outputGroup;

        [Header("AudioVolume")]
        [Range(0, 1)]
        public float volume = 1;

        [Header("isAwake")]
        public bool playOnAwake;

        [Header("isLoop")]
        public bool loop;
    }

    /// <summary>
    /// Store all audios
    /// </summary>
    public List<Sound> sounds;

    /// <summary>
    /// Name of every audoClip matches an AudioSource
    /// </summary>
    private Dictionary<string, AudioSource> audiosDic;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audiosDic = new Dictionary<string, AudioSource>();
        }
    }

    private void Start()
    {
        foreach(var sound in sounds)
        {
            GameObject obj = new GameObject(sound.clip.name);
            obj.transform.SetParent(transform);

            AudioSource source = obj.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.playOnAwake = sound.playOnAwake;
            source.loop = sound.loop;
            source.volume = sound.volume;
            source.outputAudioMixerGroup = sound.outputGroup;

            if (sound.playOnAwake)
            {
                source.Play();
            }

            audiosDic.Add(sound.clip.name, source);
        }
    }

    /// <summary>
    /// Play audioClip(NoWaiting)
    /// </summary>
    /// <param name="name">AudioClipName</param>
    /// <param name="isWait">isWait</param>
    public static void PlayAudio(string name,bool isWait = false)
    {
        if (!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"{name}audio not exists");
            return;
        }

        if (isWait)
        {
            if (!instance.audiosDic[name].isPlaying)
            {
                instance.audiosDic[name].Play();
            }
        } else
        {
            instance.audiosDic[name].Play();
        }
    }

    /// <summary>
    /// Stop AudioClip
    /// </summary>
    /// <param name="name">AudioClipName</param>
    public static void StopAudio(string name)
    {
        if (!instance.audiosDic.ContainsKey(name))
        {
            Debug.LogWarning($"{name}audio not exists");
            return;
        }

        instance.audiosDic[name].Stop();
    }

    public static void PlayRandomAudio(string[] names, bool isWait = false)
    {
        string name = names[Random.Range(0, names.Length)];
        PlayAudio(name, isWait);
    }
}
