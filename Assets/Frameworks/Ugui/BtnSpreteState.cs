using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 动态设置按钮的转换状态
/// </summary>

public class BtnSpreteState : MonoBehaviour {


	string stateName = "_press";

	Button btn;
	Sprite highlightSpr;

	string highlightSprName = string.Empty;
	private void Awake()
	{
		btn = GetComponent<Button>();
		highlightSprName = GetComponent<Image>().sprite.name;
		highlightSprName += stateName;


		btn.transition = Selectable.Transition.SpriteSwap;
		highlightSpr = Resources.Load<Sprite>("keyPress/" + highlightSprName);

	}
	// Use this for initialization
	SpriteState btnState;
	void Start()
	{
		if (highlightSpr == null) return;
		btnState = new SpriteState();
		btnState.highlightedSprite = highlightSpr;
		btn.spriteState = btnState;
	}



	
}
