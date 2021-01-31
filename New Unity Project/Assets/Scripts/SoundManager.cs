using UnityEngine;
using UnityEngine.Audio; //引用 印效 API


public class SoundManager : MonoBehaviour
{
    [Header("音源管理")]
    public AudioMixer mixer;

    public void SFXVolume(float v)
    {
        mixer.SetFloat("SFXVolume", v);
    }

}
