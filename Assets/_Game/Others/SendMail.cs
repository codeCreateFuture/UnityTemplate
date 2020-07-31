using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System;
/// <summary>
/// �����ʼ�����
///ע�⣺���͵ĸ���·����unity�µ�����·��
/// </summary>
public class SendMail : MonoBehaviour {

    string fileUnityFullPath = "screen.png";


    event EventHandler MyDownload;
    private void Start()
    {
        
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 50, 100, 40), "Capture"))
        {
            Debug.Log("Capture Screenshot");
            ScreenCapture.CaptureScreenshot("screen.png");
        }
        if (GUI.Button(new Rect(0, 0, 100, 40), "Send"))
        {
            SendEmail(fileUnityFullPath);
        }
    }

    private void SendEmail(string _fileUnityFullPath)
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("906188006@qq.com", "fdfdd");
        mail.To.Add("2836833199@qq.com");
        mail.Subject = "Test Mail";
        mail.Body = "This is for testing SMTP mail from GMAIL";
        mail.Attachments.Add(new Attachment(_fileUnityFullPath));

        SmtpClient smtpServer = new SmtpClient("smtp.qq.com");
        //smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("906188006@qq.com", "snvxlmrxdeurbbei") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

        smtpServer.Send(mail);
        Debug.Log("success");
    }

    void PrintPicture(string imgFullPathInWindows)
    {
        System.Diagnostics.Process.Start("mspaint.exe", "/pt " + imgFullPathInWindows);
    }
}
