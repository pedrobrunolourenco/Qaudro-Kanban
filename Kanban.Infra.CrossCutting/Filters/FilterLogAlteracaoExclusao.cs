using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Kanban.Infra.CrossCutting.Filters
{
    public class FilterLogAlteracaoExclusaoAttribute : Attribute, IActionFilter
    {
        private readonly string _name;
        public FilterLogAlteracaoExclusaoAttribute(string name)
        {
            _name = name;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Executado - {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Executando - {_name}" );
        }
    }
}
