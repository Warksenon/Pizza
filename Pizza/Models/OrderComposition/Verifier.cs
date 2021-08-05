namespace Pizza.Models.OrderComposition
{
    public abstract class Verifier
    {
        protected string CheckIsNotNull ( string str )
        {
            if (string.IsNullOrEmpty( str ))
                return "";
            else
                return str;
        }
    }
}
