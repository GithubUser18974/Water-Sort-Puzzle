using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class SendMailDemo : MonoBehaviour {
    public static SendMailDemo Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

string From = "mohamedaraby1296@gmail.com";
    string Name = "Mohamed Araby";
    public string To;
    public string Subject;
    public string  Message;
    public string author;
    public string age;
    public string gender;
    public string AttachmentFilename = "logo.jpg";
    public UserData userData;
    private void Start()
    {
        userData = new UserData();
        To = "badrawyproductions@gmail.com";
        Message = "TEST EMails";
    }
    public void SendMailWithAttachment()
    {
        Subject = userData.gender + " " + userData.name + " Age =" + userData.age;

        MailSingleton.Instance.SendMailWithAttachment(
            From, 
            Name, 
            To, 
            Subject, 
            Message, 
            Application.streamingAssetsPath + "/" + AttachmentFilename
        );
    }

    public void SendPlainMail()
    {
        Subject = userData.gender + " " + userData.name + " Age =" + userData.age;

        MailSingleton.Instance.SendPlainMail(
            From, 
            Name, 
            To, 
            Subject, 
            Message
        );
    }

    public void Quit() {
        Application.Quit();
    }

}
