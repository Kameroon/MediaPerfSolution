using Prism.Events;

namespace MediaPerf.Infrastructure.Events
{
    public class SendMessageEvent : PubSubEvent<string>
    {
    }
}
