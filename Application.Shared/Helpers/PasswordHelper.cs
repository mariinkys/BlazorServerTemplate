namespace Application.Shared.Helpers
{
    public static class PasswordHelper
    {
        public static string Encrypt(this string stringToEncrypt)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(stringToEncrypt);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
