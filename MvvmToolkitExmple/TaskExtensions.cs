using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitExmple
{
    public static class TaskExtensions
    {
     
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }

          
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
