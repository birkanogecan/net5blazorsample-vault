using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Model
{
    public class InvesmentInsertModel
    {
        [Required]
        public decimal Amount { get; set; }

        public decimal Quantity { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime Date
        {
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
