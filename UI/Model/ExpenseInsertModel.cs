using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Model
{
    public class ExpenseInsertModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        
        public bool IsCredit { get; set; }
       
        [Required]
        public DateTime Date {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }
        private DateTime? dateCreated = null;

    }
}
