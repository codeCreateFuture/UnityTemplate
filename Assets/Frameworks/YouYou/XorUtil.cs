
/// <summary>
/// 对字节数组进行异或处理
/// 异或加密的原理：把需要加密的数据或者文件转化成 字节数组 byte[]，然后对每一个字节byte和一个异或因子进行异或处理
///解密：对已经加密过的数据再进行一次异或(和加密时的异或因子要一样)处理就异或回原理的数据，相当于将原数据进行两次异或处理
/// </summary>
public sealed class XorUtil
{
    #region xorScale 异或因子
    /// <summary>
    /// 异或因子
    /// </summary>
    private static readonly byte[] xorScale = new byte[] { 45, 66, 38, 55, 23, 254, 9, 165, 90, 19, 41, 45, 201, 58, 55, 37, 254, 185, 165, 169, 19, 171 };//.data文件的xor加解密因子
    #endregion

    private XorUtil()
    {

    }
    /// <summary>
    /// 对字节数组进行异或
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static byte[] Xor(byte[] buffer)
    {       
        int iScaleLen = xorScale.Length;
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (byte)(buffer[i] ^250);
        }
        return buffer;
    }
}