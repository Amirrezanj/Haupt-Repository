using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Models;

namespace TodoAppMaui.Abstractions
{
    public interface ISecureStorageService
    {
        Task SetSessionCredentialsAsync(SessionCredentials credentials);
        Task<SessionCredentials?> GetSessionCredentialsAsync();
        void DeleteSessionCredentials();
    }
}
