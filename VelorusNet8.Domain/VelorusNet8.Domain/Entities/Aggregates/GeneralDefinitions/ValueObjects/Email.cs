namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class Email
{
    public string SmtpServer { get; private set; } // Smtp Sunucu
    public string SenderEmail { get; private set; } // Gönderen EPosta
    public string SmtpUsername { get; private set; } // Smtp Kullanıcı Adı
    public string SmtpPassword { get; private set; } // Smtp Parola
    public string Port { get; private set; } // Port

    // Constructor
    public Email(string smtpServer, string senderEmail, string smtpUsername, string smtpPassword, string port)
    {
        SmtpServer = smtpServer;
        SenderEmail = senderEmail;
        SmtpUsername = smtpUsername;
        SmtpPassword = smtpPassword;
        Port = port;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is Email email)
        {
            return SmtpServer == email.SmtpServer &&
                   SenderEmail == email.SenderEmail &&
                   SmtpUsername == email.SmtpUsername &&
                   SmtpPassword == email.SmtpPassword &&
                   Port == email.Port;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(SmtpServer, SenderEmail, SmtpUsername, SmtpPassword, Port);
    }
}

