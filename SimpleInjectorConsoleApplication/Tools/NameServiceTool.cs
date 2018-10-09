using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjectorLibrary.Services;

namespace SimpleInjectorConsoleApplication.Tools
{
    public class NameServiceTool
    {
        public INameService _nameService { get; set; }

        public NameServiceTool(INameService nameService)
        {
            _nameService = nameService;
        }

        public void RunThisTool()
        {
            Console.WriteLine(_nameService.GetUser("1234").Name);
            _nameService.SetName("Tony");
            _nameService.SetId("7890");
            Console.WriteLine(_nameService.GetUser("7890").Name);
        }
    }
}
