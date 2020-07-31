using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// 字符串类帮助类
/// </summary>
public static class StringUtils
{


    //HexToColor(7ecef4);
    /// <summary>
    /// 颜色转换到字符串
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ColorToHex(Color color)
    {
        int r = Mathf.RoundToInt(color.r * 255.0f);
        int g = Mathf.RoundToInt(color.g * 255.0f);
        int b = Mathf.RoundToInt(color.b * 255.0f);
        int a = Mathf.RoundToInt(color.a * 255.0f);
        string hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
        return hex;
    }

    /// <summary>
    /// hex转换到color
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static Color HexToColor(string hex)
    {
        byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        float r = br / 255f;
        float g = bg / 255f;
        float b = bb / 255f;
        float a = cc / 255f;
        return new Color(r, g, b, a);
    }


    //StringToColor(7ecef4);
    public static Color StringToColor(string colorStr)
    {
        if (string.IsNullOrEmpty(colorStr))
        {
            return new Color();
        }
        int colorInt = int.Parse(colorStr, System.Globalization.NumberStyles.AllowHexSpecifier);
        return IntToColor(colorInt);
    }
    public static Color IntToColor(int colorInt)
    {
        float basenum = 255;

        int b = 0xFF & colorInt;
        int g = 0xFF00 & colorInt;
        g >>= 8;
        int r = 0xFF0000 & colorInt;
        r >>= 16;
        return new Color((float)r / basenum, (float)g / basenum, (float)b / basenum, 1);

    }



    /// <summary>
    /// 字符串转换成其他类型
    /// </summary>
    /// <typeparam name="T">基础类型</typeparam>
    /// <param name="str"></param>
    /// <returns></returns>
    public static T StringTo<T>(string str)where T:struct
    {
        //if (typeof(T) == typeof(int))
        //{ }
        //else if (typeof(T) == typeof(double))
        //{ }

        T ret = (T)Convert.ChangeType(str, typeof(T));
        return ret;
    }
    /// <summary>
    /// 字符串转成byte[]
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static byte[] GetBytes(string str)
    {
      return  Encoding.UTF8.GetBytes(str);
    }

    /// <summary>
    /// byte 数组转换成字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetString(byte[] bytes)
    {
      return   Encoding.UTF8.GetString(bytes);
    }


	/// <summary>
	/// MD5 String
	/// </summary>
	/// <returns>
	public static string MD5(string str)
	{
		byte [] b = Encoding.Default.GetBytes(str);
		MD5 md5 = new MD5CryptoServiceProvider();
		byte [] c = md5.ComputeHash(b);
		return System.BitConverter.ToString(c).Replace("-","");
	}
	
	

	/// <summary>
	/// 对Vector3整体保留几位小数
	/// </summary>
	/// <param name="vec"></param>
	/// <param name="decimals">小数位数</param>
	/// <returns></returns>
	public static Vector3 Vector3ToRound(Vector3 vec, int decimals)
	{
		float x = (float)Math.Round(vec.x, decimals);
		float y = (float)Math.Round(vec.y, decimals);
		float z = (float)Math.Round(vec.z, decimals);
		return new Vector3(x, y, z);
	}

	/// <summary>
	/// 对Vector2整体保留几位小数
	/// </summary>
	/// <param name="vec"></param>
	/// <param name="decimals">小数位数</param>
	/// <returns></returns>
	public static Vector2 Vector2ToRound(Vector2 vec, int decimals)
	{
		float x = (float)Math.Round(vec.x, decimals);
		float y = (float)Math.Round(vec.y, decimals);
		return new Vector2(x, y);
	}

	/// <summary>
	/// 根据概率获取随机数是否随机到
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static bool OnProbability(float value)
	{
		if (value >= 1)
			return true;

		if (value <= 0)
			return false;

		byte[] bytes = new byte[4];
		System.Security.Cryptography.RNGCryptoServiceProvider rng = 
			new System.Security.Cryptography.RNGCryptoServiceProvider();
		rng.GetBytes(bytes);
		int seed = BitConverter.ToInt32(bytes, 0);

		System.Random random = new System.Random(seed);
		int randomValue = random.Next(100);
		if (randomValue < value * 100)
		{
			return true;
		}

		return false;
	}

