using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormScale : MonoBehaviour {
    private static FormScale instance;public static FormScale Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }


    public void m_OpenForm(Transform openTransform)
    {
        openTransform.gameObject.SetActive(true);
        StartCoroutine(OpenForm(openTransform, 0.4f));
    }

    IEnumerator OpenForm(Transform openTransform,float scalexyz)
    {
        scalexyz += 0.1f;
        openTransform.localScale = new Vector3(scalexyz, scalexyz, scalexyz);
        yield return new WaitForSeconds(0.02f);
        if (scalexyz < 1.0f)
        {
            StartCoroutine(OpenForm(openTransform, scalexyz));
        }
    }


    public void m_CloseForm(Transform closeTransform)
    {
        closeTransform.gameObject.SetActive(true);
        StartCoroutine(CloseForm(closeTransform, 1f));
    }

    IEnumerator CloseForm(Transform closeTransform, float scalexyz)
    {
        scalexyz -= 0.1f;
        closeTransform.localScale = new Vector3(scalexyz, scalexyz, scalexyz);
        yield return new WaitForSeconds(0.02f);
        if (scalexyz > 0.4f)
        {
            StartCoroutine(CloseForm(closeTransform, scalexyz));
        }
        else
        {
            closeTransform.gameObject.SetActive(false);
        }
    }

    public void ClearFormChild(Transform form)
    {
        for(int i = 0; i < form.childCount; i++)
        {
            Destroy(form.GetChild(i).gameObject);
        }
    }

}
