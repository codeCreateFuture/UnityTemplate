using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


	public class ItemToggleGroup : MonoBehaviour {
	    public ToggleGroup toggleGroup;
	
	    public Toggle[] toggles;
	
	    private void Awake()
	    {
	        toggles = GetComponentsInChildren<Toggle>();
	        toggleGroup = GetComponent<ToggleGroup>();
	        for(int i=0;i<toggles.Length;i++)
	        {
	            toggles[i].group = toggleGroup;
	            toggles[i].onValueChanged.AddListener(OnValueChange);
	        }
	        ExecuteEvents.Execute<ISubmitHandler>(toggles[0].gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
	    }
	
	    private void OnValueChange(bool arg0)
	    {
	        if (!arg0) return;
	        foreach (var item in toggleGroup.ActiveToggles())
	        {
	            if (item.isOn)
	            {
	                switch (item.name)
	                {
	                    case "on":
	                        Debug.Log("on");
	                        break;
	                    default:
	                        Debug.Log(item.name);
	                        break;
	                }
	            }
	        }
	    }
	
		
	}

