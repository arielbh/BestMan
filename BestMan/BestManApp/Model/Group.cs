using System.Collections.Generic;
using System.Windows.Input;

namespace BestManApp.Model
{
    public class Group<T> : List<T>
    {
        public Group(string title, IEnumerable<T> items)
            : base(items)
        {
            this.Title = title;
        }

        public string Title {  get; set; }
    }
}