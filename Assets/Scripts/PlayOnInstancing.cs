using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnInstancing : MonoBehaviour
{
    [SerializeField] 
    private AudioClip audioClip;
    [SerializeField, MinMaxSlider(0.0f, 1.0f)]
    private Vector2     volume = new Vector2(1.0f, 1.0f);
    [SerializeField, MinMaxSlider(0.0f, 2.0f)]
    private Vector2     pitch = new Vector2(1.0f, 1.0f);

    // Start is called before the first frame update
    void Awake()
    {
        SoundManager.PlaySound(audioClip, Random.Range(volume.x, volume.y), Random.Range(pitch.x, pitch.y));
        Destroy(this);
    }

}
