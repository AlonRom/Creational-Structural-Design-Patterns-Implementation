using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FacebookVip.Model.Models;
using FacebookWrapper.ObjectModel;

namespace FacebookVip.Logic.Interfaces
{
    public interface IStrategyWriter
    {
        string Extention { get; }
        void Init();
        void WriteLine(String line);
        void Fini();
        IEnumerable<string> GetResult();
    }
}
