using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
/// <summary>
/// ��֤�������䣬�ֻ��Ÿ�ʽ
/// </summary>
public class CheckInput {
    #region δ��֤���ƶ��ֻ�������֤������  

    

    ///// <summary>
    ///// ͨ��Framwork����е�Regex��ʵ����һЩ���⹦�����ݼ��
    ///// </summary>

    //private static CheckInput instance = null;
    //    public static CheckInput GetInstance()
    //    {
    //        if (CheckInput.instance == null)
    //        {
    //        CheckInput.instance = new CheckInput();
    //        }
    //        return CheckInput.instance;
    //    }
    //    private CheckInput()
    //    {
    //    }
    //    /// <summary>
    //    /// �ж�������ַ���ֻ��������
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsChineseCh(string input)
    //    {
    //        Regex regex = new Regex("^[\u4e00-\u9fa5]+$");
    //        return regex.IsMatch(input);
    //    }
    //    /// <summary>
    //    /// ƥ��3λ��4λ���ŵĵ绰���룬�������ſ�����С������������
    //    /// Ҳ���Բ��ã������뱾�غż���������ֺŻ�ո�����
    //    /// Ҳ����û�м��
    //    /// \(0\d{2}\)[- ]?\d{8}|0\d{2}[- ]?\d{8}|\(0\d{3}\)[- ]?\d{7}|0\d{3}[- ]?\d{7}
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsPhone(string input)
    //    {
    //        string pattern = "^\\(0\\d{2}\\)[- ]?\\d{8}$|^0\\d{2}[- ]?\\d{8}$|^\\(0\\d{3}\\)[- ]?\\d{7}$|^0\\d{3}[- ]?\\d{7}$";
    //        Regex regex = new Regex(pattern);
    //        return regex.IsMatch(input);
    //    }
    //    /// <summary>
    //    /// �ж�������ַ����Ƿ���һ���Ϸ����ֻ���
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsMobilePhone(string input)
    //    {
    //        Regex regex = new Regex("^13\\d{9}$");
    //        return regex.IsMatch(input);

    //    }


    //    /// <summary>
    //    /// �ж�������ַ���ֻ��������
    //    /// ����ƥ�������͸�����
    //    /// ^-?\d+$|^(-?\d+)(\.\d+)?$
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsNumber(string input)
    //    {
    //        string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
    //        Regex regex = new Regex(pattern);
    //        return regex.IsMatch(input);
    //    }
    //    /// <summary>
    //    /// ƥ��Ǹ�����
    //    ///
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsNotNagtive(string input)
    //    {
    //        Regex regex = new Regex(@"^\d+$");
    //        return regex.IsMatch(input);
    //    }
    //    /// <summary>
    //    /// ƥ��������
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsUint(string input)
    //    {
    //        Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");
    //        return regex.IsMatch(input);
    //    }
    //    /// <summary>
    //    /// �ж�������ַ����ְ���Ӣ����ĸ
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsEnglisCh(string input)
    //    {
    //        Regex regex = new Regex("^[A-Za-z]+$");
    //        return regex.IsMatch(input);
    //    }


    //    /// <summary>
    //    /// �ж�������ַ����Ƿ���һ���Ϸ���Email��ַ
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsEmail(string input)
    //    {
    //        string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    //        Regex regex = new Regex(pattern);
    //        return regex.IsMatch(input);
    //    }


    //    /// <summary>
    //    /// �ж�������ַ����Ƿ�ֻ�������ֺ�Ӣ����ĸ
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsNumAndEnCh(string input)
    //    {
    //        string pattern = @"^[A-Za-z0-9]+$";
    //        Regex regex = new Regex(pattern);
    //        return regex.IsMatch(input);
    //    }


    //    /// <summary>
    //    /// �ж�������ַ����Ƿ���һ��������
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsURL(string input)
    //    {
    //        //string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
    //        string pattern = @"^[a-zA-Z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";
    //        Regex regex = new Regex(pattern);
    //        return regex.IsMatch(input);
    //    }


    //    /// <summary>
    //    /// �ж�������ַ����Ƿ��Ǳ�ʾһ��IP��ַ
    //    /// </summary>
    //    /// <param name="input">���Ƚϵ��ַ���</param>
    //    /// <returns>��IP��ַ��ΪTrue</returns>
    //    public static bool IsIPv4(string input)
    //    {

