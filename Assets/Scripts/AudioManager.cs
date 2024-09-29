using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject bgmObject;
    public GameObject effectObject;

    [Header("#BGM")] // 배경음
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    // 게임이 멈춰 있을 떄 BGM이 들리는 것을 방지하기 위해
    // 일정 주파수의 음역대는 거르는 컴포넌트를 사용
    AudioHighPassFilter bgmEffect; 
    

    [Header("#SFX")] // 효과음
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum SFX
    {
        Dead, Hit, LevelUp = 3, Lose, Melee, Range = 7, Select, Win = 9 
    }

    private void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform; // AudioManger Object의 자식으로 위치시킨다.
        bgmPlayer = bgmObject.AddComponent<AudioSource>(); // AddComponent 함수로 오디오소스를 생성하고 변수에 저장
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SFXPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int i = 0; i < channels; i++) 
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].bypassListenerEffects = true;
            sfxPlayers[i].volume = sfxVolume;
        }

    }

    public void PlaySFX(SFX sfx)
    {
        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            // 채널 개수만큼 순회하도록 채털인덱스 변수 활용
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            int ranIndex = 0;
            if(sfx == SFX.Hit || sfx == SFX.Melee)
            {
                ranIndex = Random.Range(0, 2);
            }

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx + ranIndex];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void PlayBGM(bool isPlay)
    {
        if (isPlay)
            bgmPlayer.Play();

        else
            bgmPlayer.Stop(); 
    }

    public void EffectBGM(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }
}
