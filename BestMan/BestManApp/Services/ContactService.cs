using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.UserData;

namespace BestManApp.Services
{
    public class ContactService
    {
        public Task<Contact[]> GetAllContacts()
        {
            var taskCompletionSource =new TaskCompletionSource<Contact[]>();
            var contacts = new Contacts();
            try
            {
                contacts.SearchCompleted += (sender, args) => taskCompletionSource.SetResult(args.Results.ToArray());
                contacts.SearchAsync(String.Empty, FilterKind.None, null);
            }
            catch (Exception ex)
            {
                taskCompletionSource.SetException(ex);
            }
            return taskCompletionSource.Task;
        }
    }
}
