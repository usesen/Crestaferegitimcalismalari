namespace VelorusNet8.Domain.Entities.Aggregates.User;

public class UserAccount
{
 
    public string UserName { get; private set; }
    public string Email { get; private set; }

    public UserAccount(string username, string email)
    {
        UserName = username;
        Email = email;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (UserAccount)obj;

        return UserName == other.UserName &&
               Email == other.Email;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(UserName, Email);
    }

    public override string ToString()
    {
        return $"{UserName} ({Email})";
    }
}