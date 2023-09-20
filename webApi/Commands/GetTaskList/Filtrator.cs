using MediatR;

namespace webApi.Commands.GetTaskList
{
    public class Filtrator
    {
        public Filtrator(string propertyName, string value)
        {
            _propertyName = propertyName;
            _value = value;
        }

        private string _propertyName;
        private string _value;

        public IEnumerable<T> Filter<T>(IEnumerable<T> collection) where T : Entities.Task
        {
            var property = typeof(T).GetProperty(_propertyName);

            if (property != null && string.IsNullOrEmpty(_value) == false)
            {
                return collection.Where(task => property.GetValue(task).ToString().Contains(_value))
                    .ToList();
            }

            return collection;
        }
    }
}
