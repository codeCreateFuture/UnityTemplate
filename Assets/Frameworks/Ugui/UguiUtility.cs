using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UguiUtility{

    public EventHandler UguiEvent;


  

   

    /// <summary>
    /// UGUI中按钮自动触发UI事件
    /// </summary>
    /// <param name="UguiGo">触发的ui</param>
    public static void AutoClick(GameObject UguiGo)
    {
        //调用会触发Button的按钮变色
        ExecuteEvents.Execute<ISubmitHandler>(UguiGo, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);

        //调用不会触发按钮变色
       // ExecuteEvents.Execute<IPointerClickHandler>(UguiGo, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
    }

    public static Sprite TextureToSpr(Texture texture)
    {
        Sprite spr;
        spr= Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return spr;
    }
}
