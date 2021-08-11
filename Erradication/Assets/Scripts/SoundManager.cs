using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace eradication
{
    public class SoundManager : MonoBehaviour
    {
        public AudioMixer mixer;

        public void SetLevel (float sliderValue)
        {
            mixer.SetFloat("BackgroundMusic", Mathf.Log10(sliderValue) * 20);
        }
    }
}
