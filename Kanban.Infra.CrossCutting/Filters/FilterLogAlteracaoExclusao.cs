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
            if (_name == "Alterar" || _name == "Remover")
            {
                var id = context.HttpContext.Request.QueryString;
                Console.WriteLine($"{DateTime.Now} - Id: {id} - {_name}");
            }

        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
