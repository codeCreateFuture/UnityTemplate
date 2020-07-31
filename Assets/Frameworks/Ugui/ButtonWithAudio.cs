using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonWithAudio : Button {

    public AudioClip enterClip;
    public AudioClip clickClip;
    public AudioClip exitClip;
    AudioSource m_AudioSource;

    protected override void Start()
    {
        base.Start();
        m_AudioSource = this.transform.parent.GetComponent<AudioSource>();
        if (m_AudioSource == null)
        {
            m_AudioSource = this.transform.parent.gameObject.AddComponent<AudioSource>();
            m_AudioSource.playOnAwake = false;
        }
    }

    //指针移入
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        this.PlayAudio(this.enterClip);
    }
    //指针退出
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        this.PlayAudio(this.exitClip);
    }
    //指针按下
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        this.PlayAudio(this.clickClip);
    }
    //播放声音
    private void PlayAudio(AudioClip ac)
    {
        if (ac == null)
        {
            //Debug.LogError(this.name + ":audioClip is Null !");
        }
        this.m_AudioSource.PlayOneShot(ac);
        this.m_AudioSource.clip = ac;
        m_AudioSource.Play();
    }
}
