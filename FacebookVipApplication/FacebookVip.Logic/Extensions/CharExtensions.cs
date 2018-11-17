namespace FacebookVip.Logic.Extensions
{
    public static class CharExtensions
    {
        public static bool IsDigid(this char i_Char)
        {
            return char.IsDigit(i_Char) || i_Char == 8 || i_Char == 46;
        }
    }
}
