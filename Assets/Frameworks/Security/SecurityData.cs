using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SecurityData{

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="ciphertext">要解密的密文</param>
    /// <returns>解密后的明文</returns>
    public static string DecryptStr(string ciphertext)
    {

        string key = "330ead0b-4951-46a7-8db8-0e2569472fd1";

        byte[] bStr = (new UnicodeEncoding()).GetBytes(ciphertext);
        byte[] bKey = (new UnicodeEncoding()).GetBytes(key);//加密锁

        //异或解密
        for (int i = 0; i < bStr.Length; i += 2)
        {
            for (int j = 0; j < bKey.Length; j += 3)
            {
                bStr[i] = Convert.ToByte(bStr[i] ^ bKey[j]);
            }
        }
        //位移解密
        for (int i = 0; i < bStr.Length; i++)
        {
            byte b = (byte)(bStr[i] - 255);
            bStr[i] = b;
        }

        return (new UnicodeEncoding()).GetString(bStr).TrimEnd('\0');
    }

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="characters">要加密的明文</param>
    /// <returns>加密后的密文</returns>
    public static string EncryptStr(string characters)
    {
        string key = "330ead0b-4951-46a7-8db8-0e2569472fd1";

        //位移加密

        byte[] bStr = (new UnicodeEncoding()).GetBytes(characters);

        for (int i = 0; i < bStr.Length; i++)
        {
            byte b = (byte)(bStr[i] + 255);
            bStr[i] = b;
        }

        byte[] bKey = (new UnicodeEncoding()).GetBytes(key);//加密锁

        //异或加密
        for (int i = 0; i < bStr.Length; i += 2)
        {

            for (int j = 0; j < bKey.Length; j += 3)
            {
                bStr[i] = Convert.ToByte(bStr[i] ^ bKey[j]);
            }
        }
        return (new UnicodeEncoding()).GetString(bStr).TrimEnd('\0');
    }
}
