using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UguiExtension
{
    public static bool Contains(this RectTransform transform, Vector2 position)
    {
        Vector3[] array = new Vector3[4];
        transform.GetWorldCorners(array);
        float x = array[0].x;
        float x2 = array[2].x;
        float y = array[3].y;
        float y2 = array[1].y;
        if (position.x >= x && position.x <= x2 && position.y >= y && position.y <= y2)
        {
            return true;
        }
        return false;
    }


    public static Bounds GetBounds(this RectTransform transform)
    {
        return RectTransformUtility.CalculateRelativeRectTransformBounds(transform);
    }

    public static bool Intersects(this RectTransform @this, RectTransform other, RectTransform root)
    {
        Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(root, @this);
        Bounds bounds2 = RectTransformUtility.CalculateRelativeRectTransformBounds(root, other);
        return bounds.Intersects(bounds2);
    }

}

public static class ImageExtension
{
    public static void Example()
    {
        var gameObject = new GameObject();
        var image1 = gameObject.AddComponent<Image>();

        image1.FillAmount(0.0f); // image1.fillAmount = 0.0f;
    }

    public static Image FillAmount(this Image selfImage, float fillamount)
    {
        selfImage.fillAmount = fillamount;
        return selfImage;
    }
}

public static class TextExtension
{
    public static void Example()
    {
        var gameObject = new GameObject();
        var txt = gameObject.AddComponent<Text>();

        txt.SetText("str");
    }

    public static Text SetText(this Text txt, string str)
    {
        txt.text = str;
        return txt;
    }

    public static Text SetText(this GameObject go, string str)
    {
        Text txt = go.GetComponent<Text>();
        if (txt == null) return null;
        txt.text = str;
        return txt;
    }

    public static Text SetText(this Transform tran, string str)
    {
        Text txt = tran.GetComponent<Text>();
        if (txt == null) return null;
        txt.text = str;
        return txt;
    }
}
