using System.Linq;

namespace workshare.core.Extensions
{
    public static class StringNumero
    {
        public static string ApenasNumeros(this string str)
        {
            return new string(str.Where(char.IsDigit).ToArray());
        }
    }
}
