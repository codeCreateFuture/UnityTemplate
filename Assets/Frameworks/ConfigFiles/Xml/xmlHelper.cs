
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
namespace Helper
{
    public class xmlHelper
    {
        #region �ֶ�
        /// <summary>
        /// xml�ļ�����·��
        /// </summary>
        private string _FilePath = string.Empty;
        /// <summary>
        /// xml�ĵ�
        /// </summary>
        private XmlDocument _xml;
        /// <summary>
        /// xml�ĵ����ڵ�
        /// </summary>
        private XmlElement _element;
        #endregion
        public xmlHelper()
        {
            //
        }
        /// <summary>
        /// ��xml�ĵ�·����ֵ
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public xmlHelper(string xmlFilePath)
        {
            _FilePath = xmlFilePath;
        }
        /// <summary>
        /// ��ȡָ��·���ڵ�
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public static XmlNode GetXmlNode(string xmlFileName, string xPath)
        {
            XmlDocument xmldocument = new XmlDocument();
            //����xml�ĵ�
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                return xmlnode;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ��ȡָ��·���ڵ��º��ӽڵ��б�
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public static XmlNodeList GetXmlNodeList(string xmlFileName, string xPath)
        {
            XmlDocument xmldocument = new XmlDocument();
            //����xml�ĵ�
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNodeList xmlnodelist = xmldocument.SelectNodes(xPath);
                return xmlnodelist;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ��ȡָ��·���ڵ��������ָ��������ƥ��
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath">Ҫƥ���XPath���ʽ(����:"//�ڵ���//�ӽڵ���</param>
        /// <param name="attributeName">ָ������������</param>
        /// <returns></returns>
        public static XmlAttribute GetXmlAttribute(string xmlFileName, string xPath, string attributeName)
        {
            XmlAttribute xmlattribute = null;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    if (xmlnode.Attributes.Count > 0)
                    {
                        xmlattribute = xmlnode.Attributes[attributeName];
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return xmlattribute;
        }
        /// <summary>
        /// ��ȡָ���ڵ�����Լ���
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public static XmlAttributeCollection GetNodeAttributes(string xmlFileName, string xPath)
        {
            XmlAttributeCollection xmlattributes = null;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    if (xmlnode.Attributes.Count > 0)
                    {
                        xmlattributes = xmlnode.Attributes;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return xmlattributes;
        }
        /// <summary>
        /// ����ָ���ڵ��ĳһ�����趨������ֵvalue
        /// </summary>
        /// <param name="xmlFileName">xml�ĵ�·��</param>
        /// <param name="xPath"></param>
        /// <param name="attributeOldeName">����������</param>
        /// <param name="attributeNewName">����������</param>
        /// <param name="value">����ֵ</param>
        /// <returns>�ɹ�����true,ʧ�ܷ���false</returns>
        public static bool UpdateAttribute(string xmlFileName, string xPath, string attributeName, string value)
        {
            bool isSuccess = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    foreach (XmlAttribute attribute in xmlnode.Attributes)
                    {
                        if (attribute.Name.ToString().ToLower() == attributeName.ToLower())
                        {
                            isSuccess = true;
                            attribute.Value = value;
                            xmldocument.Save(xmlFileName);
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// ɾ��ָ���ڵ����������
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <returns>�ɹ�����true,ʧ�ܷ���false</returns>
        public static bool DeleteAttributes(string xmlFileName, string xPath)
        {
            bool isSuccess = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    if (xmlnode.Attributes.Count > 0)
                    {
                        xmlnode.Attributes.RemoveAll();
                        xmldocument.Save(xmlFileName);
                        isSuccess = true;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// ɾ��ƥ���������Ƶ�ָ���ڵ������
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static bool DeleteOneAttribute(string xmlFileName, string xPath, string attributeName)
        {
            bool isSuccess = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            XmlAttribute xmlAttribute = null;
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    if (xmlnode.Attributes.Count > 0)
                    {
                        foreach (XmlAttribute attribute in xmlnode.Attributes)
                        {
                            if (attribute.Name.ToLower() == attributeName.ToLower())
                            {
                                xmlAttribute = attribute;
                                break;
                            }
                        }
                    }
                    if (xmlAttribute != null)
                    {
                        xmlnode.Attributes.Remove(xmlAttribute);
                        xmldocument.Save(xmlFileName);
                        isSuccess = true;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// ����ָ���ڵ������,������Դ����򲻴���
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AddAttribute(string xmlFileName, string xPath, string attributeName, string value)
        {
            bool isSuccess = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    if (xmlnode.Attributes.Count > 0)//�����ж����޴�����
                    {
                        foreach (XmlAttribute attribute in xmlnode.Attributes)
                        {
                            if (attribute.Name.ToLower() == attributeName.ToLower())
                            {
                                //���򲻸ģ�ֱ�ӷ���true;
                                return true;
                            }
                        }
                    }
                    XmlAttribute xmlAttribute = xmldocument.CreateAttribute(attributeName);
                    xmlAttribute.Value = value;
                    xmlnode.Attributes.Append(xmlAttribute);
                    xmldocument.Save(xmlFileName);
                    isSuccess = true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// Ϊĳһָ��·���ڵ�������µĽڵ㣬����ýڵ���ڣ������
        /// </summary>
        /// <param name="xmlFileName">xml�ĵ�·��</param>
        /// <param name="xPath">��Ҫ��ӽڵ��·��</param>
        /// <param name="nodeName">�ڵ�����</param>
        /// <param name="innerText">�ڵ��ı�ֵ</param>
        /// <returns>�ɹ�����true,���ڷ���false</returns>
        public static bool AddNode(string xmlFileName, string xPath, string nodeName, string innerText)
        {
            bool isSuccess = false;
            bool isExisitNode = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    isExisitNode = true;
                }
                if (!isExisitNode)
                {
                    XmlElement subElement = xmldocument.CreateElement(nodeName);
                    subElement.InnerText = innerText;
                    xmlnode.AppendChild(subElement);
                    isSuccess = true;
                    xmldocument.Save(xmlFileName);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// ����ָ���Ľڵ㣬������ڵ�ֵ
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static bool UpdateNode(string xmlFileName, string xPath, string nodeName, string innerText)
        {
            bool isSuccess = false;
            bool isExisitNode = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
            try
            {
                if (xmlnode != null)
                {
                    isExisitNode = true;
                }
                if (!isExisitNode)
                {
                    xmlnode.InnerText = innerText;
                    isSuccess = true;
                    xmldocument.Save(xmlFileName);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// ɾ��ָ���ڵ�����ΪnodeName�����нڵ㣬����ýڵ����ӽڵ㣬����ɾ��
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static bool deleteNode(string xmlFileName, string xPath, string nodeName)
        {
            bool isSuccess = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    if (xmlnode.HasChildNodes)
                    {
                        isSuccess = false;
                    }
                    else
                    {
                        xmlnode.ParentNode.RemoveChild(xmlnode);//ɾ���ڵ�
                        isSuccess = true;
                        xmldocument.Save(xmlFileName);
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        /// <summary>
        /// ����ָ���ڵ����Ƹ�������ָ�����ӽڵ��ֵ
        /// </summary>
        /// <param name="xmlFileName"></param>
        /// <param name="xPath"></param>
        /// <param name="nodeName"></param>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static bool UpdateChildNode(string xmlFileName, string xPath, string nodeName, string childName, string innerText)
        {
            bool isSuccess = false;
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(xmlFileName);
            try
            {
                XmlNode xmlnode = xmldocument.SelectSingleNode(xPath);
                if (xmlnode != null)
                {
                    foreach (XmlNode node in xmlnode.ChildNodes)
                    {
                        if (node.Name.ToLower() == childName.ToLower())
                        {
                            node.InnerText = innerText;
                            xmldocument.Save(xmlFileName);
                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return isSuccess;
        }
        #region ����XML�ĸ��ڵ�
        /// <summary>
        /// ����XML�ĸ��ڵ�
        /// </summary>
        private void CreateXMLElement()
        {
            //����һ��XML����
            _xml = new XmlDocument();
            if (File.Exists(_FilePath))
            {
                //����XML�ļ�
                _xml.Load(this._FilePath);
            }
            //ΪXML�ĸ��ڵ㸳ֵ
            _element = _xml.DocumentElement;
        }
        #endregion
        #region ����XML�ļ�
        /// <summary>
        /// ����XML�ļ�
        /// </summary>        
        public void Save()
        {
            //����XML�ĸ��ڵ�
            //CreateXMLElement();
            //����XML�ļ�
            _xml.Save(this._FilePath);
        }
        #endregion //����XML�ļ�
        #region XML�ĵ������ͽڵ�����Ե���ӡ��޸�
        /// <summary>
        /// ����һ��XML�ĵ�
        /// </summary>
        /// <param name="xmlFileName">XML�ĵ���ȫ�ļ���(��������·��)</param>
        /// <param name="rootNodeName">XML�ĵ����ڵ�����(��ָ��һ�����ڵ�����)</param>
        /// <param name="version">XML�ĵ��汾��(����Ϊ:"1.0")</param>
        /// <param name="encoding">XML�ĵ����뷽ʽ</param>
        /// <param name="standalone">��ֵ������"yes"��"no",���Ϊnull,Save��������XML������д����������</param>
        /// <returns>�ɹ�����true,ʧ�ܷ���false</returns>
        public static bool CreateXmlDocument(string xmlFileName, string rootNodeName, string version, string encoding, string standalone)
        {
            bool isSuccess = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration(version, encoding, null);
                XmlNode root = xmlDoc.CreateElement(rootNodeName);
                xmlDoc.AppendChild(xmlDeclaration);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFileName);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //������Զ������Լ����쳣����
            }
            return isSuccess;
        }
        #endregion
    }
}




#region example use
/*
 *
 using System.Xml;
using System.Data;
namespace DotNet.Utilities
{
    /// <summary>
    /// Xml�Ĳ���������
    /// </summary>    
    public class XmlHelper
    {
        #region �ֶζ���
        /// <summary>
        /// XML�ļ�������·��
        /// </summary>
        private string _filePath = string.Empty;
        /// <summary>
        /// Xml�ĵ�
        /// </summary>
        private XmlDocument _xml;
        /// <summary>
        /// XML�ĸ��ڵ�
        /// </summary>
        private XmlElement _element;
        #endregion
        #region ���췽��
        /// <summary>
        /// ʵ����XmlHelper����
        /// </summary>
        /// <param name="xmlFilePath">Xml�ļ������·��</param>
        public XmlHelper(string xmlFilePath)
        {
            //��ȡXML�ļ��ľ���·��
            _filePath = SysHelper.GetPath(xmlFilePath);
        }
        #endregion
        #region ����XML�ĸ��ڵ�
        /// <summary>
        /// ����XML�ĸ��ڵ�
        /// </summary>
        private void CreateXMLElement()
        {
            //����һ��XML����
            _xml = new XmlDocument();
            if (DirFile.IsExistFile(_filePath))
            {
                //����XML�ļ�
                _xml.Load(this._filePath);
            }
            //ΪXML�ĸ��ڵ㸳ֵ
            _element = _xml.DocumentElement;
        }
        #endregion
        #region ��ȡָ��XPath���ʽ�Ľڵ����
        /// <summary>
        /// ��ȡָ��XPath���ʽ�Ľڵ����
        /// </summary>        
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        public XmlNode GetNode(string xPath)
        {
            //����XML�ĸ��ڵ�
            CreateXMLElement();
            //����XPath�ڵ�
            return _element.SelectSingleNode(xPath);
        }
        #endregion
        #region ��ȡָ��XPath���ʽ�ڵ��ֵ
        /// <summary>
        /// ��ȡָ��XPath���ʽ�ڵ��ֵ
        /// </summary>
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        public string GetValue(string xPath)
        {
            //����XML�ĸ��ڵ�
            CreateXMLElement();
            //����XPath�ڵ��ֵ
            return _element.SelectSingleNode(xPath).InnerText;
        }
        #endregion
        #region ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// <summary>
        /// ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// </summary>
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        /// <param name="attributeName">������</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            //����XML�ĸ��ڵ�
            CreateXMLElement();
            //����XPath�ڵ������ֵ
            return _element.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion
        #region �����ڵ�
        /// <summary>
        /// 1. ���ܣ������ڵ㡣
        /// 2. ʹ��������������ڵ���뵽��ǰXml�ļ��С�
        /// </summary>        
        /// <param name="xmlNode">Ҫ�����Xml�ڵ�</param>
        public void AppendNode(XmlNode xmlNode)
        {
            //����XML�ĸ��ڵ�
            CreateXMLElement();
            //����ڵ�
            XmlNode node = _xml.ImportNode(xmlNode, true);
            //���ڵ���뵽���ڵ���
            _element.AppendChild(node);
        }
        /// <summary>
        /// 1. ���ܣ������ڵ㡣
        /// 2. ʹ����������DataSet�еĵ�һ����¼����Xml�ļ��С�
        /// </summary>        
        /// <param name="ds">DataSet��ʵ������DataSet��Ӧ��ֻ��һ����¼</param>
        public void AppendNode(DataSet ds)
        {
            //����XmlDataDocument����
            XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);
            //����ڵ�
            XmlNode node = xmlDataDocument.DocumentElement.FirstChild;
            //���ڵ���뵽���ڵ���
            AppendNode(node);
        }
        #endregion
        #region ɾ���ڵ�
        /// <summary>
        /// ɾ��ָ��XPath���ʽ�Ľڵ�
        /// </summary>        
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        public void RemoveNode(string xPath)
        {
            //����XML�ĸ��ڵ�
            CreateXMLElement();
            //��ȡҪɾ���Ľڵ�
            XmlNode node = _xml.SelectSingleNode(xPath);
            //ɾ���ڵ�
            _element.RemoveChild(node);
        }
        #endregion //ɾ���ڵ�
        #region ����XML�ļ�
        /// <summary>
        /// ����XML�ļ�
        /// </summary>        
        public void Save()
        {
            //����XML�ĸ��ڵ�
            CreateXMLElement();
            //����XML�ļ�
            _xml.Save(this._filePath);
        }
        #endregion //����XML�ļ�
        #region ��̬����
        #region �������ڵ����
        /// <summary>
        /// �������ڵ����
        /// </summary>
        /// <param name="xmlFilePath">Xml�ļ������·��</param>        
        private static XmlElement CreateRootElement(string xmlFilePath)
        {
            //�����������ʾXML�ļ��ľ���·��
            string filePath = "";
            //��ȡXML�ļ��ľ���·��
            filePath = SysHelper.GetPath(xmlFilePath);
            //����XmlDocument����
            XmlDocument xmlDocument = new XmlDocument();
            //����XML�ļ�
            xmlDocument.Load(filePath);
            //���ظ��ڵ�
            return xmlDocument.DocumentElement;
        }
        #endregion
        #region ��ȡָ��XPath���ʽ�ڵ��ֵ
        /// <summary>
        /// ��ȡָ��XPath���ʽ�ڵ��ֵ
        /// </summary>
        /// <param name="xmlFilePath">Xml�ļ������·��</param>
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        public static string GetValue(string xmlFilePath, string xPath)
        {
            //����������
            XmlElement rootElement = CreateRootElement(xmlFilePath);
            //����XPath�ڵ��ֵ
            return rootElement.SelectSingleNode(xPath).InnerText;
        }
        #endregion
        #region ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// <summary>
        /// ��ȡָ��XPath���ʽ�ڵ������ֵ
        /// </summary>
        /// <param name="xmlFilePath">Xml�ļ������·��</param>
        /// <param name="xPath">XPath���ʽ,
        /// ����1: @"Skill/First/SkillItem", ��Ч�� @"//Skill/First/SkillItem"
        /// ����2: @"Table[USERNAME='a']" , []��ʾɸѡ,USERNAME��Table�µ�һ���ӽڵ�.
        /// ����3: @"ApplyPost/Item[@itemName='��λ���']",@itemName��Item�ڵ������.
        /// </param>
        /// <param name="attributeName">������</param>
        public static string GetAttributeValue(string xmlFilePath, string xPath, string attributeName)
        {
            //����������
            XmlElement rootElement = CreateRootElement(xmlFilePath);
            //����XPath�ڵ������ֵ
            return rootElement.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion
        #endregion
        public static void SetValue(string xmlFilePath, string xPath, string newtext)
        {
            //string path = SysHelper.GetPath(xmlFilePath);
            //var queryXML = from xmlLog in xelem.Descendants("msg_log")
            //               //��������ΪBin�ļ�¼
            //               where xmlLog.Element("user").Value == "Bin"
            //               select xmlLog;
            //foreach (XElement el in queryXML)
            //{
            //    el.Element("user").Value = "LiuBin";//��ʼ�޸�
            //}
            //xelem.Save(path);
        }
    }
}

*/



#endregion