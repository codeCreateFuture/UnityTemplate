using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIEventWithAudio : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {

    public AudioClip enterClip;
    public AudioClip clickClip;
    public AudioClip exitClip;

    protected AudioSource m_AudioSource;
    // Use this for initialization
    void Start()
    {
        m_AudioSource = this.transform.parent.GetComponent<AudioSource>();
        if (m_AudioSource == null)
        {
            m_AudioSource = this.transform.parent.gameObject.AddComponent<AudioSource>();
            m_AudioSource.playOnAwake = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.PlayAudio(this.clickClip);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.PlayAudio(this.enterClip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.PlayAudio(this.exitClip);
    }

    //播放音乐
    private void PlayAudio(AudioClip ac)
    {
        if (ac == null)
        {
            //Debug.LogError(this.name + ":audioClip is Null !");
        }
        this.m_AudioSource.PlayOneShot(ac);
    }
}
