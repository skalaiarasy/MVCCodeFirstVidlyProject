using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCCodeFirstVidly.Models;

namespace MVCCodeFirstVidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType>  MembershipTypes { get; set; }        
        public Customer Customer { get; set; }
    }
}