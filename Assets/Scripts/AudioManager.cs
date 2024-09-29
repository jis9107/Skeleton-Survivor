using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject bgmObject;
    public GameObject effectObject;

    [Header("#BGM")] // �����
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    // ������ ���� ���� �� BGM�� �鸮�� ���� �����ϱ� ����
    // ���� ���ļ��� ������� �Ÿ��� ������Ʈ�� ���
    AudioHighPassFilter bgmEffect; 
    

    [Header("#SFX")] // ȿ����
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
        // ����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform; // AudioManger Object�� �ڽ����� ��ġ��Ų��.
        bgmPlayer = bgmObject.AddComponent<AudioSource>(); // AddComponent �Լ��� ������ҽ��� �����ϰ� ������ ����
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        // ȿ���� �÷��̾� �ʱ�ȭ
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
            // ä�� ������ŭ ��ȸ�ϵ��� ä���ε��� ���� Ȱ��
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
