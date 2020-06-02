using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace Broom.Models.ViewModels
{
    public class BModelViewModel
    {
        public BModel BModel { get; set; }
        public IEnumerable<Make> Makes { get; set; }


    }
}
