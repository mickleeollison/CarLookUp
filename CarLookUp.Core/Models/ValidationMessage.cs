using CarLookUp.Core.Enums;

namespace CarLookUp.Core.Models
{
    public class ValidationMessage
    {
        public ValidationMessage(MessageTypes type, string messageText)
        {
            Type = type;
            Text = messageText;
        }

        public string Text { get; set; }
        public MessageTypes Type { get; set; }
    }
}
