//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_Demo3
{
    using System;
    using System.Collections.Generic;
    
    public partial class product_audits
    {
        public int change_id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public short model_year { get; set; }
        public decimal list_price { get; set; }
        public System.DateTime updated_at { get; set; }
        public string operation { get; set; }
    }
}
