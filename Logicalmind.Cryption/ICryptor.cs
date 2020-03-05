namespace Logicalmind.Cryption
{
    public interface ICryptor
    {
        string Encrypt(string str);
        string Decrypt(string str);
    }
}
