using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;

namespace TodoAppMaui.Services
{
    public sealed class SecureStorageService : ISecureStorageService
    {
        private const string _sessionTokenKey = "SessionToken";
        private const string _sessionExpiryKey = "SessionExpiry";

        public async Task SetSessionCredentialsAsync(SessionCredentials credentials)
        {
            await SecureStorage.Default.SetAsync(_sessionTokenKey, credentials.Token);
            await SecureStorage.Default.SetAsync(_sessionExpiryKey, credentials.TokenExpiry.ToString());
        }

        public async Task<SessionCredentials?> GetSessionCredentialsAsync()
        {
            Task<string?> tokenTask = SecureStorage.Default.GetAsync(_sessionTokenKey);
            Task<string?> expiryTask = SecureStorage.Default.GetAsync(_sessionExpiryKey);

            await Task.WhenAll(tokenTask, expiryTask);

            if (tokenTask.Result == null || expiryTask.Result == null)
                return null;

            return new SessionCredentials(tokenTask.Result, DateTime.Parse(expiryTask.Result));
        }

        public void DeleteSessionCredentials()
        {
            SecureStorage.Default.Remove(_sessionTokenKey);
            SecureStorage.Default.Remove(_sessionExpiryKey);
        }
    }
}
