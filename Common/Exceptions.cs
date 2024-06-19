using Microsoft.AspNetCore.Mvc.ModelBinding;

using System;

namespace BasicWebApiFirstExam.Common
{
    [Serializable]
    public class CompanyException : Exception
    {
        public CompanyException(string message) : base(message)
        {
        }
    }
}