	/// <summary>
	/// 根据秒数获取时间字符串
	/// </summary>
	/// <param name="second"></param>
	/// <returns></returns>
	public static string GetStringBySecond(long second)
	{
		long minute = (second / 60) % 60;
		long hour = (second / 3600) % 24;
		long day = second / (3600*24);
		long sec = second % 60;
		string timeStr = "";

		bool hasD = false, hasH = false, hasM = false, hasS = false;

		if (day > 0)
		{
			hasD = true;
			timeStr += day + "天";
		}

		if (!hasD && hour == 0)
		{
		}
		else
		{
			hasH = true;
			if (hour <= 9 && hasD == true && hour > 0)
			{
				timeStr += "0" + hour + "时";
			}
			else if(hour > 0)
			{
				timeStr += hour + "时";
			}
		}

		if (!hasD)
		{
			if (!hasD && !hasH && minute == 0)
			{
			}
			else
			{
				hasM = true;
				if (minute <= 9 && hasH == true && minute > 0)
				{
					timeStr += "0" + minute + "分";
				}
				else if(minute > 0)
				{
					timeStr += minute + "分";
				}
			}
		}

		if (!hasH)
		{
			if (!hasD && !hasH && !hasM && sec == 0)
			{
			}
			else
			{
				hasS = true;
				if (sec <= 9 && hasM == true && sec > 0)
				{
					timeStr += "0" + sec + "秒";
				}
				else if(sec > 0)
				{
					timeStr += sec + "秒";
				}
			}
		}


		return timeStr;
	}

	/// <summary>
	/// 获取key 和value 对应字符串
	/// </summary>
	/// <param name="keyValue"></param>
	/// <param name="key"></param>
	/// <param name="value"></param>
	/// <param name="split"></param>
	/// <returns></returns>
	public static bool KeyValue(string keyValue, out string key, out string value,char split='=')
	{
		bool ret = false;
		int mark = 0;
		for(int i = 0; i < keyValue.Length; ++i)
		{
			if(keyValue[i] == split)
			{
				mark = i;
				ret = true;
				break;
			}
		}
		key = keyValue.Substring(0, mark);
		value = keyValue.Substring(mark+1, keyValue.Length - mark -1);
		return ret;
	}
	public static string PathToString(List<Vector2> path)
	{
		StringBuilder stringBuild = new StringBuilder();
		
		for (int i = 0; i < path.Count; ++i)
			{
			 stringBuild.Append(path[i].x); stringBuild.Append(',');
				stringBuild.Append(path[i].y); stringBuild.Append(',');
			}
		
		return stringBuild.ToString();
	}

	public static void ToPath(List<Vector2> path,string moveList)
	{
		if(moveList!= null && moveList.Length > 0)
		{
			path.Clear();
			string[] splits = moveList.Split(',');
			Vector2 vect;
			for (int i = 0; i < splits.Length -1; i+=2)
			{
				vect.x = Convert.ToSingle(splits[i]);
				vect.y = Convert.ToSingle(splits[i + 1]);
				path.Add(vect);
			}
		}
	}

	#region 类型转换处理

	/// <summary>
	/// 空字串
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static bool IsEmpty(string value)
	{
		return string.IsNullOrEmpty(value);
		//if (value == null || value.Length == 0)
		//    return true;

		//return false;
	}

	/// <summary>
	/// 是否是标示符
	/// </summary>
	/// <returns></returns>
	static public bool IsLegal(string value)
	{
		if (value == null || value.Length == 0)
			return false;
		bool ret= true;
		for (int i = 0; i < value.Length; ++i )
		{
			if (!(char.IsLetterOrDigit(value[i]) || value[i]=='_'))
				return false;
		}
		return ret;
	}
	/// <summary>
	/// 是否数字
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static bool IsNumeric(string value)
	{
		if (value == null || value.Length == 0)
			return false;
		bool ret = Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");

		if(!ret)
		{
		   // LogHelper.Inst.Log.InfoFormat(value + "IsNumber:" + ret);
		}
		return ret;
	}
	public static bool IsInt(string value)
	{
		if (value == null || value.Length == 0)
			return false;

		bool ret= Regex.IsMatch(value, @"^[+-]?\d*$");

		if (!ret)
		{
		  //  LogHelper.Inst.Log.InfoFormat(value + "IsInt:" + ret);
		}
		return ret;
	}
	public static bool IsUnsign(string value)
	{
		if (value == null || value.Length == 0)
			return false;
		return Regex.IsMatch(value, @"^\d*[.]?\d*$");
	}
	#endregion
}