    //        string[] IPs = input.Split('.');
    //        Regex regex = new Regex(@"^\d+$");
    //        for (int i = 0; i < IPs.Length; i++)
    //        {
    //            if (!regex.IsMatch(IPs[i]))
    //            {
    //                return false;
    //            }
    //            if (Convert.ToUInt16(IPs[i]) > 255)
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }


    //    /// <summary>
    //    /// �����ַ������ַ����ȣ�һ�������ַ���������Ϊ�����ַ�
    //    /// </summary>
    //    /// <param name="input">��Ҫ������ַ���</param>
    //    /// <returns>�����ַ����ĳ���</returns>
    //    public static int GetCount(string input)
    //    {
    //        return Regex.Replace(input, @"[\u4e00-\u9fa5/g]", "aa").Length;
    //    }

    //    /// <summary>
    //    /// ����Regex��IsMatch����ʵ��һ���������ʽƥ��
    //    /// </summary>
    //    /// <param name="pattern">Ҫƥ���������ʽģʽ��</param>
    //    /// <param name="input">Ҫ����ƥ������ַ���</param>
    //    /// <returns>���������ʽ�ҵ�ƥ�����Ϊ true������Ϊ false��</returns>
    //    public static bool IsMatch(string pattern, string input)
    //    {
    //        Regex regex = new Regex(pattern);
    //        return regex.IsMatch(input);
    //    }

    //    /// <summary>
    //    /// �������ַ����еĵ�һ���ַ���ʼ�����滻�ַ����滻ָ����������ʽģʽ������ƥ���
    //    /// </summary>
    //    /// <param name="pattern">ģʽ�ַ���</param>
    //    /// <param name="input">�����ַ���</param>
    //    /// <param name="replacement">�����滻���ַ���</param>
    //    /// <returns>���ر��滻��Ľ��</returns>
    //    public static string Replace(string pattern, string input, string replacement)
    //    {
    //        Regex regex = new Regex(pattern);
    //        return regex.Replace(input, replacement);
    //    }

    //    /// <summary>
    //    /// ����������ʽģʽ�����λ�ò�������ַ�����
    //    /// </summary>
    //    /// <param name="pattern">ģʽ�ַ���</param>
    //    /// <param name="input">�����ַ���</param>
    //    /// <returns></returns>
    //    public static string[] Split(string pattern, string input)
    //    {
    //        Regex regex = new Regex(pattern);
    //        return regex.Split(input);
    //    }
    //    /// <summary>
    //    /// �ж�������ַ����Ƿ��ǺϷ���IPV6 ��ַ
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static bool IsIPV6(string input)
    //    {
    //        string pattern = "";
    //        string temp = input;
    //        string[] strs = temp.Split(':');
    //        if (strs.Length > 8)
    //        {
    //            return false;
    //        }
    //        int count =GetStringCount(input, "::");
    //        if (count > 1)
    //        {
    //            return false;
    //        }
    //        else if (count == 0)
    //        {
    //            pattern = @"^([\da-f]{1,4}:){7}[\da-f]{1,4}$";

    //            Regex regex = new Regex(pattern);
    //            return regex.IsMatch(input);
    //        }
    //        else
    //        {
    //            pattern = @"^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$";
    //            Regex regex1 = new Regex(pattern);
    //            return regex1.IsMatch(input);
    //        }

    //    }

       

    //    /* *******************************************************************
    //    * 1��ͨ����:�����ָ��ַ������õ����ַ������鳤���Ƿ�С�ڵ���8
    //    * 2���ж������IPV6�ַ������Ƿ��С�::����
    //    * 3�����û�С�::������ ^([\da-f]{1,4}:){7}[\da-f]{1,4}$ ���ж�
    //    * 4������С�::�� ���ж�"::"�Ƿ�ֹ����һ��
    //    * 5���������һ������ ����false
    //    * 6��^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$
    //    * ******************************************************************/
    //    /// <summary>
    //    /// �ж��ַ���compare �� input�ַ����г��ֵĴ���
    //    /// </summary>
    //    /// <param name="input">Դ�ַ���</param>
    //    /// <param name="compare">���ڱȽϵ��ַ���</param>
    //    /// <returns>�ַ���compare �� input�ַ����г��ֵĴ���</returns>
        
    //    private static int GetStringCount(string input, string compare)
    //    {
    //        int index = input.IndexOf(compare);
    //        if (index != -1)
    //        {
    //            return 1 + GetStringCount(input.Substring(index + compare.Length), compare);
    //        }
    //        else
    //        {
    //            return 0;
    //        }

    //    }

      

   

    #endregion



   
        #region ƥ�䷽��
        /// <summary>  
        /// ��֤�ַ����Ƿ�ƥ��������ʽ�����Ĺ���  
        /// </summary>  
        /// <param name="inputStr">����֤���ַ���</param>  
        /// <param name="patternStr">������ʽ�ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsMatch(string inputStr, string patternStr)
        {
            return IsMatch(inputStr, patternStr, false, false);
        }

        /// <summary>  
        /// ��֤�ַ����Ƿ�ƥ��������ʽ�����Ĺ���  
        /// </summary>  
        /// <param name="inputStr">����֤���ַ���</param>  
        /// <param name="patternStr">������ʽ�ַ���</param>  
        /// <param name="ifIgnoreCase">ƥ��ʱ�Ƿ����ִ�Сд</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsMatch(string inputStr, string patternStr, bool ifIgnoreCase)
        {
            return IsMatch(inputStr, patternStr, ifIgnoreCase, false);
        }

        /// <summary>  
        /// ��֤�ַ����Ƿ�ƥ��������ʽ�����Ĺ���  
        /// </summary>  
        /// <param name="inputStr">����֤���ַ���</param>  
        /// <param name="patternStr">������ʽ�ַ���</param>  
        /// <param name="ifValidateWhiteSpace">�Ƿ���֤�հ��ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        //public static bool IsMatch(string inputStr, string patternStr, bool ifValidateWhiteSpace)
        //{
        //    return IsMatch(inputStr, patternStr, false, ifValidateWhiteSpace);
        //}

        /// <summary>  
        /// ��֤�ַ����Ƿ�ƥ��������ʽ�����Ĺ���  
        /// </summary>  
        /// <param name="inputStr">����֤���ַ���</param>  
        /// <param name="patternStr">������ʽ�ַ���</param>  
        /// <param name="ifIgnoreCase">ƥ��ʱ�Ƿ����ִ�Сд</param>  
        /// <param name="ifValidateWhiteSpace">�Ƿ���֤�հ��ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsMatch(string inputStr, string patternStr, bool ifIgnoreCase, bool ifValidateWhiteSpace)
        {
            if (!ifValidateWhiteSpace && string.IsNullOrEmpty(inputStr))//.NET 4.0 ����IsNullOrWhiteSpace ���������ڶ��û�������
                return false;//�����Ҫ����֤�հ��ַ�������ʱ����Ĵ���֤�ַ���Ϊ�հ��ַ�������ƥ��  
            Regex regex = null;
            if (ifIgnoreCase)
                regex = new Regex(patternStr, RegexOptions.IgnoreCase);//ָ�������ִ�Сд��ƥ��  
            else
                regex = new Regex(patternStr);
            return regex.IsMatch(inputStr);
        }
        #endregion

        #region ��֤����
        /// <summary>  
        /// ��֤����(double����)  
        /// [���԰������ź�С����]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsNumber(string input)
        {
            //string pattern = @"^-?\d+$|^(-?\d+)(\.\d+)?$";  
            //return IsMatch(input, pattern);  
            double d = 0;
            if (double.TryParse(input, out d))
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤����  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsInteger(string input)
        {
            //string pattern = @"^-?\d+$";  
            //return IsMatch(input, pattern);  
            int i = 0;
            if (int.TryParse(input, out i))
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤�Ǹ�����  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIntegerNotNagtive(string input)
        {
            //string pattern = @"^\d+$";  
            //return IsMatch(input, pattern);  
            int i = -1;
            if (int.TryParse(input, out i) && i >= 0)
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤������  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIntegerPositive(string input)
        {
            //string pattern = @"^[0-9]*[1-9][0-9]*$";  
            //return IsMatch(input, pattern);  
            int i = 0;
            if (int.TryParse(input, out i) && i >= 1)
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤С��  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsDecimal(string input)
        {
            string pattern = @"^([-+]?[1-9]\d*\.\d+|-?0\.\d*[1-9]\d*)$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��ֻ֤����Ӣ����ĸ  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsEnglishCharacter(string input)
        {
            string pattern = @"^[A-Za-z]+$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��ֻ֤�������ֺ�Ӣ����ĸ  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIntegerAndEnglishCharacter(string input)
        {
            string pattern = @"^[0-9A-Za-z]+$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��ֻ֤��������  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsChineseCharacter(string input)
        {
            string pattern = @"^[\u4e00-\u9fa5]+$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤���ֳ��ȷ�Χ������ǰ�˵�0�Ƴ��ȣ�  
        /// [��Ҫ��֤�̶����ȣ��ɴ�����ͬ������������ֵ]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <param name="lengthBegin">���ȷ�Χ��ʼֵ������</param>  
        /// <param name="lengthEnd">���ȷ�Χ����ֵ������</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIntegerLength(string input, int lengthBegin, int lengthEnd)
        {
            //string pattern = @"^\d{" + lengthBegin + "," + lengthEnd + "}$";  
            //return IsMatch(input, pattern);  
            if (input.Length >= lengthBegin && input.Length <= lengthEnd)
            {
                int i;
                if (int.TryParse(input, out i))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>  
        /// ��֤�ַ�����������  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <param name="withEnglishCharacter">�Ƿ����Ӣ����ĸ</param>  
        /// <param name="withNumber">�Ƿ��������</param>  
        /// <param name="withChineseCharacter">�Ƿ��������</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsStringInclude(string input, bool withEnglishCharacter, bool withNumber, bool withChineseCharacter)
        {
            if (!withEnglishCharacter && !withNumber && !withChineseCharacter)
                return false;//���Ӣ����ĸ�����ֺͺ��ֶ�û�У��򷵻�false  
            StringBuilder patternString = new StringBuilder();
            patternString.Append("^[");
            if (withEnglishCharacter)
                patternString.Append("a-zA-Z");
            if (withNumber)
                patternString.Append("0-9");
            if (withChineseCharacter)
                patternString.Append(@"\u4E00-\u9FA5");
            patternString.Append("]+$");
            return IsMatch(input, patternString.ToString());
        }

        /// <summary>  
        /// ��֤�ַ������ȷ�Χ  
        /// [��Ҫ��֤�̶����ȣ��ɴ�����ͬ������������ֵ]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <param name="lengthBegin">���ȷ�Χ��ʼֵ������</param>  
        /// <param name="lengthEnd">���ȷ�Χ����ֵ������</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsStringLength(string input, int lengthBegin, int lengthEnd)
        {
            //string pattern = @"^.{" + lengthBegin + "," + lengthEnd + "}$";  
            //return IsMatch(input, pattern);  
            if (input.Length >= lengthBegin && input.Length <= lengthEnd)
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤�ַ������ȷ�Χ���ַ�����ֻ�������ֺ�/��Ӣ����ĸ��  
        /// [��Ҫ��֤�̶����ȣ��ɴ�����ͬ������������ֵ]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <param name="lengthBegin">���ȷ�Χ��ʼֵ������</param>  
        /// <param name="lengthEnd">���ȷ�Χ����ֵ������</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsStringLengthOnlyNumberAndEnglishCharacter(string input, int lengthBegin, int lengthEnd)
        {
            string pattern = @"^[0-9a-zA-z]{" + lengthBegin + "," + lengthEnd + "}$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤�ַ������ȷ�Χ  
        /// [��Ҫ��֤�̶����ȣ��ɴ�����ͬ������������ֵ]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <param name="withEnglishCharacter">�Ƿ����Ӣ����ĸ</param>  
        /// <param name="withNumber">�Ƿ��������</param>  
        /// <param name="withChineseCharacter">�Ƿ��������</param>  
        /// <param name="lengthBegin">���ȷ�Χ��ʼֵ������</param>  
        /// <param name="lengthEnd">���ȷ�Χ����ֵ������</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsStringLengthByInclude(string input, bool withEnglishCharacter, bool withNumber, bool withChineseCharacter, int lengthBegin, int lengthEnd)
        {
            if (!withEnglishCharacter && !withNumber && !withChineseCharacter)
                return false;//���Ӣ����ĸ�����ֺͺ��ֶ�û�У��򷵻�false  
            StringBuilder patternString = new StringBuilder();
            patternString.Append("^[");
            if (withEnglishCharacter)
                patternString.Append("a-zA-Z");
            if (withNumber)
                patternString.Append("0-9");
            if (withChineseCharacter)
                patternString.Append(@"\u4E00-\u9FA5");
            patternString.Append("]{" + lengthBegin + "," + lengthEnd + "}$");
            return IsMatch(input, patternString.ToString());
        }

        /// <summary>  
        /// ��֤�ַ����ֽ������ȷ�Χ  
        /// [��Ҫ��֤�̶����ȣ��ɴ�����ͬ������������ֵ��ÿ������Ϊ�����ֽڳ���]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <param name="lengthBegin">���ȷ�Χ��ʼֵ������</param>  
        /// <param name="lengthEnd">���ȷ�Χ����ֵ������</param>  
        /// <returns></returns>  
        public static bool IsStringByteLength(string input, int lengthBegin, int lengthEnd)
        {
            //int byteLength = Regex.Replace(input, @"[^\x00-\xff]", "ok").Length;  
            //if (byteLength >= lengthBegin && byteLength <= lengthEnd)  
            //{  
            //    return true;  
            //}  
            //return false;  
            int byteLength = Encoding.Default.GetByteCount(input);
            if (byteLength >= lengthBegin && byteLength <= lengthEnd)
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤����  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsDateTime(string input)
        {
            DateTime dt;
            if (DateTime.TryParse(input, out dt))
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤�̶��绰����  
        /// [3λ��4λ���ţ����ſ�����С���������������ſ���ʡ�ԣ������뱾�غż�����ü��Ż�ո������������3λ���ķֻ��ţ��ֻ���ǰҪ�Ӽ���]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsTelePhoneNumber(string input)
        {
            string pattern = @"^(((0\d2|0\d{2})[- ]?)?\d{8}|((0\d3|0\d{3})[- ]?)?\d{7})(-\d{3})?$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤�ֻ�����  
        /// [��ƥ��"(+86)013325656352"�����ſ���ʡ�ԣ�+�ſ���ʡ�ԣ�(+86)����ʡ�ԣ�11λ�ֻ���ǰ��0����ʡ�ԣ�11λ�ֻ��ŵڶ�λ��������3��4��5��8�е�����һ��]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsMobilePhoneNumber(string input)
        {
            string pattern = @"^((\+)?86|((\+)?86)?)0?1[3458]\d{9}$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤�绰���루�����ǹ̶��绰������ֻ����룩  
        /// [�̶��绰��[3λ��4λ���ţ����ſ�����С���������������ſ���ʡ�ԣ������뱾�غż�����ü��Ż�ո������������3λ���ķֻ��ţ��ֻ���ǰҪ�Ӽ���]]  
        /// [�ֻ����룺[��ƥ��"(+86)013325656352"�����ſ���ʡ�ԣ�+�ſ���ʡ�ԣ�(+86)����ʡ�ԣ��ֻ���ǰ��0����ʡ�ԣ��ֻ��ŵڶ�λ��������3��4��5��8�е�����һ��]]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsPhoneNumber(string input)
        {
            string pattern = @"^((\+)?86|((\+)?86)?)0?1[3458]\d{9}$|^(((0\d2|0\d{2})[- ]?)?\d{8}|((0\d3|0\d{3})[- ]?)?\d{7})(-\d{3})?$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤��������  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsZipCode(string input)
        {
            //string pattern = @"^\d{6}$";  
            //return IsMatch(input, pattern);  
            if (input.Length != 6)
                return false;
            int i;
            if (int.TryParse(input, out i))
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤��������  
        /// [@�ַ�ǰ���԰�����ĸ�����֡��»��ߺ͵�ţ�@�ַ�����԰�����ĸ�����֡��»��ߺ͵�ţ�@�ַ������ٰ���һ������ҵ�Ų��������һ���ַ������һ����ź�ֻ������ĸ������]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsEmail(string input)
        {
            ////�����������ֻ���ĸ��ͷ��������������ĸ�����֡���š����š��»�����ɣ���������@ǰ���ַ�������Ϊ3��18���ַ��������������Ե�š����Ż��»��߽�β�����ܳ��������������������ϵĵ�š����š�  
            //string pattern = @"^[a-zA-Z0-9]((?<!(\.\.|--))[a-zA-Z0-9\._-]){1,16}[a-zA-Z0-9]@([0-9a-zA-Z][0-9a-zA-Z-]{0,62}\.)+([0-9a-zA-Z][0-9a-zA-Z-]{0,62})\.?|((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$";  
            string pattern = @"^([\w-\.]+)@([\w-\.]+)(\.[a-zA-Z0-9]+)$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤��ַ������ƥ��IPv4��ַ��û��IPv4��ַ���и�ʽ��֤��IPv6��ʱû��ƥ�䣩  
        /// [����ʡ��"://"��������Ӷ˿ںţ�����㼶�������Σ�����������һ������Ҵ˵��ǰҪ������]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsURL(string input)
        {
            ////ÿ����������ĸ�����ֺͼ��Ź��ɣ���һ����ĸ�����Ǽ��ţ��������ִ�Сд�������򳤶Ȳ�����63������������ȫ��������256���ַ�����DNSϵͳ�У�ȫ������һ���㡰.���������ģ����硰www.nit.edu.cn.����û�������Ǹ������ʾһ����Ե�ַ��   
            ////û������"http://"��ǰ׺��û�д��ε�ƥ��  
            //string pattern = @"^([0-9a-zA-Z][0-9a-zA-Z-]{0,62}\.)+([0-9a-zA-Z][0-9a-zA-Z-]{0,62})\.?$";  

            //string pattern = @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&%_\./-~-]*)?$";  
            string pattern = @"^([a-zA-Z]+://)?([\w-\.]+)(\.[a-zA-Z0-9]+)(:\d{0,5})?/?([\w-/]*)\.?([a-zA-Z]*)\??(([\w-]*=[\w%]*&?)*)$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ��֤IPv4��ַ  
        /// [��һλ�����һλ���ֲ�����0��255��������0��λ]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIPv4(string input)
        {
            //string pattern = @"^(25[0-4]|2[0-4]\d]|[01]?\d{2}|[1-9])\.(25[0-5]|2[0-4]\d]|[01]?\d?\d)\.(25[0-5]|2[0-4]\d]|[01]?\d?\d)\.(25[0-4]|2[0-4]\d]|[01]?\d{2}|[1-9])$";  
            //return IsMatch(input, pattern);  
            string[] IPs = input.Split('.');
            if (IPs.Length != 4)
                return false;
            int n = -1;
            for (int i = 0; i < IPs.Length; i++)
            {
                if (i == 0 || i == 3)
                {
                    if (int.TryParse(IPs[i], out n) && n > 0 && n < 255)
                        continue;
                    else
                        return false;
                }
                else
                {
                    if (int.TryParse(IPs[i], out n) && n >= 0 && n <= 255)
                        continue;
                    else
                        return false;
                }
            }
            return true;
        }

        /// <summary>  
        /// ��֤IPv6��ַ  
        /// [������ƥ���κ�һ���Ϸ���IPv6��ַ]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIPv6(string input)
        {
            string pattern = @"^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$";
            return IsMatch(input, pattern);
        }

        /// <summary>  
        /// ���֤�����ֶ�Ӧ�ĵ�ַ  
        /// </summary>  
        //enum IDAddress  
        //{  
        //    ���� = 11, ��� = 12, �ӱ� = 13, ɽ�� = 14, ���ɹ� = 15, ���� = 21, ���� = 22, ������ = 23, �Ϻ� = 31, ���� = 32, �㽭 = 33,  
        //    ���� = 34, ���� = 35, ���� = 36, ɽ�� = 37, ���� = 41, ���� = 42, ���� = 43, �㶫 = 44, ���� = 45, ���� = 46, ���� = 50, �Ĵ� = 51,  
        //    ���� = 52, ���� = 53, ���� = 54, ���� = 61, ���� = 62, �ຣ = 63, ���� = 64, �½� = 65, ̨�� = 71, ��� = 81, ���� = 82, ���� = 91  
        //}  

        /// <summary>  
        /// ��֤һ�����֤�ţ�15λ����  
        /// [����Ϊ15λ�����֣�ƥ���Ӧʡ�ݵ�ַ����������ȷƥ��]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIDCard15(string input)
        {
            //��֤�Ƿ����ת��Ϊ15λ����  
            long l = 0;
            if (!long.TryParse(input, out l) || l.ToString().Length != 15)
            {
                return false;
            }
            //��֤ʡ���Ƿ�ƥ��  
            //1~6λΪ�������룬����1��2λ��Ϊ��ʡ�������Ĵ��룬3��4λ��Ϊ�ء��м������Ĵ��룬5��6λ��Ϊ�ء������������롣  
            string address = "11,12,13,14,15,21,22,23,31,32,33,34,35,36,37,41,42,43,44,45,46,50,51,52,53,54,61,62,63,64,65,71,81,82,91,";
            if (!address.Contains(input.Remove(2) + ","))
            {
                return false;
            }
            //��֤�����Ƿ�ƥ��  
            string birthdate = input.Substring(6, 6).Insert(4, "/").Insert(2, "/");
            DateTime dt;
            if (!DateTime.TryParse(birthdate, out dt))
            {
                return false;
            }
            return true;
        }

        /// <summary>  
        /// ��֤�������֤�ţ�18λ����GB11643-1999��׼��  
        /// [����Ϊ18λ��ǰ17λΪ���֣����һλ(У����)����Ϊ��Сдx��ƥ���Ӧʡ�ݵ�ַ����������ȷƥ�䣻У��������ȷƥ��]  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIDCard18(string input)
        {
            //��֤�Ƿ����ת��Ϊ��ȷ������  
            long l = 0;
            if (!long.TryParse(input.Remove(17), out l) || l.ToString().Length != 17 || !long.TryParse(input.Replace('x', '0').Replace('X', '0'), out l))
            {
                return false;
            }
            //��֤ʡ���Ƿ�ƥ��  
            //1~6λΪ�������룬����1��2λ��Ϊ��ʡ�������Ĵ��룬3��4λ��Ϊ�ء��м������Ĵ��룬5��6λ��Ϊ�ء������������롣  
            string address = "11,12,13,14,15,21,22,23,31,32,33,34,35,36,37,41,42,43,44,45,46,50,51,52,53,54,61,62,63,64,65,71,81,82,91,";
            if (!address.Contains(input.Remove(2) + ","))
            {
                return false;
            }
            //��֤�����Ƿ�ƥ��  
            string birthdate = input.Substring(6, 8).Insert(6, "/").Insert(4, "/");
            DateTime dt;
            if (!DateTime.TryParse(birthdate, out dt))
            {
                return false;
            }
            //У������֤  
            //У���룺  
            //��1��ʮ��λ���ֱ������Ȩ��͹�ʽ   
            //S = Sum(Ai * Wi), i = 0, ... , 16 ���ȶ�ǰ17λ���ֵ�Ȩ���   
            //Ai:��ʾ��iλ���ϵ����֤��������ֵ   
            //Wi:��ʾ��iλ���ϵļ�Ȩ����   
            //Wi: 7 9 10 5 8 4 2 1 6 3 7 9 10 5 8 4 2   
            //��2������ģ   
            //Y = mod(S, 11)   
            //��3��ͨ��ģ�õ���Ӧ��У����   
            //Y: 0 1 2 3 4 5 6 7 8 9 10   
            //У����: 1 0 X 9 8 7 6 5 4 3 2   
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = input.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != input.Substring(17, 1).ToLower())
            {
                return false;
            }
            return true;
        }

        /// <summary>  
        /// ��֤���֤�ţ�������һ�������֤�ţ�  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsIDCard(string input)
        {
            if (input.Length == 18)
                return IsIDCard18(input);
            else if (input.Length == 15)
                return IsIDCard15(input);
            else
                return false;
        }

        /// <summary>  
        /// ��֤����  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsLongitude(string input)
        {
            ////��ΧΪ-180��180��С��λ��������1��5λ  
            //string pattern = @"^[-\+]?((1[0-7]\d{1}|0?\d{1,2})\.\d{1,5}|180\.0{1,5})$";  
            //return IsMatch(input, pattern);  
            float lon;
            if (float.TryParse(input, out lon) && lon >= -180 && lon <= 180)
                return true;
            else
                return false;
        }

        /// <summary>  
        /// ��֤γ��  
        /// </summary>  
        /// <param name="input">����֤���ַ���</param>  
        /// <returns>�Ƿ�ƥ��</returns>  
        public static bool IsLatitude(string input)
        {
            ////��ΧΪ-90��90��С��λ��������1��5λ  
            //string pattern = @"^[-\+]?([0-8]?\d{1}\.\d{1,5}|90\.0{1,5})$";  
            //return IsMatch(input, pattern);  
            float lat;
            if (float.TryParse(input, out lat) && lat >= -90 && lat <= 90)
                return true;
            else
                return false;
        }
        #endregion
    }
