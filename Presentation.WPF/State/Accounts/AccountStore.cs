
using SmartClassRoom.Domain.Models.Core;
using System;

namespace Presentation.WPF.State.Accounts
{
    /// <summary>
    /// Class AccountStore
    /// Write your documentation here
    /// </summary>
    public class AccountStore : IAccountStore
    {
        #region constructor
        #endregion
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}