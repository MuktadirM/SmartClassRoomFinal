using SmartClassRoom.Domain.Models.Core;
using System;

namespace Presentation.WPF.State.Accounts
{
    /// <summary>
    /// Interface IAccountStore 
    /// Write your documentation here 
    /// </summary>
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
