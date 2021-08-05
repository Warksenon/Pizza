using Pizza;

namespace Test.Test
{
    public class FakeDialog : IDialogService
    {
        public string Message { get; private set; }

        public FakeDialog ()
        {
            Message = "";
        }

        public void ShowMessage ( string message )
        {
            Message = message;
        }
    }
}
