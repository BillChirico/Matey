﻿using System.Threading.Tasks;

namespace Matey.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
