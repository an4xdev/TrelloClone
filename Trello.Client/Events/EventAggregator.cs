namespace Trello.Client.Events
{
    public class EventAggregator
    {
        private readonly Dictionary<string, List<Func<Task>>> _eventSubscriptions = [];

        public void Subscribe(string eventName, Func<Task> callback)
        {
            if (!_eventSubscriptions.TryGetValue(eventName, out List<Func<Task>>? value))
            {
                value = ([]);
                _eventSubscriptions[eventName] = value;
            }

            value.Add(callback);
        }

        public void Publish(string eventName)
        {
            if (_eventSubscriptions.TryGetValue(eventName, out List<Func<Task>>? value))
            {
                foreach (var callback in value)
                {
                    callback.Invoke();
                }
            }
        }
    }
}
